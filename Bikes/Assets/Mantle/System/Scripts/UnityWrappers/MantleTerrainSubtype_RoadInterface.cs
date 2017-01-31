using UnityEngine;
using System.Collections;


namespace MantleEngine.PluginComponents 
{
	[System.Serializable]
	public class MantleTerrainSubtype_RoadInterface: MantleTerrainSubtypeInterface {


		public float roadWidth = 1f;


		public override MantleTerrainSubtype Instantiate() {

			_script = new MantleTerrainSubtype_Road();
			SetVariables();
			return _script;
		}


		protected override void SetVariables() {
			
			base.SetVariables();
			MantleTerrainSubtype_Road _scriptOverride = (MantleTerrainSubtype_Road)_script;
			if (roadWidth < 0.01f) {roadWidth = 1f;}
			_scriptOverride.roadWidth = roadWidth;
		}

		public override MantleTerrainSubtypeInterface ShallowCopy ()
		{
			MantleTerrainSubtype_RoadInterface mtsi = new MantleTerrainSubtype_RoadInterface();
			ShallowCopyInto(mtsi);
			mtsi.roadWidth = roadWidth;
			return mtsi;
		}

	}
}