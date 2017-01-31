


using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

using MantleEngine.PluginComponents;
using MantleEngine.PluginUtilities;
using MantleEngine.Mathematics;


namespace MantleEngine.Transport { 

	public class Vehicle : MonoBehaviour {

		public enum VehicleState {
			IS_OUT_OF_BOUNDS,
			IS_TAP,
			IS_DOUBLE_TAP,
			IS_LONG_TAP,
			IS_START_DRAG

		};

		public enum VehicleBehaviour {
			DRIVING,
			STOPPED,
			DEAD
		}

		public enum MotionStyle
		{
			Lerp,
			Incremental
		}


		public const string ANIM_STATE_NAME_IDLE = "Idle";
		public const string ANIM_STATE_NAME_DRIVE = "Drive";
		public const string ANIM_STATE_NAME_DEATH = "Death";



		public bool autoStart = false;

		private bool usingTerrainHeight = false; 

		public float minWaitSecs = 0.5f;

		public float maxWaitSecs = 3f;

		public float altitude = 0.1f;

		public float speedMin = 0.3f;

		public float speedMax = 0.8f;

		public MotionStyle motionStyle = MotionStyle.Incremental;

		public bool animateTurns = false;

		public float turnSpeed = 0.5f;

		public float sampleDistance = 5;

		protected float stopTimeSecs = 0f;

		public bool isBlocked = false;

		public MantleTransportNetwork.RoadFeatureKind[] TraversableRoadTypes = null;

		protected float speed;
		//protected const int MAX_SPEED = 100;



		protected DateTime pauseUntilTime;
		protected DateTime nextPauseTime;

		protected float bounceSpeed ;
		protected Vector3 trans;

		protected Node fromNode;
		protected Vector3 fromPoint;

		protected Node toNode;
		protected Vector3 toPoint;

		protected Arc currArc;

		//protected Vector3 fwdDestinationVector;
		protected Quaternion fwdDestination;

		protected RaycastHit fwdHit;
		protected float covPct = 0f;
		protected float rotPct = 0f;

		protected Animator animator;

		public VehicleBehaviour vehicleBehaviour = VehicleBehaviour.STOPPED;

		protected DirectedGeoGraph3D currentNetwork = null;

		void Start() {
			usingTerrainHeight = Mantle.Instance.dataSource.useTerrainHeightServer;
			InitAppearance();
			//if (autoStart) {Init();}

		}

		public virtual void Init(Arc path, Node fromNode, Node toNode, MantleTransportNetwork.RoadFeatureKind[] traversableRoadTypes = null) {

			this.currArc = path;
			this.fromNode = fromNode;
			this.toNode = toNode;
			this.currentNetwork = toNode.network;
			this.currentNetwork.NetworkUnloadE += this.NetworkUnloadEvent;
			this.TraversableRoadTypes = traversableRoadTypes;
			RandomSpeed ();

			RefreshWaypoints();

			InitDriving();
			vehicleBehaviour = VehicleBehaviour.DRIVING;

			animator = gameObject.GetComponent<Animator>();
		}


		void Update () {
			if (vehicleBehaviour != VehicleBehaviour.DEAD) {
				Tick();
			}
		}

		public virtual void Tick() {

			switch(vehicleBehaviour) {
			case VehicleBehaviour.DRIVING:
				DoDefaultMotion();
				break;
			default: //case VehicleBehaviour.STOPPED:

				break;
			}

		}

		protected virtual void InitAppearance() {
			this.GetComponent<Renderer>().material.color = TransSimManager.RNG.RandomColor();
		}

		protected Vector3 fwdDirection = default(Vector3);

		public void RefreshWaypoints() 
		{
			Vector3 prevFwdDirection = fwdDirection * 2f;
			//Vector3 fullVector = toNode.WorldPos - transform.position; //fromNode.WorldPos;
			Vector3 fullVector = toNode.WorldPos - fromNode.WorldPos;
			fwdDirection = fullVector.normalized;
			remainingIncrements = (int)( currArc.ArcLength / (speed * Time.deltaTime));
			momentum = fullVector / remainingIncrements;

			Vector3 leftSideStart = fromNode.WorldPos + (Vector3.Cross (fwdDirection, Vector3.up) * currArc.ArcWidth * 0.25f);
			//Vector3 leftSideStart = transform.position + (Vector3.Cross (fwdDirection, Vector3.up) * currArc.ArcWidth * 0.5f);
			Vector3 leftSideEnd = toNode.WorldPos + (Vector3.Cross (fwdDirection, Vector3.up) * currArc.ArcWidth * 0.25f);


			this.fromPoint = leftSideStart + (Vector3.up * (altitude + fromNode.groundHeight));
			this.toPoint = leftSideEnd + (Vector3.up * (altitude + toNode.groundHeight));


			Vector3 intersectionPoint;
			if (prevFwdDirection != default(Vector3) 
				&& Geometry.TryGetLineIntersectionPointXZ (fromPoint.Grounded(), 
					toPoint.Grounded(), transform.position.Grounded(), 
					(transform.position + prevFwdDirection).Grounded(), 
					out intersectionPoint)) 
			{
				transform.position = intersectionPoint + new Vector3(0f, fromNode.WorldPos.y + (altitude + fromNode.groundHeight), 0f);
			} 
			else 
			{
				transform.position = fromPoint;
			}


			covPct = 0f;
			covPctInc = 1f / ((float)remainingIncrements);
			isTraversingArcLeftToRight = System.Object.ReferenceEquals (toNode, currArc.RightNode);
			if (this.animateTurns) 
			{
				this.fwdDestination = Quaternion.LookRotation(toPoint - fromPoint);
				rotPct = 0f;
			} 
			else 
			{
				FaceTowards(toPoint);
			}
		}

		protected void RandomSpeed() {

			speed = (( UnityEngine.Random.value * (speedMax-speedMin )) + speedMin );

			if (motionStyle == MotionStyle.Incremental) {
				speed *= 15;
			}
		}

		protected void InitDriving() {

			RandomSpeed();

			bounceSpeed = speed * 100f;

			pauseUntilTime = DateTime.MinValue;

			stopTimeSecs =  (int)UnityEngine.Random.value * 7 + 5;
			nextPauseTime = DateTime.UtcNow.AddSeconds(UnityEngine.Random.value * (maxWaitSecs-minWaitSecs) + minWaitSecs );

			transform.position = fromPoint;
			//FaceTowards(toPoint);

			//AnimatorPlay(ANIM_STATE_NAME_DRIVE);

		}


		protected Node ChooseNextRandomNode() 
		{
			if (toNode.network.NetworkUnloaded)
				NetworkUnloadEvent ();
			if (toNode == null) {return null;}
			if (toNode.referencingArcs == null) {return null;}

			List<Arc> potentialArcs = new List<Arc>();
			List<Arc> arcsToCheck = toNode.AllArcsFromXYZ;

			foreach (Arc arc in arcsToCheck) {

				//skip this road if not of specified road type (FeatureKind)..
				if (TraversableRoadTypes != null && TraversableRoadTypes.Length > 0 && arc.RoadInfo != null) 
				{
					MantleTransportNetwork.RoadFeatureKind roadType = 
						MiscTools.StringToEnum<MantleTransportNetwork.RoadFeatureKind>(arc.RoadInfo.FeatureKind);

					if ( !MiscTools.ArrayContains<MantleTransportNetwork.RoadFeatureKind> (TraversableRoadTypes, roadType)) 
						continue;
				}

				//TransportNetwork.Node next = arc.GetSiblingNodeOf(toNode);
				if (arc != currArc) {potentialArcs.Add(arc);}
			}

			if (potentialArcs.Count == 0) 
				return fromNode;

			if (potentialArcs.Count == 1) 
			{
				currArc = potentialArcs [0];
			} 
			else 
			{
				int offset = UnityEngine.Random.Range (0, potentialArcs.Count);
				currArc = potentialArcs [offset];
			}

			DirectedGeoGraph3D toNodeNet = toNode.network;
			if (currentNetwork == null)
			{
				currentNetwork = toNodeNet;
				currentNetwork.NetworkUnloadE += this.NetworkUnloadEvent;
			}
			else if (currentNetwork != toNodeNet)
			{
				currentNetwork.NetworkUnloadE -= this.NetworkUnloadEvent;
				currentNetwork = toNodeNet;
				currentNetwork.NetworkUnloadE += this.NetworkUnloadEvent;
			}

			return currArc.GetSiblingNodeOf(toNode);
		}

		private void NetworkUnloadEvent()
		{
			currentNetwork.NetworkUnloadE -= this.NetworkUnloadEvent;
			TransSimManager.Instance.PoolVehicle (this);
		}

		protected bool isAtDest() {
			return (covPct >= 1f &&  (rotPct > 1f || !animateTurns));
		}

		protected virtual void DoDefaultMotion() 
		{
			if (DateTime.UtcNow < pauseUntilTime) {
				return;
			} else if (pauseUntilTime != DateTime.MinValue) {
				RandomSpeed();
				//AnimatorPlay(ANIM_STATE_NAME_DRIVE);
				pauseUntilTime = DateTime.MinValue;
			}

			//check ahead;
			if (isAtDest()) 
			{

				Node nextNode = ChooseNextRandomNode();
				if (nextNode != null) {
					fromNode = toNode;
					toNode = nextNode;
				} else {
					Node prevToNode = toNode;
					toNode = fromNode;
					fromNode = prevToNode; 
				}


				RefreshWaypoints();
			} 

			if (rotPct < 1f) 
			{
				RotateTowardsTarget();
			}

			if (!isBlocked)
			{
				if (usingTerrainHeight)
					TerrainIncrementForward ();
				else if (motionStyle == MotionStyle.Incremental)
					IncrementForward ();
				else if (motionStyle == MotionStyle.Lerp)
					LerpForward ();
			}
		}

		protected int remainingIncrements = -1;
		protected Vector3 momentum;
		protected bool isTraversingArcLeftToRight;
		protected float covPctInc;

		protected void IncrementForward() {

			//float progress;
			if (remainingIncrements-- > 0) 
			{
				covPct += covPctInc;
				transform.position += momentum;
				transform.position = new Vector3 (transform.position.x, 
					currArc.GetHeightAtPlaceOnArc (isTraversingArcLeftToRight ? covPct : (1f - covPct)),
					transform.position.z);
			} 
			else 
			{
				covPct = 1f;
			}
		}

		Vector3 currentTriangleNormal = Vector3.up;
		Vector3 currentTriangleForward = Vector3.forward;
		protected void TerrainIncrementForward()
		{
			if (remainingIncrements-- > 0) 
			{
				covPct += covPctInc;
				//Debug.DrawLine(newPos, newPos + Vector3.down * 5f, Color.blue);
				Vector3 newPos = transform.position + momentum;//new Vector3 (transform.position.x, transform.position.y, transform.position.z);
				float y = currArc.SampleTriangle (new Vector2 (newPos.x, newPos.z), 
					     	ref currentTriangleNormal, ref currentTriangleForward, isTraversingArcLeftToRight);
				newPos = new Vector3 (newPos.x, y, newPos.z);
				transform.LookAt (transform.position + currentTriangleForward, currentTriangleNormal);
				transform.position = newPos;
			} 
			else 
			{
				covPct = 1f;
			}
		}

		protected void LerpForward() {

			float progress;

			if (covPct < 1f) {
				covPct += speed * Time.smoothDeltaTime; 

				//..if we're not approaching a straight, slow down..
				if (toNode.AllArcsFromXYZ.Count != 2) {
					progress = Mathf.Sin(Mathf.Lerp(MiscTools.SIN_START, MiscTools.SIN_END, covPct));
				} else {
					progress = covPct;
				}

				trans = Vector3.Lerp(fromPoint, toPoint, progress);
				transform.position = trans;	
			}

		}

		protected void RotateTowardsTarget() {

			//..if not fully facing forward then increment rotate..


			//..if already a long way on the road force faster alignment with tragectory..
			float distanceFromToNode = (trans-fromPoint).magnitude;
			rotPct += turnSpeed * (distanceFromToNode) * Time.smoothDeltaTime;

			transform.rotation = Quaternion.Lerp(transform.rotation, fwdDestination,rotPct);


		}

		public void TurnAround() {

			Node origTo = toNode;
			toNode = fromNode;
			fromNode = origTo;

			RefreshWaypoints();
			if (!animateTurns) {
				FaceTowards(toPoint);
			}
			covPct = 1f-covPct;

		}

		public void DoPause(float minSecs, float maxSecs) {
			stopTimeSecs =  (int)UnityEngine.Random.value * (maxSecs-minSecs) + minSecs;
			//AnimatorPlay(ANIM_STATE_NAME_IDLE);
			pauseUntilTime = DateTime.UtcNow.AddSeconds(stopTimeSecs);

		}

		//returns the length in seconds of the stateName animation..
		public virtual float AnimatorPlay(string stateName = "") {

			//Animator animator = gameObject.GetComponent<Animator>();
			if (animator != null) 
			{
				//Debug.Log("Citizen.AnimatorPlay(): Playing animation state '"+stateName+"'!");
				if (stateName == "") {stateName = ANIM_STATE_NAME_IDLE;}
				//animator.CrossFade(stateName,0.5f);
				animator.speed = 1f;
				animator.Play(stateName);
				if (animator.GetComponent<Animation>() == null || animator.GetComponent<Animation>()[stateName] == null) {return 0;}
				return animator.GetComponent<Animation>()[stateName].length;
			} 
			else 
			{
				//Debug.Log("Warning: AnimatorPlay(): Failed to play animation state '"+stateName+"'!");
				return 0f;
			}

		}

		public virtual bool AnimatorStop() {
			//Animator animator = gameObject.GetComponent<Animator>();
			if (animator != null) {
				animator.speed = 0f;
				return true;
			} else {
				return false;
			}
		}

		public virtual float GetAnimatorSpeed() {
			Animator animator = gameObject.GetComponent<Animator>();
			if (animator != null) {
				return animator.speed;

			} else {
				return -1f;
			}
		}

		public void FaceTowards(Vector3 position) {

			//Vector3 facePoint = new Vector3 (position.x, transform.position.y, position.z);
			transform.LookAt (position);//facePoint);
			rotPct = 1f;
			//Debug.Log ("FaceTowards " + facePoint);
		}

	}

}

