using UnityEngine;
using UnityEditor;

using System.Collections;
using MantleEngine.Unity.Editor.Utilities;
using MantleEngine.MapServices;
using System.Collections.Generic;
using MantleEngine.PluginUtilities;

namespace MantleEngine.PluginComponents 
{


	[CustomEditor(typeof(MantleDataSourceInterface)),CanEditMultipleObjects]
	public class MantleEditor_MantleDataSource : Editor {

		private bool _showAlphaFeatures = false;
		private bool _isInit = false;
		private GUIStyle _mStyleToggle = null;

		private Dictionary<string, string> lastApiKeys_MapServer;
		private string _mapBoxKeyDefault = "pk.eyJ1IjoiY2xpcGtpbGxhIiwiYSI6ImJ6VmpJQjAifQ.RNxLemfMaATc36pcz5QIDg"; 
		private int _currMapService = -1;

		private const string REGKEY_PREFIX_MAPSERVERKEY = "MSK_";

		protected void Init() {
			_mStyleToggle = EditorTools.ColorStyle( new GUIStyle(EditorStyles.toggle), Color.white);
			_mStyleToggle.fontSize = 12;

			lastApiKeys_MapServer = MiscTools.GetEnumRegKeys<MapServerVectorTile.MapVectorService>(REGKEY_PREFIX_MAPSERVERKEY);
			_isInit = true;
		}

		public override void OnInspectorGUI () {

			SerializedProperty vectorMapService = serializedObject.FindProperty ("mapService");
			SerializedProperty apiKeyMapServer = serializedObject.FindProperty ("apiKeyMapServer");

			if (!_isInit) {
				Init();
				_currMapService = vectorMapService.intValue;
			}

			bool showAmazingNewFeaturesCommingSoonIfWeGetEnoughPurchasesOnTheStoreFTW = false || Mantle.ReleaseType == Mantle.ReleaseBuildType.Trial || Mantle.ReleaseType == Mantle.ReleaseBuildType.Runtime;

			EditorTools.HelpBox(
				"A datasource controls where the mapping information is drawn from to create " +
				"Mantle environments. If you’re unsure, leave it at its default settings.", MessageType.Info);

			EditorTools.DrawSectionHeader("Remote Vector Data");
			if (showAmazingNewFeaturesCommingSoonIfWeGetEnoughPurchasesOnTheStoreFTW) {
				EditorGUILayout.PropertyField(serializedObject.FindProperty("useMapServer"));
			}

			//...map service changed?
			if (vectorMapService.intValue != _currMapService) {

				string enumTypeName = "";

				//..save previous key?
				if (_currMapService != -1) {
					enumTypeName = vectorMapService.enumNames[_currMapService];
					lastApiKeys_MapServer[enumTypeName] = apiKeyMapServer.stringValue;
					PlayerPrefs.SetString(REGKEY_PREFIX_MAPSERVERKEY + enumTypeName, lastApiKeys_MapServer[enumTypeName]);
				}

				_currMapService = vectorMapService.intValue;

				//.. load new key
				enumTypeName = vectorMapService.enumNames[_currMapService];
				apiKeyMapServer.stringValue = lastApiKeys_MapServer[enumTypeName];

			}

			if ( _currMapService == (int)MapServerVectorTile.MapVectorService.MAPBOX_STREETS_V7_ALL && apiKeyMapServer.stringValue == "")
			{
				apiKeyMapServer.stringValue = _mapBoxKeyDefault;
			} 

			EditorGUILayout.PropertyField(vectorMapService);

			if (apiKeyMapServer.stringValue == _mapBoxKeyDefault && _currMapService == (int)MapServerVectorTile.MapVectorService.MAPBOX_STREETS_V7_ALL)
				EditorGUILayout.HelpBox("A free key has been provided to you from MapBox",MessageType.Info, false);
			
			EditorGUILayout.PropertyField(apiKeyMapServer);


			EditorGUILayout.Separator();
				
			EditorGUILayout.PropertyField(serializedObject.FindProperty("IncludeRemoteLanduse"));
			EditorGUILayout.PropertyField(serializedObject.FindProperty("IncludeRemoteWater"));
			EditorGUILayout.PropertyField(serializedObject.FindProperty("IncludeRemoteBuildings"));
			EditorGUILayout.PropertyField(serializedObject.FindProperty("IncludeRemoteRoads"));
			EditorGUILayout.PropertyField(serializedObject.FindProperty("IncludeRemoteEarth"));



			EditorTools.DrawSectionHeader("Remote Data Settings");
			EditorTools.HelpBox(
				"Cache keeps a downloaded copy of map data from the map server " +
				"locally if enabled. Setting the cache to expire will remove them after the specified period, " +
				"redownloading when next requested.");
			
			EditorGUILayout.PropertyField(serializedObject.FindProperty("cacheIsEnabled"));
			EditorGUILayout.PropertyField(serializedObject.FindProperty("cacheExpires"));

			//clear all cache button..
			if( MantleCacheManager.CacheExists()) {
				if (GUILayout.Button ("Clear cache")) {
					PopupYesNoCancel popup = ScriptableObject.CreateInstance< PopupYesNoCancel>();
					popup.Init("Clear Cache?", "Are you sure you wish to delete all mapping cache from your local system?", delegate {

						if (MantleCacheManager.ClearAllCache()) {
							Mantle.Instance.PrintMessage("Cache successfully cleared");
						} else {
							Mantle.Instance.PrintMessage("No local cache was found.");
						}
					});

				}
			}

			EditorTools.HelpBox(
				"Download threads controls how many map tiles are downloaded simultaneously. If you are experiencing " +
				"issues with map download, try reducing the number of threads. NOTE: increasing the threads will also " +
				"hit the map server much harder so use sparingly.");
			
			EditorGUILayout.PropertyField(serializedObject.FindProperty("tileDownloadThreads"));
			EditorGUILayout.PropertyField(serializedObject.FindProperty("tileRefreshRate"));

			if (showAmazingNewFeaturesCommingSoonIfWeGetEnoughPurchasesOnTheStoreFTW && !_showAlphaFeatures) {
				EditorTools.DrawSectionHeader("Further options ");
				_showAlphaFeatures = GUILayout.Toggle(_showAlphaFeatures,"Show alpha features?", _mStyleToggle);
			}

			if (showAmazingNewFeaturesCommingSoonIfWeGetEnoughPurchasesOnTheStoreFTW && _showAlphaFeatures ) {
				EditorTools.HelpBox(
					"Please note, the below features are under development and may produce unexpected results.");

				EditorTools.DrawSectionHeader("Remote Image Data");
				EditorGUILayout.PropertyField (serializedObject.FindProperty ("useOverlayImageServer"));
				EditorGUILayout.PropertyField(serializedObject.FindProperty("overlayImageService"));
				EditorGUILayout.PropertyField(serializedObject.FindProperty("apiKeyImageOverlay"));

				EditorTools.DrawSectionHeader("Remote Elevation Data");

				EditorGUILayout.PropertyField(serializedObject.FindProperty("useTerrainHeightServer"));
				EditorGUILayout.PropertyField(serializedObject.FindProperty("terrainHeightService"));

				SerializedProperty applySmoothing = serializedObject.FindProperty ("applySmoothing");
				SerializedProperty highAccuracyTerrainAdjustment = serializedObject.FindProperty ("highAccuracyTerrainAdjustment");
				SerializedProperty smoothTerrainUnderRoads = serializedObject.FindProperty ("smoothTerrainUnderRoads");
				EditorGUILayout.PropertyField(applySmoothing);
				if (applySmoothing.boolValue)
				{
					EditorGUILayout.PropertyField (highAccuracyTerrainAdjustment);
					EditorGUILayout.PropertyField (smoothTerrainUnderRoads);
				}
				else
				{
					highAccuracyTerrainAdjustment.boolValue = false;
					smoothTerrainUnderRoads.boolValue = false;
				}

				EditorGUILayout.PropertyField(serializedObject.FindProperty("apiKeyTerrainHeights"));
				EditorGUILayout.PropertyField(serializedObject.FindProperty("includeHeightCubes"));

				EditorTools.DrawSectionHeader("Local Data");

				EditorGUILayout.PropertyField(serializedObject.FindProperty("useLocalFiles"));
				EditorGUILayout.PropertyField(serializedObject.FindProperty("primaryLocalFile"));
				EditorGUILayout.PropertyField(serializedObject.FindProperty("additionalLocalFiles"));
				EditorGUILayout.PropertyField(serializedObject.FindProperty("IncludeLocalEarth"));
				EditorGUILayout.PropertyField(serializedObject.FindProperty("IncludeLocalLanduse"));
				EditorGUILayout.PropertyField(serializedObject.FindProperty("IncludeLocalWater"));
				EditorGUILayout.PropertyField(serializedObject.FindProperty("IncludeLocalBuildings"));
				EditorGUILayout.PropertyField(serializedObject.FindProperty("IncludeLocalRoads"));
			}

			serializedObject.ApplyModifiedProperties();

		}


			
	}

}


