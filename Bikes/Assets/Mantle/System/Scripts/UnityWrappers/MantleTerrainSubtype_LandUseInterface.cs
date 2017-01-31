using UnityEngine;
using System.Collections;


namespace MantleEngine.PluginComponents 
{
	[System.Serializable]
	public class MantleTerrainSubtype_LandUseInterface: MantleTerrainSubtypeInterface {

		public override MantleTerrainSubtype Instantiate() {

			_script = new MantleTerrainSubtype_LandUse();
			SetVariables();
			return _script;
		}

		public override MantleTerrainSubtypeInterface ShallowCopy ()
		{
			MantleTerrainSubtype_LandUseInterface mtsi = new MantleTerrainSubtype_LandUseInterface();
			ShallowCopyInto (mtsi);
			return mtsi;
		}

	}
}