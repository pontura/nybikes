using UnityEngine;
using System.Collections;


namespace MantleEngine.PluginComponents 
{
	[System.Serializable]
	public class MantleTerrainSubtype_EarthInterface : MantleTerrainSubtypeInterface {

		public override MantleTerrainSubtype Instantiate() {

			_script = new MantleTerrainSubtype_Earth();
			SetVariables();
			return _script;
		}

		public override MantleTerrainSubtypeInterface ShallowCopy ()
		{
			MantleTerrainSubtype_EarthInterface mtsi = new MantleTerrainSubtype_EarthInterface ();
			ShallowCopyInto (mtsi);
			return mtsi;
		}
	}
}