using UnityEngine;
using System.Collections;


namespace MantleEngine.PluginComponents 
{

	[System.Serializable] 
	[SelectionBase]
	public class MantleThemeInterface : ScriptableObject {

		public string ThemeName = "NewMantleTheme";

		public bool IncludeTerrainFill = true;
		public bool IncludeTerrainEdge = true;
		public bool IncludeBuildingCladding = true;

		public MantleTerrainSettings_Earth EarthTerrain;
		public MantleTerrainSubtype_EarthInterface[] EarthToRender;

		public MantleTerrainSettings_LandUse LanduseTerrain;
		public MantleTerrainSubtype_LandUseInterface[] LandUseToRender;

		public MantleTerrainSettings_Water WaterTerrain;
		public MantleTerrainSubtype_WaterInterface[] WaterToRender;

		public MantleTerrainSettings_Building BuildingTerrain;
		public MantleTerrainSubtype_BuildingInterface[] BuildingsToRender;

		public MantleTerrainSettings_Road RoadTerrain;
		public MantleTerrainSubtype_RoadInterface[] TransportToRender;

		//public MantleStyleInterface DefaultStyle;




		protected MantleTheme _script;

		public  MantleTheme Instantiate() {
			_script = new MantleTheme();
			SetVariables();
			_script.LoadSubtypes();

			return _script;
		}

		/*
		public  void LoadDefaults() {

			MantleTerrainSubtypeInterface defaultSubtype = MantleStyleInterface.GetSystemDefaultStyleInterface();


			EarthToRender = new MantleTerrainSubtype[]{defaultStyle};

			LandUseToRender = new MantleTerrainSubtype[]{defaultStyle};
			EarthToRender = new MantleTerrainSubtype[]{defaultStyle};
			EarthToRender = new MantleTerrainSubtype[]{defaultStyle};
			EarthToRender = new MantleTerrainSubtype[]{defaultStyle};
				
		}
		*/


		protected  void SetVariables() {

			_script.Name = ThemeName;
			_script.IncludeTerrainFill = IncludeTerrainFill;
			_script.IncludeTerrainEdge = IncludeTerrainEdge;
			_script.IncludeBuildingCladding = IncludeBuildingCladding;
			//_script.DefaultStyle = DefaultStyle.Instantiate();

			_script.EarthTerrain = EarthTerrain;
			_script.EarthToRender = new MantleTerrainSubtype_Earth[EarthToRender.Length];
			for (int i = 0; i < EarthToRender.Length; i++) _script.EarthToRender[i] = (MantleTerrainSubtype_Earth)(EarthToRender[i].Instantiate());
			
			_script.LanduseTerrain = LanduseTerrain;
			_script.LandUseToRender = new MantleTerrainSubtype_LandUse[LandUseToRender.Length];
			for (int i = 0; i < LandUseToRender.Length; i++) _script.LandUseToRender[i] = (MantleTerrainSubtype_LandUse)LandUseToRender[i].Instantiate();

			_script.WaterTerrain = WaterTerrain;
			_script.WaterToRender = new MantleTerrainSubtype_Water[WaterToRender.Length];
			for (int i = 0; i < WaterToRender.Length; i++) _script.WaterToRender[i] = (MantleTerrainSubtype_Water)WaterToRender[i].Instantiate();

			_script.BuildingTerrain = BuildingTerrain;
			_script.BuildingsToRender = new MantleTerrainSubtype_Building[BuildingsToRender.Length];
			for (int i = 0; i < BuildingsToRender.Length; i++) _script.BuildingsToRender[i] = (MantleTerrainSubtype_Building)BuildingsToRender[i].Instantiate();


			_script.RoadTerrain = RoadTerrain;
			_script.TransportToRender = new MantleTerrainSubtype_Road[TransportToRender.Length];
			for (int i = 0; i < TransportToRender.Length; i++) _script.TransportToRender[i] = (MantleTerrainSubtype_Road)TransportToRender[i].Instantiate();

		}


		public static void DeepCopy(MantleThemeInterface toTheme, MantleThemeInterface fromTheme) {
			
			toTheme.ThemeName = fromTheme.ThemeName;

			toTheme.IncludeTerrainFill = fromTheme.IncludeTerrainFill;
			toTheme.IncludeTerrainEdge = fromTheme.IncludeTerrainEdge;
			//toTheme.DefaultStyle = fromTheme.DefaultStyle;

			toTheme.EarthTerrain = fromTheme.EarthTerrain;
			toTheme.EarthToRender = new MantleTerrainSubtype_EarthInterface[fromTheme.EarthToRender.Length];
			for (int i = 0; i < fromTheme.EarthToRender.Length; i++) toTheme.EarthToRender[i] = fromTheme.EarthToRender[i];

			toTheme.LanduseTerrain = fromTheme.LanduseTerrain;
			toTheme.LandUseToRender = new MantleTerrainSubtype_LandUseInterface[fromTheme.LandUseToRender.Length];
			for (int i = 0; i < fromTheme.LandUseToRender.Length; i++) toTheme.LandUseToRender[i] = fromTheme.LandUseToRender[i];

			toTheme.WaterTerrain = fromTheme.WaterTerrain;
			toTheme.WaterToRender = new MantleTerrainSubtype_WaterInterface[fromTheme.WaterToRender.Length];
			for (int i = 0; i < fromTheme.WaterToRender.Length; i++) toTheme.WaterToRender[i] = fromTheme.WaterToRender[i];

			toTheme.BuildingTerrain = fromTheme.BuildingTerrain;
			toTheme.BuildingsToRender = new MantleTerrainSubtype_BuildingInterface[fromTheme.BuildingsToRender.Length];
			for (int i = 0; i < fromTheme.BuildingsToRender.Length; i++) toTheme.BuildingsToRender[i] = fromTheme.BuildingsToRender[i];

			toTheme.RoadTerrain = fromTheme.RoadTerrain;
			toTheme.TransportToRender = new MantleTerrainSubtype_RoadInterface[fromTheme.TransportToRender.Length];
			for (int i = 0; i < fromTheme.TransportToRender.Length; i++) toTheme.TransportToRender[i] = fromTheme.TransportToRender[i];

		}

	}

}
