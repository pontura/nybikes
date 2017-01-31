
using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using MantleEngine.Mathematics;

using MantleEngine.Transport;
using MantleEngine.Rendering;
using MantleEngine.Utilities;
using MantleEngine.PluginUtilities;



namespace MantleEngine.PluginComponents 
{
	public class TransSimManager : MantleBehaviour
	{
		#region Singleton Impl
		private static volatile TransSimManager _instance;
		private static object _lock = new object();

		static TransSimManager() {}

		private TransSimManager() {}

		public static TransSimManager Instance
		{
			get
			{
				if (_instance == null)
				{
					lock(_lock)
					{
						if (_instance == null) 
						{
							_instance = GameObject.FindObjectOfType<TransSimManager>();
						}
					}
				}
				return _instance;
			}
		}

		#endregion



		public const string GAMEOBJECT_NAME_TRANSPORT_GROUND_PARENT = "Mantle_GroundTransport";

		public bool doSimulateVehicles = true;
		public int RandomSeed = 0;

		public VehicleMetaData[] groundVehiclesToPlace;

		//public GameObject[] basicCars;
		//public int numberOfConcurrentGroundVehicles = 300;

		public static SimpleRNG RNG = null;

		protected List<GroundTransport> groundTransportInstances = new List<GroundTransport>();

		protected GameObject transSimManager_GroundTransport = null;

		private Queue<GameObject> vehiclePool = new Queue<GameObject>();

		private int totalNumberOfVehiclesToPlace = 0;


		public override void Init(Mantle mantleParent) 
		{
			base.Init(mantleParent);
		
			RNG = new SimpleRNG (RandomSeed);
			//Mantle.Instance.ResetEvents();
			Mantle.Instance.onClearMantleDependantSceneObjectsE += OnMantleClearScene;
			Mantle.Instance.onMapRenderCompleteE += OnMantleRenderComplete;
			//Mantle.Instance.onWorldRecenteredE += OnWorldRecentered;

			for (int i = 0; i < groundVehiclesToPlace.Length; ++i)
				totalNumberOfVehiclesToPlace += groundVehiclesToPlace [i].numberOfInstances;
		}

		private void OnNewTileLoadComplete(MantleRenderedTile tile)
		{
			if (tile.transportNetwork == null || transSimManager_GroundTransport == null)
				return;

			int vehiclesToAttempt = vehiclePool.Count < 20 ? vehiclePool.Count : vehiclePool.Count / 2;
			while(vehiclesToAttempt > 0)
			{
				vehiclesToAttempt--;
				GameObject vehicleGO = vehiclePool.Dequeue ();
				Vehicle vehicle = vehicleGO.GetComponent<Vehicle> ();
				if (vehicle == null)
				{
					AssetPoolManager.Instance.Destroy (vehicleGO);
					continue;
				}

				RouletteWheel<string> wheel = tile.transportNetwork.CreateRoadKindRouletteWheel( 
					vehicle.TraversableRoadTypes);
				if (wheel == null) 
				{
					vehiclePool.Enqueue (vehicleGO);
					continue;
				}

				Arc road = tile.transportNetwork.GetWeightedRandomRoadArc (wheel);
				if (road == null) 
				{
					vehiclePool.Enqueue (vehicleGO);
					continue;
				} //..don't place a vehicle if there are no suporting valid road types..

				vehicleGO.SetActive (true);
				vehicle.Init (road, road.LeftNode, road.RightNode, vehicle.TraversableRoadTypes);
			}
		}

		public void PoolVehicle(Vehicle v)
		{
			if (v == null) return;

			v.gameObject.SetActive (false);
			vehiclePool.Enqueue (v.gameObject);
		}

		void OnMantleRenderComplete() 
		{
			if (TransSimManager.Instance != null && TransSimManager.Instance.doSimulateVehicles) 
			{
				NotificationManager.Instance.TileRendererdE += OnNewTileLoadComplete;

				ClearGameObjectsGroundTransport();
				int totalTiles = MantleRenderedTile.LoadedMantleTiles.Count;
				int thisTile = 0;
				foreach (MantleRenderedTile mt in MantleRenderedTile.LoadedMantleTiles.Values) 
				{
					if ( mt.transportNetwork != null) 
					{
						TransSimManager.Instance.PopulateGroundTransport( mt, totalTiles, thisTile);
						thisTile++;
					}
				}
			}
		}

		void OnMantleClearScene() {
			ClearAll();
		}

		public void NotifyOutOfBounds(Vehicle v) {

			return;

			/*
			if (v is GroundTransport) {
				GroundTransport c = v as GroundTransport;
				groundTransportInstances.Remove(c);
				Mantle.Instance.DestroyObjectImmediate(v.gameObject);
			}
			*/

		}

		public void ClearAll() {
			ClearGameObjectsGroundTransport();
			groundTransportInstances =  new List<GroundTransport>();;
		}

		protected void ClearGameObjectsGroundTransport() {

			if (transSimManager_GroundTransport == null) {
				transSimManager_GroundTransport = GameObject.Find (GAMEOBJECT_NAME_TRANSPORT_GROUND_PARENT);
			}

			if (transSimManager_GroundTransport != null) {
				Mantle.Instance.DestroyObjectImmediate(transSimManager_GroundTransport);

			}

			groundTransportInstances = new List<GroundTransport>();
		}

		protected void RefreshAllWaypoints() {
			Debug.LogWarning("Refreshing "+groundTransportInstances.Count+" waypoints");
			foreach (GroundTransport t in groundTransportInstances) {
				t.RefreshWaypoints();
			}
		}


		protected int PopulateGroundTransport( MantleRenderedTile tile, int totalTilesCount, int thisTileCount) 
		{
			MantleTransportNetwork transNetwork = tile.transportNetwork;

			if (transNetwork == null) {
				Debug.LogWarning("TransSimManager's transNetwork object is null. No vehicles will be placed.");
				return 0;
			}


			if (groundVehiclesToPlace == null || groundVehiclesToPlace.Length ==0 ) {
				Debug.LogWarning("TransSimManager requires at least one car prefab (on inspector) to populate the map with.");
				return 0;
			}

			transSimManager_GroundTransport = new GameObject(GAMEOBJECT_NAME_TRANSPORT_GROUND_PARENT);
			transSimManager_GroundTransport.transform.position = tile.transform.position;
			tile.parent_TransportNetwork = transSimManager_GroundTransport;
			//transSimManager_GroundTransport.transform.SetParent(tile.transform);

			GameObject parent_MantleWorld = GameObject.Find (Mantle.GAMEOBJECT_NAME_MANTLE_WORLD_PARENT);
			transSimManager_GroundTransport.transform.SetParent(parent_MantleWorld.transform);

			float maxVehiclesReal = (float)totalNumberOfVehiclesToPlace / (float)totalTilesCount;
			int maxVehicles = (int)maxVehiclesReal;
			float dps = maxVehiclesReal - (float)maxVehicles;
			if (SimpleRNG.Instance.Range(0f, 1f) <= dps) maxVehicles++;

			if (thisTileCount == totalTilesCount - 1)
				maxVehicles += totalNumberOfVehiclesToPlace % totalTilesCount;

			int vehiclesPlaced = 0;
			for (int vi = 0; vi < groundVehiclesToPlace.Length; vi++) 
			{
				RouletteWheel<string> wheel = transNetwork.CreateRoadKindRouletteWheel( groundVehiclesToPlace[vi].TraversableRoadTypes);
				if (wheel == null || groundVehiclesToPlace[vi].vehicles.Length == 0) {continue;}

				for (int i = 0; i < groundVehiclesToPlace[vi].numberOfInstances; i++) 
				{
					if (vehiclesPlaced >= maxVehicles)
						break;

					Arc road = null;
					bool foundValidArc = false;
					int maxSearchCountdown = 100;
					while (!foundValidArc && maxSearchCountdown > 0)
					{
						maxSearchCountdown--;
						road = transNetwork.GetWeightedRandomRoadArc (wheel);
						if (road.LeftNode.referencingArcs.Count + road.RightNode.referencingArcs.Count >= 3)
							foundValidArc = true;
					}

					if (road == null) {continue;} //..don't place a vehicle if there are no suporting valid road types..

					int ci = RNG.Range (0, groundVehiclesToPlace[vi].vehicles.Length - 1);
					GameObject currPrefab = groundVehiclesToPlace[vi].vehicles [ci];
					if (currPrefab == null) {
						Mantle.Instance.PrintMessage("The TransSimManager contains empty prefab slots." +
							" Please check and re-run.",ConsoleMessageType.Error);
						return 0;
					}

					GameObject goVehicle = (GameObject)GameObject.Instantiate (currPrefab, road.LeftNode.WorldPos,
						currPrefab.transform.rotation);
					goVehicle.transform.parent = transSimManager_GroundTransport.transform;
					GroundTransport car = goVehicle.GetComponent<GroundTransport> ();
					if (car == null) {
						car = goVehicle.AddComponent<GroundTransport> ();
					}
					//GroundTransport car = (GroundTransport)carInterface.Instantiate();
					car.Init (road, road.LeftNode, road.RightNode, groundVehiclesToPlace[vi].TraversableRoadTypes);

					groundTransportInstances.Add (car);
					vehiclesPlaced++;
					//Debug.Log ("TransSimManager created car: " + car.ToString()); 
				}

			}

			return vehiclesPlaced;

		}

	}
}

