using UnityEngine;
using System.Collections;

namespace MantleEngine.PluginComponents 
{

	[System.Serializable]
	public class MantleTerrainSubtype_BuildingInterface: MantleTerrainSubtypeInterface {


		public override MantleTerrainSubtype Instantiate() {

			_script = new MantleTerrainSubtype_Building();
			SetVariables();
			return _script;
		}

		public override MantleTerrainSubtypeInterface ShallowCopy ()
		{
			MantleTerrainSubtype_BuildingInterface mtsi = new MantleTerrainSubtype_BuildingInterface();
			ShallowCopyInto(mtsi);
			return mtsi;
		}

	}
}

