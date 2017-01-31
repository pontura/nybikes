using UnityEngine;
using UnityEditor;

using System.Collections;

namespace MantleEngine.PluginComponents 
{


	[CustomPropertyDrawer (typeof(MantleTerrainSubtype_BuildingInterface))]
	public class MantleEditor_MantleTerrainSubtype_Building : MantleEditor_MantleTerrainSubtype {


		public override string[] GetPopupContents() {
			return LoadCommonTypes("TerrainTypesBuildingsList.txt");
		}

		public override string GetPopupValueAtIndex(int index) {
			return GetPopupContents()[index];
		}

		protected override MantleStyleInterface GetDefaultStyleInterface() {
			return MantleStyle_BuildingsInterface.GetSystemDefault();
		}

	}




}


