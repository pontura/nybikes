using UnityEngine;
using System.Collections;
using MantleEngine.PluginComponents;
using MantleEngine.Mathematics;
using MantleEngine.PluginUtilities;
using System.Collections.Generic;

namespace MantleEngine.Runtime 
{
	
	public class CharacterHeldItem :MonoBehaviour {
		
		public Vector3 offsetFromHand = Vector3.forward;
		public Vector3 rotationFromHand = Vector3.zero;


		/// <summary>
		/// The collection sound. One sound is randomly selected and played on collection.
		/// </summary>
		public AudioClip[] soundOnPlacement = null;

		/// <summary>
		/// The collection objects. All gameObjects in this array are instantiated on collection.  This could include particle effects and children.
		/// </summary>
		public GameObject[] FXOnPlacement = null;

		public MantleTerrainType.TerrainTypeCode[] validItemPlacementTerrain = new MantleTerrainType.TerrainTypeCode[] {MantleTerrainType.TerrainTypeCode.earth, MantleTerrainType.TerrainTypeCode.landuse};

		public bool animateOnPlaced = true;
		public bool isRecoverable = false;


		protected List<Collider> allColliders ;
		protected int countPlacedTimes = 0;
		protected MantlePlayerInteractions playerInteractions = null;
		protected GameObject playersHand = null;
		protected Animator anim = null;


		public static int totalPlacedCount = 0;

		private Quaternion _origRotation = default(Quaternion);

		void Start() {


			playerInteractions = MantleRuntimeManager.Instance.playerInteractions;

			_origRotation = transform.rotation;

			anim = GetComponent<Animator>();
			if (anim != null) anim.enabled = !animateOnPlaced;


			playersHand = MantleRuntimeManager.Instance.runtimePlayer.playerHandGameObject;
			if (playersHand == null) {
				Debug.Log("playersHand not found under " + MantleRuntimeManager.Instance.runtimePlayer.gameObject);
				playersHand = MantleRuntimeManager.Instance.runtimePlayer.gameObject;
			}

			transform.SetParent(playersHand.transform);
			transform.localPosition = offsetFromHand;
			transform.localRotation = Quaternion.Euler(rotationFromHand);



			//start with non-trigger colliders off and trigger collider on
			allColliders = new List<Collider>(this.transform.GetComponentsInChildren<Collider>());

			OnlyEnableTriggerColliders(true);

		}

		public void OnlyEnableTriggerColliders(bool onlyEnableTrigger = true) {
			for (int i = 0; i < allColliders.Count; i++) {
				Collider collider = allColliders [i];
				collider.enabled = (onlyEnableTrigger && collider.isTrigger) || !onlyEnableTrigger;
			}
		}

		void Update () {
			
			if (Input.GetMouseButtonDown (0)) {
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				RaycastHit hit;
				if (Physics.Raycast(ray, out hit)) {
					

					if (hit.collider.transform == this.transform) {
						if (isRecoverable || (!isRecoverable && countPlacedTimes == 0)) {
							DoPlacement(playerInteractions);
						}
					}
				}
			}
		}



		public void DoPlacement(MantlePlayerInteractions placer,  bool destroyThis = false) {

			int validTerrainLayerMask = Mantle.Instance.ConstructMantleLayerMask(validItemPlacementTerrain);
			Vector3 placementPos = Geometry.GetBestValidPositionFromTarget(this.transform.position, validTerrainLayerMask);
			this.transform.parent = null;
			this.transform.rotation = _origRotation;
			this.transform.position= placementPos;

			if (soundOnPlacement != null && soundOnPlacement.Length > 0) {
				int offset = SimpleRNG.Instance.Range(0, soundOnPlacement.Length-1);
				AudioClip clip = soundOnPlacement[offset];
				placer.PlayAudioClip(clip);
			}

			if (FXOnPlacement != null) {
				for (int i = 0; i < FXOnPlacement.Length; i++) {
					GameObject obj = GameObject.Instantiate(FXOnPlacement[i],placementPos, FXOnPlacement[i].transform.rotation) as GameObject;
					ParticleSystem ps = obj.transform.GetComponentInChildren<ParticleSystem>();
					if (ps != null) {
						GameObject.Destroy(obj, ps.duration + 0.1f);
					}
				}
			}



			if (anim != null) anim.enabled = animateOnPlaced;

			countPlacedTimes ++;
			totalPlacedCount ++;

			Mantle.Instance.PrintMessage("Item Placed: " + gameObject.name );

			if (!destroyThis) {
				OnlyEnableTriggerColliders(false);
			} else {
				GameObject.Destroy(this.gameObject);
			}

			
		}

	}

}
