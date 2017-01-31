using UnityEngine;
using UnityEditor;

using System.Collections;

namespace MantleEngine.PluginComponents 
{


	[CustomPropertyDrawer (typeof(MantleTerrainSubtype_EarthInterface))]
	public class MantleEditor_MantleTerrainSubtype_Earth : MantleEditor_MantleTerrainSubtype {


		public override string[] GetPopupContents() {
			return LoadCommonTypes("TerrainTypesEarthList.txt");
		}

		public override string GetPopupValueAtIndex(int index) {
			return GetPopupContents()[index];
		}

	}





}


