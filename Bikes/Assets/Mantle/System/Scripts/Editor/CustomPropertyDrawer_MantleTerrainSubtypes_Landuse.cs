using UnityEngine;
using UnityEditor;

using System.Collections;

namespace MantleEngine.PluginComponents 
{


	[CustomPropertyDrawer (typeof(MantleTerrainSubtype_LandUseInterface))]
	public class MantleEditor_MantleTerrainSubtype_LandUse : MantleEditor_MantleTerrainSubtype {


		public override string[] GetPopupContents() {
			return LoadCommonTypes("TerrainTypesLanduseList.txt");
		}

		public override string GetPopupValueAtIndex(int index) {
			return GetPopupContents()[index];
		}

	}





}


