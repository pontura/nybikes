using UnityEngine;
using UnityEditor;

using System.Collections;

namespace MantleEngine.PluginComponents 
{

	[CustomPropertyDrawer (typeof(MantleTerrainSubtype_WaterInterface))]
	public class MantleEditor_MantleTerrainSubtype_Water : MantleEditor_MantleTerrainSubtype {
		
		public override string[] GetPopupContents() {
			return LoadCommonTypes("TerrainTypesWaterList.txt");
		}

		public override string GetPopupValueAtIndex(int index) {
			return GetPopupContents()[index];
		}

	}





}


