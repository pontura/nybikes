using UnityEngine;
using System.Collections;

using MantleEngine.Graphics;

namespace MantleEngine.PluginComponents 
{

	[System.Serializable]
	public class MantleStyle_BuildingsInterface: MantleStyleInterface {

		protected const float MIN_BUILDINGS_DEFAULT_SIDE_HEIGHT = 3f;
		protected const float MAX_BUILDINGS_DEFAULT_SIDE_HEIGHT = 12f;

		[Header("Building Specific Settings")]
		public bool ignoreRealBuildingHeights = false;

		[Header("Building Cladding")]
		public float groundLevelHeight = 3.5f;
		public float topLevelHeight = 2f;

		public MantleTerrainCladdingAsset[] GroundLevelCladding;
		public MantleTerrainCladdingAsset[] MidSectionCladding;
		public MantleTerrainCladdingAsset[] TopLevelCladding;

		//public MantleTerrainEdgeAsset[] TerrainEdge ;


		public override MantleStyleInterface ShallowCopy ()
		{
			MantleStyle_BuildingsInterface msi = new MantleStyle_BuildingsInterface ();
			ShallowCopyInto (msi);
			msi.ignoreRealBuildingHeights = ignoreRealBuildingHeights;
			msi.groundLevelHeight = groundLevelHeight;
			msi.topLevelHeight = topLevelHeight;
			msi.GroundLevelCladding = GroundLevelCladding;
			msi.MidSectionCladding = MidSectionCladding;
			msi.TopLevelCladding = TopLevelCladding;
			return msi;
		}

		public override MantleStyle Instantiate() {

			_script = new MantleStyle_Buildings();
			SetVariables();
			return _script;
		}

		public override void LoadDefaults() {
			minSideHeight = MIN_BUILDINGS_DEFAULT_SIDE_HEIGHT;
			maxSideHeight = MAX_BUILDINGS_DEFAULT_SIDE_HEIGHT;
		}


		protected override void SetVariables() {

			base.SetVariables();

			MantleStyle_Buildings _scriptOverride = (MantleStyle_Buildings)_script;

			_scriptOverride.ignoreRealBuildingHeights = ignoreRealBuildingHeights;
			_scriptOverride.groundLevelHeight = groundLevelHeight;
			_scriptOverride.topLevelHeight = groundLevelHeight;

			_scriptOverride.GroundLevelCladding = GroundLevelCladding;
			_scriptOverride.MidSectionCladding = MidSectionCladding;
			_scriptOverride.TopLevelCladding = TopLevelCladding;

		}

		public override void CopyFrom(MantleStyleInterface fromStyle) {

			MantleStyle_BuildingsInterface fromBuildingStyle = (MantleStyle_BuildingsInterface)fromStyle;

			base.CopyFrom(fromStyle);

			ignoreRealBuildingHeights = fromBuildingStyle.ignoreRealBuildingHeights;
			groundLevelHeight = fromBuildingStyle.groundLevelHeight;
			topLevelHeight = fromBuildingStyle.groundLevelHeight;

			GroundLevelCladding = fromBuildingStyle.GroundLevelCladding;
			MidSectionCladding = fromBuildingStyle.MidSectionCladding;
			TopLevelCladding = fromBuildingStyle.TopLevelCladding;


		}

		protected static MantleStyle_BuildingsInterface _systemDefaultBuilding = null;

		public new static MantleStyle_BuildingsInterface GetSystemDefault() {

			if (_systemDefaultBuilding == null) {
				ScriptableObject obj = Resources.Load(Mantle.MANTLE_RESOURCE_DEFAULT_STYLE_BUILDING_NAME) as ScriptableObject;

				if (obj == null) {
					Mantle.Instance.PrintMessage("Missing resource file '"+Mantle.MANTLE_RESOURCE_DEFAULT_STYLE_NAME+"'!", ConsoleMessageType.Error);
					return null;
				}
				_systemDefaultBuilding  = (MantleStyle_BuildingsInterface)obj;
			}

			return _systemDefaultBuilding;


		}


	}

}