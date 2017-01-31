using UnityEngine;
using System.Collections;


namespace MantleEngine.PluginComponents 
{
	[System.Serializable]
	public class MantleTerrainSubtype_WaterInterface: MantleTerrainSubtypeInterface {


		public override MantleTerrainSubtype Instantiate() {

			_script = new MantleTerrainSubtype_Water();
			SetVariables();
			return _script;
		}

		public override MantleTerrainSubtypeInterface ShallowCopy ()
		{
			MantleTerrainSubtype_WaterInterface mtsi = new MantleTerrainSubtype_WaterInterface ();
			ShallowCopyInto (mtsi);
			return mtsi;
		}

	}
}