using UnityEngine;
using System;
using System.Collections.Generic;

using MantleEngine.MapServices;
using MantleEngine.PluginUtilities;

namespace MantleEngine.PluginComponents 
{

	[System.Serializable]
	public class MantleDataSourceInterface: ScriptableObject {



		//[Header("Remote Data")]
		public bool useMapServer = true;
		[ContextMenuItem("Reset to default", "ResetURLFormatToDefault")]
		//public string URLFormat = "http://vector.mapzen.com/osm/all/{zoom}/{x}/{y}.json";

		public MapServerVectorTile.MapVectorService mapService;
		public string apiKeyMapServer = "";
		public bool IncludeRemoteEarth = true;
		public bool IncludeRemoteLanduse = true;
		public bool IncludeRemoteWater = true;
		public bool IncludeRemoteBuildings = true;
		public bool IncludeRemoteRoads = true;

		//[Header("Overlay Image Data")]
		public bool useOverlayImageServer = false;
		public MapServiceRaster overlayImageService;
		public string apiKeyImageOverlay = "";
	

		//[Header("Local Data")]
		public bool useLocalFiles = false;
		public string primaryLocalFile= ""; //Users/isaacdart/Documents/DEV/MapData/gml/OSRoadSample_TowerBridgeArea.gml
		public string[] additionalLocalFiles = null; //Users/isaacdart/Documents/DEV/MapData/gml/OSRoadSample_TowerBridgeArea.gml
		public bool IncludeLocalEarth = true;
		public bool IncludeLocalLanduse = true;
		public bool IncludeLocalWater = true;
		public bool IncludeLocalBuildings = true;
		public bool IncludeLocalRoads = true;




		//[HideInInspector]
		//[Header("Terrain Height Data")]
		public bool useTerrainHeightServer = false;
		//[HideInInspector]
		public TerrainHeightService terrainHeightService;
		public string apiKeyTerrainHeights = "";
		//[HideInInspector]
		public bool includeHeightCubes = false;
		public bool applySmoothing = true;
		public bool highAccuracyTerrainAdjustment = false;
		public bool smoothTerrainUnderRoads = false;

		//[Header("Download Settings")]

		public bool cacheIsEnabled = true;
		public bool cacheExpires = false;
		[Range (1,512)]
		public int tileDownloadThreads = 64;
		[Range (1,512)]
		public int tileRefreshRate = 16;

		protected MantleDataSource _script = null;

		public  MantleDataSource Instantiate() {

			_script = new MantleDataSource();
			SetVariables();
			return _script;
		}

		void ResetURLFormatToDefault() {mapService = MapServerVectorTile.MapVectorService.MAPZEN_VECTOR_ALL;}

		protected void SetVariables() {

			_script.useMapServer = useMapServer;
			_script.mapService = mapService;
			_script.apiKeyMapServer = apiKeyMapServer;


			_script.IncludeRemoteEarth = IncludeRemoteEarth;
			_script.IncludeRemoteLanduse = IncludeRemoteLanduse;
			_script.IncludeRemoteWater = IncludeRemoteWater;
			_script.IncludeRemoteBuildings = IncludeRemoteBuildings;
			_script.IncludeRemoteRoads = IncludeRemoteRoads;

			_script.cacheIsEnabled = cacheIsEnabled;
			_script.cacheExpires = cacheExpires;
			_script.tileDownloadThreads = tileDownloadThreads;
			_script.tileRefreshRate = tileRefreshRate;

			_script.useOverlayImageServer = useOverlayImageServer;
			_script.overlayImageService = overlayImageService;
			_script.apiKeyImageOverlay = apiKeyImageOverlay;


			_script.useLocalFiles = useLocalFiles;
			_script.primaryLocalFile= primaryLocalFile;
			_script.additionalLocalFiles = additionalLocalFiles;
			_script.IncludeLocalEarth = IncludeLocalEarth;
			_script.IncludeLocalLanduse = IncludeLocalLanduse;
			_script.IncludeLocalWater = IncludeLocalWater;
			_script.IncludeLocalBuildings = IncludeLocalBuildings;
			_script.IncludeLocalRoads = IncludeLocalRoads;

			_script.useTerrainHeightServer = useTerrainHeightServer;
			_script.terrainHeightService = terrainHeightService;
			_script.includeHeightCubes = includeHeightCubes;
			_script.applySmoothing = applySmoothing;
			_script.highAccuracyTerrainAdjustment = highAccuracyTerrainAdjustment;
			_script.smoothTerrainUnderRoads = smoothTerrainUnderRoads;

			_script.apiKeyTerrainHeights = apiKeyTerrainHeights;


		}

	}



}