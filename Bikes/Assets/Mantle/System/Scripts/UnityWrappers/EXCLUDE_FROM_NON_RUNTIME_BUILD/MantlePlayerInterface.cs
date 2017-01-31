
using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using MantleEngine.Mathematics;

using MantleEngine.Transport;
using MantleEngine.Utilities;

using MantleEngine.PluginUtilities;
using MantleEngine.PluginComponents;



namespace MantleEngine.Runtime {
	
	//[RequireComponent(typeof(MantlePlayerInteractions))]
	public class MantlePlayerInterface : RuntimeMantleBehaviour
	{
		public MantleTerrainType.TerrainTypeCode[] validPlayerPlacementTerrain = new MantleTerrainType.TerrainTypeCode[] {MantleTerrainType.TerrainTypeCode.earth, MantleTerrainType.TerrainTypeCode.landuse};
		public GameObject playerHandGameObject = null;

		public Vector3 direction = default(Vector3);
		public Vector3 movementInc = default(Vector3);

		private Vector3 _targetPos = default(Vector3);
		private Vector3 _prevPosition = default(Vector3);

		private MantlePlayer _script = null;




		public virtual MantlePlayer Instantiate() {

			_script = new MantlePlayer();
			SetVariables();
			_script.Init(this.gameObject);
			return _script;
		}

		protected virtual void SetVariables() {

			_script.validPlayerPlacementTerrain = validPlayerPlacementTerrain;
			_script.playerHandGameObject = playerHandGameObject;

		}

		void FixedUpdate() {
			_script.PumpFixedUpdate();

		}






	}
}

