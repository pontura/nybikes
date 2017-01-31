using System.IO;

namespace MantleEngine.Unity.Editor.Utilities
{
    /// <summary>
    ///     Contains paths to all resources for the World with the given name.
    /// </summary>
	/// 

	/*
	 * 
	 * [MenuItem("MyTools/Export test")]
     static void Export()
     {

     
	 * 
	 * */


    public static class EditorPaths
    {

		public const string MANTLE_PREFAB_EXPORT_DIRECTORY = "Assets/MantleTilePrefabExport"; // must be relative to project Assets directory...
		public const string MANTLE_BUNDLE_EXPORT_DIRECTORY = "MantleTileBundlesExport"; // must be relative to project..

        public const string DATA_DIRECTORY = "../../../Data";
        public const string ASSET_DATABASE_DIRECTORY = DATA_DIRECTORY + "/AssetDatabase";
        public const string AUTODESK_NAVIGATOR_DIRECTORY = DATA_DIRECTORY + "/AutodeskNavigator";
        public const string SCALA_RESOURCES_FOLDER = "../../../gamelogic/src/main/resources";
        public const string PREFAB_EXPORT_DIRECTORY = ASSET_DATABASE_DIRECTORY + "/EntityPrefab";
        public const string PREFAB_COMPILE_DIRECTORY = "Assets/Improbable/EntityPrefabs";
        public const string PREFAB_SOURCE_DIRECTORY = "Assets/EntityPrefabs";
        public const string PREFAB_RESOURCES_DIRECTORY = "Assets/Resources/EntityPrefabs";
        public const string WORLDSCENE_RESOURCES_DIR = "Assets/src/main/resources";
        public const string SERVER_SUFFIX = "@UnityFSim";
        public const string CLIENT_SUFFIX = "@UnityClient";


		public static readonly string MantlePrefabAbsoluteDirectory = 
			string.Format("{0}/{1}", Directory.GetCurrentDirectory(), MANTLE_PREFAB_EXPORT_DIRECTORY);

		public static readonly string MantleBundlesAbsoluteParentDirectory = 
			string.Format("{0}/{1}", Directory.GetCurrentDirectory(), MANTLE_BUNDLE_EXPORT_DIRECTORY);
        

		public static string AssetDatabaseDirectory
        {
            get { 
				string fullPathName = string.Format("{0}/{1}", Directory.GetCurrentDirectory(), ASSET_DATABASE_DIRECTORY);
				//UnityEngine.Debug.LogWarning("AssetDatabaseDirectory path = '"+fullPathName+"'.");
				return fullPathName; 
			}
        }

        public static string TerrainDirectory(string worldName)
        {
            return string.Format("{0}/Terrain/{1}", AssetDatabaseDirectory, worldName);
        }

        public static string ResourcesDirectory(string worldName)
        {
            return string.Format("{0}/{1}", WORLDSCENE_RESOURCES_DIR, worldName);
        }

        public static string WorldPrefabPath(string worldName)
        {
            return string.Format("{0}/{1}.prefab", ResourcesDirectory(worldName), worldName);
        }

        public static string ObjExportPath(string worldName)
        {
            return string.Format("{0}/world.obj", TerrainDirectory(worldName));
        }

        private static string WorldFilePrefix(string worldName)
        {
            return string.Format("{0}/{1}", TerrainDirectory(worldName), worldName);
        }

        public static string AutodeskNavDataExportPath(string worldName)
        {
            return string.Format("{0}@AutodeskNavigation.NavData", WorldFilePrefix(worldName));
        }

        public static string FSimBundleExportPath(string worldName)
        {
            return string.Format("{0}@UnityFSim.unity3d", WorldFilePrefix(worldName));
        }

        public static string ClientBundleExportPath(string worldName)
        {
            return string.Format("{0}@UnityClient.unity3d", WorldFilePrefix(worldName));
        }

        public static string EntityExportPath()
        {
            return string.Format("{0}/entityList.txt", SCALA_RESOURCES_FOLDER);
        }
    }
}