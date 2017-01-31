using UnityEngine;
using System.Collections;

using MantleEngine.Graphics;
using System.Collections.Generic;

namespace MantleEngine.PluginComponents 
{

	[System.Serializable]
	public class MantleStyle_TransNetworkInterface: MantleStyleInterface {

		/*
		[Header("Cladding Settings")]
		public float groundLevelHeight = 3.5f;
		public float topLevelHeight = 2f;

		public MantleTerrainCladdingAsset[] GroundLevelCladding;
		public MantleTerrainCladdingAsset[] MidSectionCladding;
		public MantleTerrainCladdingAsset[] TopLevelCladding;
		*/

		//public MantleTerrainEdgeAsset[] TerrainEdge ;
		//[Header("Intersections")]
		public MantleMaterial[] IntersectionMaterial;
		public MantleMaterial[] BridgeMaterial;

		[Header("Transport Network Settings")]
		public bool ignoreTunnels = true;
		public bool ignoreBridges = false;
		public float BridgeRampLength = 10f;

		public MantleTerrainEdgeAsset_TransNetwork[] TransportEdging ;


		public override MantleStyleInterface ShallowCopy ()
		{
			MantleStyle_TransNetworkInterface msi = new MantleStyle_TransNetworkInterface ();
			ShallowCopyInto (msi);
			msi.IntersectionMaterial = IntersectionMaterial;
			msi.BridgeMaterial = BridgeMaterial;
			msi.ignoreTunnels = ignoreTunnels;
			msi.ignoreBridges = ignoreBridges;
			msi.BridgeRampLength = BridgeRampLength;
			return msi;
		}

		public override MantleStyle Instantiate() {

			_script = new MantleStyle_TransNetwork();
			SetVariables();
			return _script;
		}


		protected override void SetVariables() {

			base.SetVariables();

			MantleStyle_TransNetwork _scriptOverride = (MantleStyle_TransNetwork)_script;

			_scriptOverride.IgnoreBridges = ignoreBridges;
			_scriptOverride.IgnoreTunnels = ignoreTunnels;
			_scriptOverride.TransportEdging = TransportEdging;
			_scriptOverride.IntersectionMaterial = IntersectionMaterial;
			_scriptOverride.BridgeMaterial = BridgeMaterial;
			_scriptOverride.BridgeRampLength = BridgeRampLength;

			/*
			_scriptOverride.groundLevelHeight = groundLevelHeight;
			_scriptOverride.topLevelHeight = groundLevelHeight;

			_scriptOverride.GroundLevelCladding = GroundLevelCladding;
			_scriptOverride.MidSectionCladding = MidSectionCladding;
			_scriptOverride.TopLevelCladding = TopLevelCladding;
			*/

		}

		public override void CopyFrom(MantleStyleInterface fromStyle) {
			
			base.CopyFrom(fromStyle);

			//..TODO: uncomment when fromStyle becomes MantleStyle_TransNetworkInterface
			//ignoreBridges = fromStyle.ignoreBridges;
			//ignoreTunnels = fromStyle.ignoreTunnels;

			TransportEdging = new MantleTerrainEdgeAsset_TransNetwork[fromStyle.TerrainEdge.Length];

			for (int i = 0; i < fromStyle.TerrainEdge.Length; i++) {
				MantleTerrainEdgeAsset_TransNetwork elem = new MantleTerrainEdgeAsset_TransNetwork();
				elem.CopyFrom(fromStyle.TerrainEdge[i]);
				TransportEdging[i] = elem;
			}
		}


		protected static MantleStyle_TransNetworkInterface _systemDefaultTransNetwork = null;

		public new static MantleStyle_TransNetworkInterface GetSystemDefault() {

			if (_systemDefaultTransNetwork == null) {
				ScriptableObject obj = Resources.Load(Mantle.MANTLE_RESOURCE_DEFAULT_STYLE_TRANSNETWORK_NAME) as ScriptableObject;

				if (obj == null) {
					Mantle.Instance.PrintMessage("Missing resource file '"+Mantle.MANTLE_RESOURCE_DEFAULT_STYLE_NAME+"'!", ConsoleMessageType.Error);
					return null;
				}
				_systemDefaultTransNetwork  = (MantleStyle_TransNetworkInterface)obj;
			}

			return _systemDefaultTransNetwork;


		}


	}

}