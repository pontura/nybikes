using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

using MantleEngine.Mathematics;
using MantleEngine.Transport;
using MantleEngine.Parsing;
using MantleEngine.Rendering;
using MantleEngine.MapServices;
using MantleEngine.Geographics;
//using UnityEditor;
using MantleEngine.Utilities;


namespace MantleEngine.PluginComponents 
{
	//[ExecuteInEditMode]
	public class MantleInterface : MonoBehaviour {

		[ContextMenuItem("Go San Francisco", "ResetLocationToSanFrancisco")] 
		[ContextMenuItem("Go Manhattan", "ResetLocationToManhattan")]
		[ContextMenuItem("Go Sydney", "ResetLocationToSydney")]
		[ContextMenuItem("Go Clapham Junction", "ResetLocationToClapham")]
		[ContextMenuItem("Go Tower Bridge", "ResetLocationToTowerBridge")]
		[ContextMenuItem("Go OPDC", "ResetLocationToOPDC")]
		[ContextMenuItem("Go Singapore", "ResetLocationToSingapore")]
		[ContextMenuItem("Go Hong Kong Mid Level", "ResetLocationToHKMidLevel")]
		[ContextMenuItem("Go Matterhorn", "ResetLocationToMatterhorn")] 
		[ContextMenuItem("Go Lund", "ResetLocationToLund")] 

		public string Name = "Lower Manhattan";

		public string LatLng = "40.702833, -74.013125";

		public int metersNorthToSouth = 1000;
		public int metersEastToWest = 1000;

		public MantleDataSourceInterface dataSource = null;

		public MantleThemeInterface TerrainTheme;

		//[Header("Mantle Subscription")]
		[ContextMenuItem("Get a key at sales@mantle.tech", "CreateSalesEmail")]
		[Tooltip("Right click to get a lisence key")]
		public string mantleLicenseKey = ""; // sales@mantle.tech

		[HideInInspector]
		public bool createCityAtRuntime = true;

		//Render options..
		public bool autoSelectRenderer = true;
		public MantleRendererType rendererType = MantleRendererType.LowDefClipper;

		public bool noRenderUntilCompletion=true;
		public bool includeCameraDrone = false;
		public bool doMakeBuildingsStatic = false;
		public bool meshCombineStaticPrefabs = true;
		public bool showSceneViewGeofence = false;

		[HideInInspector]
		public bool geofenceVisible = true;
		private bool _prevGeofenceVisible = true;


		private void CreateSalesEmail()
		{
			Application.OpenURL ("mailto:sales@mantle.tech");
		}

		void ResetLocationToManhattan() {
			Name = "Lower Manhattan";		LatLng = "40.702833 -74.013125"; 		metersNorthToSouth = 1000; 		metersEastToWest = 1000;
			Mantle.Instance.mantleEditor.RefreshInspector ();

		}

		void ResetLocationToSydney() {
			Name = "Sydney - The Rocks";		LatLng = "-33.858597, 151.208107"; 		metersNorthToSouth = 1500; 		metersEastToWest = 1500;
			Mantle.Instance.mantleEditor.RefreshInspector ();

		}

		void ResetLocationToClapham() {
			Name = "Clapham Junction";		LatLng = "51.464543 -0.170687"; 		metersNorthToSouth = 1000; 		metersEastToWest = 1000;
			Mantle.Instance.mantleEditor.RefreshInspector ();

		}

		void ResetLocationToTowerBridge() {
			Name = "Tower Bridge";		LatLng = "51.505637 -0.075357"; 		metersNorthToSouth = 1000; 		metersEastToWest = 1000;
			Mantle.Instance.mantleEditor.RefreshInspector ();

		}

		void ResetLocationToOPDC() {
			Name = "OPDC Sample";		LatLng = "51.525511 -0.2437657"; 		metersNorthToSouth = 700; 		metersEastToWest = 700;
			Mantle.Instance.mantleEditor.RefreshInspector ();

		}

		void ResetLocationToSingapore() {
			Name = "Singapore";		LatLng = "1.301102 103.859858"; 		metersNorthToSouth = 1500; 		metersEastToWest = 1500;
			Mantle.Instance.mantleEditor.RefreshInspector ();

		}

		void ResetLocationToHKMidLevel() {
			Name = "HK Mid Level";		LatLng = "22.276979 114.159893"; 		metersNorthToSouth = 1000; 		metersEastToWest = 1000;
			Mantle.Instance.mantleEditor.RefreshInspector ();

		}

		void ResetLocationToMatterhorn() {
			Name = "Matterhorn Level";		LatLng = "45.976367 7.658728"; 		metersNorthToSouth = 3000; 		metersEastToWest = 3000;
			Mantle.Instance.mantleEditor.RefreshInspector ();

		}

		void ResetLocationToLund() {
			Name = "Lund";		LatLng = "55.705552, 13.190371"; 		metersNorthToSouth = 1000	; 		metersEastToWest = 1000;
			Mantle.Instance.mantleEditor.RefreshInspector ();

		}

		void ResetLocationToSanFrancisco() {
			Name = "San Francisco";		LatLng = "37.806882, -122.423731"; 		metersNorthToSouth = 700	; 		metersEastToWest = 700;
			//Name = "San Francisco";		LatLng = "37.802597, -122.427455"; 		metersNorthToSouth = 3000	; 		metersEastToWest = 3000;
			Mantle.Instance.mantleEditor.RefreshInspector ();
		}




		#region Mante system declarations

		protected Mantle _script = null;
		//public IMantleEditorManager mantleEditor;

		#endregion


		//[ExecuteInEditMode]

		void OnValidate(){
			transform.hideFlags = HideFlags.HideInInspector | HideFlags.NotEditable;

			//..ensure we default to the system default theme if it is not set / null..
			if (TerrainTheme == null) {
				
				ScriptableObject obj  = Mantle.Instance.GetSystemDefaultThemeObject();

				if (obj != null) {
					TerrainTheme = (MantleThemeInterface)obj;
				}

			}

			//..ensure we default to the system default datasource if it is not set / null..
			if (dataSource == null) {
				ScriptableObject obj  = Mantle.Instance.GetSystemDefaultDataSourceObject();

				if (obj != null) {
					dataSource = (MantleDataSourceInterface)obj;
				}

			}

			if (_prevGeofenceVisible != geofenceVisible) {
				MantleGeoFence.SetOutlineVisibility(geofenceVisible);
				_prevGeofenceVisible = geofenceVisible;
			}


		}


		public void Awake()
		{
			transform.hideFlags = HideFlags.HideInInspector | HideFlags.NotEditable;
		}



		//...moved directly into Start() condition. -- IMD
		//protected bool DoStreamingLoad = Mantle.ReleaseType == Mantle.ReleaseBuildType.Runtime

		public void Start() 
		{
			
			//if (!EditorApplication.isPlaying)
			//	return;
			
			transform.hideFlags = HideFlags.HideInInspector | HideFlags.NotEditable;

			Instantiate();


			_prevGeofenceVisible = geofenceVisible;
		}

		void OnApplicationQuit()
		{
			if (ThreadedJob.activeThreads.Count > 0)
				Debug.Log ("Aborting " + ThreadedJob.activeThreads.Count + " threads");
			ThreadedJob.AbortAllThreads ();
		}


		public  Mantle Instantiate(bool startMantle = true) 
		{
			SetVariables();
			if (startMantle) _script.Start();
			return _script;
		}



		protected  void SetVariables() {

			_script = Mantle.Instance;
			_script.mantleUnityInterface = this;
			_script.mantleEditor = null; /// this may be set on editor activation..

			_script.Name = Name;

			Position2D pos = Position2D.NewFromLatLng(LatLng);
			_script.centreLatitude = pos.y;
			_script.centerLongitude = pos.x;

			_script.metersNorthToSouth = metersNorthToSouth;
			_script.metersEastToWest = metersEastToWest;
			_script.dataSource = dataSource.Instantiate();
			_script.TerrainTheme = TerrainTheme.Instantiate(); // instatiated..
			_script.apiKeyMantleLicense = mantleLicenseKey; 
			//_script.createCityAtRuntime = createCityAtRuntime;
			_script.autoSelectRenderer = autoSelectRenderer;
			_script.rendererType = rendererType;

			_script.noRenderUntilCompletion = noRenderUntilCompletion;
			_script.includeCameraDrone = includeCameraDrone;
			_script.doMakeBuildingsStatic = doMakeBuildingsStatic;
			_script.showSceneViewGeofence = showSceneViewGeofence;
			_script.meshCombineStaticPrefabs = meshCombineStaticPrefabs;

			//_script.rendererClassNameToUse = GetRendererClassName();

			_script.defaultMantleStyle = MantleStyleInterface.GetSystemDefaultStyle();

		}

		protected string GetRendererClassName() 
		{


			if (!dataSource.useTerrainHeightServer)
			{
				if (dataSource.mapService == MapServerVectorTile.MapVectorService.MAPZEN_VECTOR_ALL)
					return Mantle.MANTLE_RENDERER_CLASS_LOWDEF_POLY;//return  Mantle.MANTLE_RENDERER_CLASS_SIMPLE;
				else
					return Mantle.MANTLE_RENDERER_CLASS_LOWDEF_POLY;
			}
			else
				return Mantle.MANTLE_RENDERER_CLASS_POLYCLIPPER;
		}

		void OnGUI() 
		{
			if (_script != null) {
				
				
				_script.OnGUI();
			}
		}

		#if  UNITY_STANDALONE || UNITY_EDITOR
		public void FixedUpdate() {
			if (Input.GetKeyUp(KeyCode.Escape)) {
				Debug.Log ("Escape key pressed, Mantle quitting...");
				Application.Quit();
			}
		}
		#endif


	}

}

