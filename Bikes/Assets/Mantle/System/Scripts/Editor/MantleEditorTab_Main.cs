using UnityEngine;
using UnityEditor;


using MantleEngine.Unity.Editor.Utilities;
using System.Collections.Generic;
using System.IO;


namespace MantleEngine.PluginComponents 
{
		
	public class MantleEditorTab_Main : MantleEditorTab
	{
		private const string INITIAL_CONSOLE_MESSAGE = "Ready...";
		private const string CONSOLE_PROMPT_SYMBOL = ">";

		private string[] _cities = null;
		private string[] Cities 
		{
			get
			{
				if (_cities == null)
					LoadCities ();
				return _cities;
			}
		}

		System.Random rnd = new System.Random();

		private void LoadCities()
		{
			string path = Application.dataPath + "/" + Mantle.MANTLE_CONFIG_PATH + "CitiesList.txt";

			if (!File.Exists(path)) 
			{
				_cities = new string[0];
				Mantle.Instance.PrintMessage("Unable to load '"+path+"'",ConsoleMessageType.Error);
			} 
			else 
			{
				using (StreamReader sr = new StreamReader(path)) 
				{
					string line = "";
					List<string> citiesList = new List<string> ();
					while ((line = sr.ReadLine ()) != null)
						citiesList.Add (line);

					_cities = citiesList.ToArray ();
				}
			}
		}

		public MantleEditorTab_Main(MantleEditorTabManager editorParent) : base (editorParent) {
			
		}


		public override void DrawGUI() {

			DrawSection_Location ();
			DrawSection_ThemeAndData();
			DrawSection_Rendering();
			DrawSection_RenderOptions();
			DrawSection_AboutMantle();

			DrawSection_MantleConsole();
		}

		protected void DrawSection_Location() 
		{
			EditorTools.DrawSectionHeader("Project Area");
			EditorTools.HelpBox("Input the lat/long coordinates to set where your Mantle scene will start building.",MessageType.Info);

			SerializedProperty nameProperty = editorParent.serializedObject.FindProperty ("Name");
			SerializedProperty latLngProperty = editorParent.serializedObject.FindProperty ("LatLng");

			if (Mantle.ReleaseType == Mantle.ReleaseBuildType.Trial) { // As per Dean request - we need to only return random cities which have good quality mapping data before an Asset Store release.
				if (GUILayout.Button ("Random City"))
				{
					if (Cities.Length > 0)
					{
						string cityLine = Cities [rnd.Next (0, Cities.Length - 1)];
						string[] splitCityLine = cityLine.Split (';');
						nameProperty.stringValue = splitCityLine [1].Trim() + ", " + splitCityLine [0].Trim();
						latLngProperty.stringValue = splitCityLine [2].Trim() + ", " + splitCityLine[3].Trim();
					}
				}
			}
			
			EditorGUILayout.PropertyField(nameProperty);
			EditorGUILayout.PropertyField(latLngProperty);

			int maxRes = (Mantle.ReleaseType == Mantle.ReleaseBuildType.FreeVersion) 
				? Mantle.FREE_VERSION_MAX_RENDER_SIZE : Mantle.MAX_RENDER_SIZE;
			
			EditorGUILayout.IntSlider (editorParent.serializedObject.FindProperty ("metersNorthToSouth"), 
				Mantle.MIN_RENDER_SIZE, maxRes, new GUILayoutOption[0]);
			EditorGUILayout.IntSlider (editorParent.serializedObject.FindProperty ("metersEastToWest"), 
				Mantle.MIN_RENDER_SIZE, maxRes, new GUILayoutOption[0]);
		}

		protected void DrawSection_ThemeAndData() {
			//EditorGUILayout.InspectorTitlebar(
			EditorTools.DrawSectionHeader("Theme & Data");

			EditorGUILayout.PropertyField(editorParent.serializedObject.FindProperty("dataSource"));
			EditorGUILayout.PropertyField(editorParent.serializedObject.FindProperty("TerrainTheme"));
			if (Mantle.ReleaseType == Mantle.ReleaseBuildType.Trial || Mantle.ReleaseType == Mantle.ReleaseBuildType.Runtime  )
				EditorGUILayout.PropertyField (editorParent.serializedObject.FindProperty ("mantleLicenseKey"));
		}


		protected void DrawSection_Rendering() {

			EditorTools.DrawSectionHeader("Rendering");

			EditorTools.HelpBox("By default Mantle renders content at runtime, simply hit play on a " +
				"scene to see the output. You can just as easily create design-time content by clicking " +
				"the Create Button below.",MessageType.Info);

			DrawCreateButton();
			DrawClearButton();
		}

		protected void DrawCreateButton() 
		{
			if (Mantle.ReleaseType == Mantle.ReleaseBuildType.FreeVersion)
				return;

			if (!Mantle.IsRenderingScene) 
			{
				if (GUILayout.Button ("Create design-time content")) 
				{
					PopupYesNoCancel popup = ScriptableObject.CreateInstance< PopupYesNoCancel>();
					popup.Init("Create Mantle content?", "Do you wish to add Mantle content into your current scene?", delegate 
					{
						editorParent.mantleInterface.Instantiate(false);
						Mantle.Instance.LoadMapFromEditor_Async (editorParent);
					});

				}
			} 
			else 
			{
				GUILayout.Label ("Create design-time content",GUI.skin.button);
				//GUIStyle style = new GUIStyle(); style.alignment = TextAnchor.MiddleCenter; style.normal.textColor = new Color(1f,1f,1f);
				//GUILayout.Label("GENERATING...", style);
			}
		}

		private void DrawClearButton() 
		{
			if (Mantle.ReleaseType == Mantle.ReleaseBuildType.FreeVersion)
				return;
			
			if (GUILayout.Button("Clear design-time content") ) {
				//EditorApplication.update += OnEditorUpdate;
				if (!Mantle.IsRenderingScene) {
					PopupYesNoCancel popup = ScriptableObject.CreateInstance< PopupYesNoCancel>();
					popup.Init("Clear Mantle scene?", "Are you sure you wish to clear all Mantle objects from the scene?", delegate {
						Mantle.Instance.ClearRender();
						OutputToInspectorConsole(INITIAL_CONSOLE_MESSAGE, ConsoleMessageType.Info, true);

					});
				}
			}
		}

		bool isRenderOptionsFoldoutExpanded = false;

		protected void DrawSection_RenderOptions() {
			EditorTools.DrawSectionHeader();

			isRenderOptionsFoldoutExpanded = EditorGUILayout.Foldout(isRenderOptionsFoldoutExpanded, "Render Options", EditorTools.GetHeadingStyleBold());
			if (isRenderOptionsFoldoutExpanded) {
				
				EditorGUILayout.PropertyField(editorParent.serializedObject.FindProperty("autoSelectRenderer"));
				if (!editorParent.serializedObject.FindProperty("autoSelectRenderer").boolValue) {
					EditorGUILayout.PropertyField(editorParent.serializedObject.FindProperty("rendererType"));
				}


				EditorGUILayout.PropertyField(editorParent.serializedObject.FindProperty("noRenderUntilCompletion"));
				EditorGUILayout.PropertyField(editorParent.serializedObject.FindProperty("includeCameraDrone"));

				if (Mantle.ReleaseType != Mantle.ReleaseBuildType.FreeVersion)
					EditorGUILayout.PropertyField(editorParent.serializedObject.FindProperty("doMakeBuildingsStatic"));
				
				EditorGUILayout.PropertyField(editorParent.serializedObject.FindProperty("meshCombineStaticPrefabs"));
				EditorGUILayout.PropertyField(editorParent.serializedObject.FindProperty("showSceneViewGeofence"));
			}
		}

		Texture texAboutMantle = null;

		protected void DrawSection_AboutMantle() {
			EditorTools.DrawSectionHeader();
			if (texAboutMantle == null) {
				texAboutMantle = (Texture)Resources.Load("EditorResources/AboutPane_ButtonGraphic");
			}
			if (GUILayout.Button(texAboutMantle, GUILayout.Height(50))) {
				//MantleAboutPage about = ScriptableObject.CreateInstance< MantleAboutPage>();
				//about.Init();
				editorParent.currentTab = MantleEditorTabManager.GuiTab.About;
			}

			//EditorTools.DrawSectionHeader();
		}



		Vector2 scrollPos = Vector2.zero;
		private bool autoScrollToBottom = false;
		protected void DrawSection_MantleConsole() {

			//EditorGUILayout.Separator();
			EditorTools.DrawSectionHeader("Mantle Output");

			if (consoleMessages == null) {
				OutputToInspectorConsole(INITIAL_CONSOLE_MESSAGE, ConsoleMessageType.Info, true);
			} 

			GUILayout.BeginVertical("box", GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));

			//GUILayout.BeginHorizontal("box", GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));

			//GUILayout.Label("Mantle Output", EditorTools.GetHeadingStyle());
			//GUILayout.EndHorizontal();

			GUILayout.FlexibleSpace();
			if (autoScrollToBottom) {
				scrollPos = new Vector2(0f, float.PositiveInfinity);
				autoScrollToBottom = false;
			}
			//scrollPos = GUILayout.BeginScrollView (scrollPos,GUILayout.Height(100f));
			scrollPos = GUILayout.BeginScrollView (scrollPos, GUILayout.ExpandHeight(true));
			GUILayout.BeginVertical();
			GUIStyle contentStyle = new GUIStyle(); contentStyle.alignment = TextAnchor.UpperLeft; contentStyle.contentOffset = new Vector2(4f,0f); contentStyle.normal.textColor = new Color(0.9f, 0.9f, 0.9f); contentStyle.wordWrap = true;
			//GUILayout.Label(_consoleOutputText, contentStyle);
			//GUI.skin.box = contentStyle;
			if (consoleMessages != null) {
				for (int im = 0; im < consoleMessages.Count; im++) {
					MessageType mt = ConvertConsoleMessageType(consoleMessages[im].msgType);
					EditorTools.HelpBox(consoleMessages[im].text, mt);
				}
			}

			GUILayout.EndVertical();
			GUILayout.EndScrollView();
			GUILayout.FlexibleSpace();

			GUILayout.EndVertical();

		}


		//must ensure that ConsoleMessageType enum is the exact definition as UnityEditor.MessageType
		private UnityEditor.MessageType ConvertConsoleMessageType(ConsoleMessageType cmt) {
			return (UnityEditor.MessageType)((int)cmt);
		}


		protected  List<MantleConsoleMessage> consoleMessages = null;
		public void OutputToInspectorConsole(string text, ConsoleMessageType messageType = ConsoleMessageType.Info, bool clearExistingText = false) {

			if (clearExistingText || consoleMessages == null) {
				consoleMessages = new List<MantleConsoleMessage>();
			}

			consoleMessages.Add(new MantleConsoleMessage(text,messageType));
			autoScrollToBottom = true;


			editorParent.RefreshInspector();


		}


	}

}