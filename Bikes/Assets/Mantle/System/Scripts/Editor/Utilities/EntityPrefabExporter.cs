/* -- webplayer assetbundles bannded from unity asset store since 5.4, so commenting out
 * 
using System.Collections.Generic;
using System.IO;
using System.Text;

using System.Linq;


using System.Collections;

using UnityEngine;
using UnityEditor;

using MantleEngine.PluginComponents;
using MantleEngine.PluginUtilities ;
using MantleEngine.Rendering;
using MantleEngine.DataStructures;
using LitJson;
using System;

namespace MantleEngine.Unity.Editor.Utilities
{
	public enum MantleMetaDataFileFormat {
		json,
		xml
	};

	public class EntityPrefabExporter
	{

		public static AssetBundleManifest ExportMantleTerrainToTileBundles(float tileSizeMeters = 100f, bool skipBundleCreation = false, MantleMetaDataFileFormat mantleMetaDataFileFormat = MantleMetaDataFileFormat.json ) {

			int prefabsCreatedCount = 0;
			int bundlesCreatedCount = 0;

			PathUtil.EnsureDirectoryClean(EditorPaths.MantlePrefabAbsoluteDirectory);
			PathUtil.EnsureDirectoryClean(EditorPaths.MantleBundlesAbsoluteParentDirectory);

			Dictionary<string, List<MantleRenderedTerrain>> terrainTiles = new Dictionary<string, List<MantleRenderedTerrain>>();
			List<MantleRenderedTerrain> tileContents = null;

			//group terrain into tiles of <tileSizeMeters> in size..
			Debug.Log ("Grouping Mantle terrain into location based asset bundles...");
			MantleRenderedTerrain[] mantleObjects = GameObject.FindObjectsOfType<MantleRenderedTerrain>() ;
			for (int i = 0; i < mantleObjects.Length; i++) {
				MantleRenderedTerrain mo = mantleObjects [i];
				if (mo.isActiveAndEnabled) {
					MantleTile mt = MantleTile.GetMantleTileForTerrain (mo);
					string tileName = mt.ToString ();
					if (!terrainTiles.TryGetValue (tileName, out tileContents)) {

						tileContents = new List<MantleRenderedTerrain> ();
						terrainTiles.Add (tileName, tileContents);
					}
					tileContents.Add (mo);


				}

			}

			//make all found terrain objects into  prefabs under folder structure prefab_folder/tile_name/terrain_type/sub_terrain_type/gameobject_name.prefab
			//Dictionary<string, List<string>> terrainTilePrefabPaths = new Dictionary<string, List<string>>();
			//List<string> currentPrefabPathList = null;

			Dictionary<string, AssetBundleTile> assetBundleTiles = new Dictionary<string, AssetBundleTile>();
			AssetBundleTile currentAssetBundleTile = null;



			int tileCounter = 0;
			AssetDatabase.SaveAssets();
			AssetDatabase.Refresh();

			foreach (KeyValuePair<string, List<MantleRenderedTerrain>> kvp in terrainTiles) {
				string tileName = kvp.Key;
				Debug.Log (string.Format("Saving Mantle terrain prefabs for tile '{0}' ({1} of {2}) ...", tileName, tileCounter, terrainTiles.Count));
				List<MantleRenderedTerrain> mtrs = kvp.Value;

				for (int mti = 0; mti < mtrs.Count; mti++) {
					string prefabFolderName = mtrs[mti].GetPrefabFolderPath (EditorPaths.MANTLE_PREFAB_EXPORT_DIRECTORY + "/" + tileName);
					GameObject newPrefab = SaveMantleTerrainAsPrefab (prefabFolderName, mtrs[mti]);
					if (newPrefab != null) {
						if (!assetBundleTiles.TryGetValue(tileName, out currentAssetBundleTile)) {
							//create new tile path..
							currentAssetBundleTile = new AssetBundleTile(tileName);
							assetBundleTiles.Add (tileName, currentAssetBundleTile);
							bundlesCreatedCount++;
						}
						prefabsCreatedCount++;

						string prefabRelativePathFileName = prefabFolderName + "/" + newPrefab.name + ".prefab";
						//assetBundleTiles.Add (currentAssetBundleTile);
						currentAssetBundleTile.PrefabInfo.Add(new AssetMetaData(prefabRelativePathFileName, mtrs[mti].transform));
					}
				}
			}

			AssetDatabase.SaveAssets();
			AssetDatabase.Refresh();
			Debug.Log (string.Format("EntityPrefabExporter has saved {0} meshes.", mantleObjects.Length));

			//... create the bundle build map out the bundles per tile..
			List<AssetBundleBuild> buildMap = new List<AssetBundleBuild>();

			foreach (KeyValuePair<string, AssetBundleTile> kvp in assetBundleTiles) {
				AssetBundleBuild abb = new AssetBundleBuild();
				abb.assetBundleName = kvp.Key;
				abb.assetNames = new string[kvp.Value.PrefabInfo.Count];
				for (int i = 0; i < kvp.Value.PrefabInfo.Count; i++) {
					abb.assetNames[i] = kvp.Value.PrefabInfo[i].PrefabName;
				}
				buildMap.Add (abb);

				Debug.Log (string.Format("Creating AssetBundleBuild '{0}' containing {1} referenced assets..." , abb.assetBundleName, abb.assetNames.Length));
				//Debug.Log ("   Reference assets are: " + IzTools.ArrayToString<string>(abb.assetNames));
			}

			//.. finally create the bundles (Unity 5.0+)..
			AssetBundleManifest abm = null;
			if (!skipBundleCreation) {
				Debug.Log ("Building Mantle asset bundles to :  " + EditorPaths.MANTLE_BUNDLE_EXPORT_DIRECTORY);
				//abm = BuildPipeline.BuildAssetBundles(EditorPaths.MANTLE_BUNDLE_EXPORT_DIRECTORY, buildMap.ToArray(), BuildAssetBundleOptions.UncompressedAssetBundle,BuildTarget.StandaloneWindows64);
				abm = BuildPipeline.BuildAssetBundles(EditorPaths.MANTLE_BUNDLE_EXPORT_DIRECTORY, buildMap.ToArray(), BuildAssetBundleOptions.UncompressedAssetBundle,BuildTarget.StandaloneWindows64);
			} else {
				Debug.Log ("Skipping bundle creation... ");
			}

			Debug.Log ("Creating Mantle asset bundle metadata file to :  " + EditorPaths.MANTLE_BUNDLE_EXPORT_DIRECTORY);

			MantleBundleMetaData mbmd = new MantleBundleMetaData(assetBundleTiles.Values.ToArray());

			string serialized_MantleBundleMetaData = "";

			switch (mantleMetaDataFileFormat) {

				case MantleMetaDataFileFormat.xml:
					serialized_MantleBundleMetaData = MantleEngine.IO.XmlUtility.SerializeObject(mbmd);
					//Debug.Log ("XML: " + Environment.NewLine + xmlEncoded);
					break;

				default: //default to Json format MantleMetaDataFileFormat.json:
					serialized_MantleBundleMetaData =  JsonMapper.ToJson(mbmd);
					//Debug.Log ("JSON: " + Environment.NewLine + jsonEncoded);
					break;
			}

			string mbmdFileName = EditorPaths.MantleBundlesAbsoluteParentDirectory + "/" + "MantleBundlesMetaData." + mantleMetaDataFileFormat.ToString();
			Debug.Log ("Writing Mantle Bundle Metadata to: " + mbmdFileName + " ...");
			File.WriteAllText(mbmdFileName, serialized_MantleBundleMetaData);

			Debug.Log (String.Format("Mantle scene export complete with {0} prefab(s) created in {1} bundle(s).", prefabsCreatedCount, bundlesCreatedCount));
			return abm;
		}



		protected static GameObject SaveMantleTerrainAsPrefab(string parentPath,  MantleRenderedTerrain terrainPiece) {

			string absPathOfPrefab = Directory.GetCurrentDirectory() + "/" + parentPath;
			//Debug.Log ("Ensuring path exists: " + absPathOfPrefab);
			PathUtil.EnsureDirectoryClean(absPathOfPrefab);

			//save the current pcg mesh to the project's Asset Datbase..
			MeshFilter mf  = terrainPiece.gameObject.transform.GetComponent<MeshFilter>();
			Mesh pcgMesh = mf.sharedMesh;
			if (pcgMesh == null) {
				Debug.LogError("Unable to find a mesh on Mantle terrain object : " + terrainPiece.name);
				return null;
			}
			string assetName =  parentPath + "/" + terrainPiece.name + ".mesh";
			if (AssetDatabase.Contains(pcgMesh)) {
				Debug.LogWarning("Overwriting mesh '"+assetName+"'...");
				AssetDatabase.DeleteAsset(assetName);
				AssetDatabase.SaveAssets();
				AssetDatabase.Refresh();
			}

			AssetDatabase.CreateAsset(pcgMesh, assetName);
			mf.mesh = mf.sharedMesh = pcgMesh;




			//save the gameobject as a prefab..
			string prefabPathName = parentPath + "/" + terrainPiece.name + ".prefab";
			GameObject prefab = PrefabUtility.CreatePrefab(prefabPathName, terrainPiece.gameObject,ReplacePrefabOptions.ReplaceNameBased);
			return prefab;

		}

		protected static GameObject SaveMantleTerrainToPrefab(string parentPath,  MantleRenderedTerrain terrainPiece) {
			//PathUtil.EnsureDirectoryExists(parentPath);
			string prefabPathName = parentPath + "/" + terrainPiece.name + ".prefab";
			//Debug.Log ("Prefabbing object : " + parentPath + "/" + prefabFileName );
			return  PrefabUtility.CreatePrefab(prefabPathName, terrainPiece.gameObject,ReplacePrefabOptions.ReplaceNameBased);
			//return null;
		}


		public static void ExportEntityPrefabs()
		{
			PathUtil.EnsureDirectoryExists(EditorPaths.PREFAB_SOURCE_DIRECTORY);
			PathUtil.EnsureDirectoryExists(EditorPaths.PREFAB_RESOURCES_DIRECTORY);
			PathUtil.EnsureDirectoryExists(EditorPaths.PREFAB_EXPORT_DIRECTORY);
			
			EnsurePrefabsHaveAssetNames(FindAssetGuids());
			EditorApplication.SaveAssets();
			ExportAllNamedPrefabs();
		}
		
		public static IEnumerable<string> FindAssetGuids()
		{
			return AssetDatabase.FindAssets("t:prefab", new[]
			                                {
				EditorPaths.PREFAB_SOURCE_DIRECTORY,
				EditorPaths.PREFAB_RESOURCES_DIRECTORY
			}).Where(IsPrefab);
		}
		
		private static bool IsPrefab(string guid)
		{
			return Path.GetExtension(AssetDatabase.GUIDToAssetPath(guid)) == ".prefab";
		}
		
		private static void ExportAllNamedPrefabs()
		{
			BuildPipeline.BuildAssetBundles(EditorPaths.PREFAB_EXPORT_DIRECTORY, BuildAssetBundleOptions.UncompressedAssetBundle, BuildTarget.StandaloneWindows64);
		}
		
		private static void EnsurePrefabsHaveAssetNames(IEnumerable<string> guids)
		{
			foreach (var guid in guids)
			{
				var path = AssetDatabase.GUIDToAssetPath(guid);
				var importer = AssetImporter.GetAtPath(path);
				var name = Path.GetFileNameWithoutExtension(path);
				importer.assetBundleName = name;
			}
		}

		private static void ExportAllPrefabsFromFolder (string fromPrefabFolder, string toBundleFolder ) {

		}


		public static void ExportPrefabsToBundles()
		{
			UnityEngine.Object[] assetPathsList = GetAtPath<UnityEngine.Object>(EditorPaths.PREFAB_SOURCE_DIRECTORY);
			Debug.Log("Loaded " + assetPathsList.Length + " assets at path: " + EditorPaths.PREFAB_SOURCE_DIRECTORY);

			for (int i = 0; i < assetPathsList.Length; i++) {
				UnityEngine.Object prefabToIndividuallyBundle = assetPathsList[0];
				string bundlename = EditorPaths.PREFAB_EXPORT_DIRECTORY + "/" + prefabToIndividuallyBundle.name;

				Debug.Log("Creating asset bundle: " + bundlename + " just for prefab of same name.");
				BuildPipeline.BuildAssetBundle(null, assetPathsList, bundlename, 
				                               BuildAssetBundleOptions.CollectDependencies | BuildAssetBundleOptions.UncompressedAssetBundle, BuildTarget.StandaloneWindows);
			}
		}
		
		public static T[] GetAtPath<T>(string path)
		{
			ArrayList al = new ArrayList();
			string[] fileEntries = Directory.GetFiles(path);
			
			foreach (string fileName in fileEntries)
			{
				int assetPathIndex = fileName.IndexOf("Assets");
				string localPath = fileName.Substring(assetPathIndex);
				
				UnityEngine.Object t = AssetDatabase.LoadAssetAtPath(localPath, typeof(T));
				
				if (t != null)
					al.Add(t);
			}
			
			T[] result = new T[al.Count];
			
			for (int i = 0; i < al.Count; i++)
				result[i] = (T)al[i];
			
			return result;
		}





	}


}
*/