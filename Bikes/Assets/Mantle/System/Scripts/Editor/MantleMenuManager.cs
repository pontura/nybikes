using UnityEngine;
using UnityEditor;
using MantleEngine.PluginComponents;
using System.IO;
using System.Collections.Generic;


public class MantleMenuManager : MonoBehaviour 
{

	//[MenuItem ("GameObject/3D Object/Mantle")]
	[MenuItem ("Tools/Mantle/Add Mantle GameObject")]
	static public void CreateMantleManager()
	{
		//Arrange
		GameObject gameObject = new GameObject("Mantle");
		gameObject.AddComponent<MantleInterface>();
		Selection.activeGameObject = gameObject;

	}

	private static T CopyStyleToLocation<T>(T msi, string location) where T : MantleStyleInterface
	{
		T msi_dup = (T)msi.ShallowCopy ();

		Directory.CreateDirectory (location);
		AssetDatabase.CreateAsset(msi_dup, location + msi.name + ".asset");
		AssetDatabase.SaveAssets();
		EditorUtility.FocusProjectWindow();
		return msi_dup;
	}

	private static void CopyStylesOfTypeForTheme<T>(MantleThemeInterface mti, 
		Dictionary<string, MantleStyleInterface> copiedStyles, ref T[] arrayToReplace, string location) 
		where T : MantleTerrainSubtypeInterface
	{
		T[] newArray = new T[arrayToReplace.Length];
		for (int j = 0, arrLength = arrayToReplace.Length; j < arrLength; j++)
		{
			T i = arrayToReplace [j];
			T i2 = (T)i.ShallowCopy ();

			if (i2.style != null)
			{
				MantleStyleInterface msi = null;
				if (!copiedStyles.TryGetValue (i2.style.name, out msi))
				{
					msi = CopyStyleToLocation (i2.style, location);
					copiedStyles.Add (i2.style.name, msi);
				}
				i2.style = msi;
			}

			newArray [j] = i2;
		}
		arrayToReplace = newArray;
	}

	private static void CopyAllStylesForTheme(MantleThemeInterface mti, string location)
	{
		Dictionary<string, MantleStyleInterface> copiedStyles = new Dictionary<string, MantleStyleInterface> ();

		CopyStylesOfTypeForTheme (mti, copiedStyles, ref mti.EarthToRender, location);
		CopyStylesOfTypeForTheme (mti, copiedStyles, ref mti.LandUseToRender, location);
		CopyStylesOfTypeForTheme (mti, copiedStyles, ref mti.WaterToRender, location);
		CopyStylesOfTypeForTheme (mti, copiedStyles, ref mti.BuildingsToRender, location);
		CopyStylesOfTypeForTheme (mti, copiedStyles, ref mti.TransportToRender, location);

		mti.EarthTerrain = (MantleTerrainSettings_Earth)mti.EarthTerrain.ShallowCopy ();
		mti.LanduseTerrain = (MantleTerrainSettings_LandUse)mti.LanduseTerrain.ShallowCopy ();
		mti.WaterTerrain = (MantleTerrainSettings_Water)mti.WaterTerrain.ShallowCopy ();
		mti.BuildingTerrain = (MantleTerrainSettings_Building)mti.BuildingTerrain.ShallowCopy ();
		mti.RoadTerrain = (MantleTerrainSettings_Road)mti.RoadTerrain.ShallowCopy ();
	}

	[MenuItem ("Tools/Mantle/Duplicate Theme")]
	private static void DuplicateTheme () 
	{
		MantleThemeInterface mti = (MantleThemeInterface)Selection.activeObject;
		if (mti == null)
			return;

		MantleThemeInterface mti_dup = ScriptableObject.CreateInstance<MantleThemeInterface>();
		MantleThemeInterface.DeepCopy (mti_dup, mti);
		mti_dup.ThemeName += "_Duplicate";

		string themeLocation = "Assets/" + Mantle.MANTLE_CONTENT_PATH + mti_dup.ThemeName + "/";
		Directory.CreateDirectory (themeLocation);
		AssetDatabase.CreateAsset(mti_dup, themeLocation + mti_dup.ThemeName + ".asset");
		AssetDatabase.SaveAssets();

		CopyAllStylesForTheme (mti_dup, themeLocation + Mantle.MANTLE_STYLES_SUB_PATH);

		EditorUtility.FocusProjectWindow();
		Selection.activeObject = mti_dup;
	}

	[MenuItem ("Tools/Mantle/Duplicate Theme", true)]
	private static bool DuplicateThemeValidation () 
	{
		if (Selection.activeObject == null)
			return false;
		return Selection.activeObject.GetType() == typeof(MantleThemeInterface);
	}

	/*
	[MenuItem("Tools/Mantle/Create/Theme")]
	static public MantleThemeInterface CreateMantleTheme() {
		MantleThemeInterface inst = ScriptableObject.CreateInstance<MantleThemeInterface>();
		Directory.CreateDirectory ("Assets/Mantle/Content/New Mantle Theme/");
		AssetDatabase.CreateAsset(inst, "Assets/Mantle/Content/New Mantle Theme/New Mantle Theme.asset");
		AssetDatabase.SaveAssets();
		EditorUtility.FocusProjectWindow();
		Selection.activeObject = inst;
		return inst;
	}
	*/

	[MenuItem("Tools/Mantle/Create/Theme")]
	static public MantleThemeInterface CreateMantleTheme() {

		MantleThemeInterface orig = null;

		ScriptableObject obj  = Mantle.Instance.GetSystemDefaultThemeObject();

		if (obj != null) {
			orig = (MantleThemeInterface)obj;
		}

		MantleThemeInterface inst = ScriptableObject.CreateInstance<MantleThemeInterface>();
		MantleThemeInterface.DeepCopy(inst, orig);

		Debug.Log (Mantle.MANTLE_NEW_THEMES_PATH.Substring(0, Mantle.MANTLE_NEW_THEMES_PATH.LastIndexOf('/')));
		Directory.CreateDirectory (Mantle.MANTLE_NEW_THEMES_PATH.Substring(0, Mantle.MANTLE_NEW_THEMES_PATH.LastIndexOf('/')));//"Assets/Mantle/Content/New Mantle Theme/");
		AssetDatabase.CreateAsset(inst, Mantle.MANTLE_NEW_THEMES_PATH);
		AssetDatabase.SaveAssets();
		EditorUtility.FocusProjectWindow();
		Selection.activeObject = inst;
		return inst;
	}


	static public void CloneMantleTheme(MantleThemeInterface theme) {
		
		MantleThemeInterface inst = ScriptableObject.CreateInstance<MantleThemeInterface>();
		MantleThemeInterface.DeepCopy(inst, theme);
		string newName = inst.ThemeName + " (Clone)" + ".asset";
		string pathName = AssetDatabase.GetAssetPath(theme); //   == Assets/Mantle/System/Resources/SystemDefaultTheme/DefaultTheme.prefab
		int lastIndex = pathName.LastIndexOf('/');
		string newpath = pathName.Substring(0, lastIndex) + "/" + newName;
		AssetDatabase.CreateAsset(inst, newpath);
		AssetDatabase.SaveAssets();
		Selection.activeObject = inst;

	}

	[MenuItem("Tools/Mantle/Create/Style/Basic")]
	static public MantleStyleInterface CreateMantleStyleBasic() {
		return CreateMantleStyle<MantleStyleInterface>("New Mantle Style");
	}

	[MenuItem("Tools/Mantle/Create/Style/Building")]
	static public MantleStyleInterface CreateMantleStyle_Building() {
		return CreateMantleStyle<MantleStyle_BuildingsInterface>("New Mantle Building Style");
	}

	[MenuItem("Tools/Mantle/Create/Style/Transport Network")]
	static public MantleStyleInterface CreateMantleStyle_TransNetwork() {
		return CreateMantleStyle<MantleStyle_TransNetworkInterface>("New Mantle TransNetwork Style");
	}
	static public MantleStyleInterface CreateMantleStyle<T>(string assetName, string path = "Assets/Mantle/Content/MantleThemes") where T: MantleStyleInterface {
		MantleStyleInterface inst = ScriptableObject.CreateInstance<T>();
		inst.LoadDefaults();
		AssetDatabase.CreateAsset(inst, path + "/" + assetName + ".asset");
		AssetDatabase.SaveAssets();
		EditorUtility.FocusProjectWindow();
		Selection.activeObject = inst;
		return inst;
	}

	static public void CloneMantleStyleInterface<T>(MantleStyleInterface style) where T : MantleStyleInterface {

		MantleStyleInterface inst = ScriptableObject.CreateInstance<T>();
		inst.CopyFrom(style);
		string newName = inst.name + " (Clone)" + ".asset";
		string pathName = AssetDatabase.GetAssetPath(style); //   == Assets/Mantle/System/Resources/SystemDefaultTheme/DefaultTheme.prefab
		int lastIndex = pathName.LastIndexOf('/');
		string newpath = pathName.Substring(0, lastIndex) + "/" + newName;
		AssetDatabase.CreateAsset(inst, newpath);
		AssetDatabase.SaveAssets();
		Selection.activeObject = inst;

	}




	[MenuItem("Tools/Mantle/Create/Datasource")]
	static public void CreateMantleDataSource() {

		MantleDataSourceInterface inst = ScriptableObject.CreateInstance<MantleDataSourceInterface>();
		//inst.name = "New Mantle Datasource";
		Directory.CreateDirectory (Mantle.MANTLE_NEW_DATA_SOURCE_PATH.Substring(0, Mantle.MANTLE_NEW_DATA_SOURCE_PATH.LastIndexOf('/')));
		AssetDatabase.CreateAsset(inst, Mantle.MANTLE_NEW_DATA_SOURCE_PATH);
		AssetDatabase.SaveAssets();
		EditorUtility.FocusProjectWindow();
		Selection.activeObject = inst;

	}


}
