using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using MantleEngine.PluginUtilities;
using MantleEngine.Mathematics;
using MantleEngine.Graphics;

using System.IO;
using MantleEngine.MapServices;
using MantleEngine.Utilities;



namespace MantleEngine.Runtime
{

	[System.Serializable]
	public class MantleRuntimeManagerInterface: MonoBehaviour {
		
		public GameObject playerPrefab;
		public bool enableTilePrioritisation = true;
		public MantleLocationServices.MonitoringFrequency locationMonitoringFrequency = MantleLocationServices.MonitoringFrequency.OnceAtStart;
		public bool hideMovementControl = false;
		public GameObject gpsLocationPrefab = null;
		public bool hideGpsLocationPrefabOnceReached = true;


		protected MantleRuntimeManager _script = null;

		public void OnStartRuntime() {
			Instantiate();
			_script.OnStartRuntime();
		}

		public virtual MantleRuntimeManager Instantiate() {

			_script = MantleRuntimeManager.Instance;
			SetVariables();
			return _script;
		}


		protected virtual void SetVariables() {

			_script.playerPrefab = playerPrefab;

			_script.enableTilePrioritisation = enableTilePrioritisation;
			_script.locationMonitoringFrequency = locationMonitoringFrequency;
			_script.hideMovementControl = hideMovementControl;
			_script.gpsLocationPrefab = gpsLocationPrefab;
			_script.hideGpsLocationPrefabOnceReached = hideGpsLocationPrefabOnceReached;

			GameObject runtimePlayerGO = GameObject.Instantiate(playerPrefab, Vector3.up * 100000f, playerPrefab.transform.rotation) as GameObject;
			MantlePlayerInterface mpi = runtimePlayerGO.GetComponent<MantlePlayerInterface>();
			if (mpi == null) mpi = runtimePlayerGO.AddComponent<MantlePlayerInterface>();
			_script.SetRuntimePlayer( mpi.Instantiate());



		}

		void FixedUpdate()
		{
			_script.PumpFixedUpdate();
		}

//		void Update()
//		{
//			_script.PumpUpdate();
//		}

		void OnApplicationQuit() {
			NotificationManager.Instance.NotifySystemQuitting();
		}




	}

}