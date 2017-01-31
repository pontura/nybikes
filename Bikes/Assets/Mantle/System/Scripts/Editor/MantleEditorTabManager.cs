using UnityEngine;
using UnityEditor;
using System;
using System.Collections;
using System.Collections.Generic;

using MantleEngine.Unity.Editor.Utilities;
using UnityEditor.SceneManagement;


namespace MantleEngine.PluginComponents 
{

	[CustomEditor (typeof(MantleInterface)), CanEditMultipleObjects]


	public class MantleEditorTabManager : Editor, IMantleEditorManager {

		public enum GuiTab {
			Main,
			About,
			EULAConsent

		}

		public GuiTab currentTab = GuiTab.Main;
		public Rect position = default(Rect);

		public SerializedObject serializedObj = null;

		protected MantleEditorTab_Main _tabEditor_Main = null;
		protected MantleEditorTab _tabEditor_About = null;
		protected MantleEditorTab _tabEditor_EULAConsent = null;
	

		public MantleInterface mantleInterface = null;
		private EditorCoroutine _currEditorCoroutine;
		//private string _consoleOutputText = CONSOLE_PROMPT_SYMBOL + INITIAL_CONSOLE_MESSAGE;

		public bool dirtyFlag = false;

		public override void  OnInspectorGUI () 
		{
			if (dirtyFlag && target != null)
				EditorUtility.SetDirty (target);
			
			if (mantleInterface == null) {
				//MantleUser.DeleteEULAConsentToken();
				mantleInterface = (MantleInterface)target;
				currentTab = MantleUser.isPlayerConsentGivenForEULA()? GuiTab.Main: GuiTab.EULAConsent;

			}

			position = new Rect(0f,0f,Screen.width, 1000f); // no good way of knowing total inspector height so hardcoded to 1000

			Mantle.Instance.EnsureEditorManagerIsRegistered(this);

			Mantle.Instance.CheckForPendingConsoleMessages(this);

			//SetGUISkin();
			this.serializedObj = serializedObject;

			serializedObject.Update();

			switch (currentTab) {
			case GuiTab.EULAConsent:
				ShowTab_EULAConsent();
				break;
			case GuiTab.Main:
				ShowTab_Main();
				break;
			
			case GuiTab.About:
				ShowTab_About();
				break;
			default:
				ShowTab_Main();
				break;
			}


			serializedObject.ApplyModifiedProperties();

		}

		#region EULA Consent
		protected void ShowTab_EULAConsent() {
			if (_tabEditor_EULAConsent == null) {
				_tabEditor_EULAConsent = new MantleEditorTab_EULAConsent(this);
			}
			_tabEditor_EULAConsent.DrawGUI();
		}
		#endregion

		#region About Tab
		protected void ShowTab_About() {
			if (_tabEditor_About == null) {
				_tabEditor_About = new MantleEditorTab_About(this);
			}
			_tabEditor_About.DrawGUI();
		}
		#endregion

		#region Main Tab

		protected void ShowTab_Main() {
			if (_tabEditor_Main == null) {
				_tabEditor_Main = new MantleEditorTab_Main(this);
			}
			_tabEditor_Main.DrawGUI();
		}


		#endregion







		#region Helper Functions

		public  void DoEditorCoroutineThen( IEnumerator _routine, Mantle.CoroutineStopped onEditorCoroutineStopped = null )
		{
			_currEditorCoroutine =  EditorCoroutine.start(_routine, onEditorCoroutineStopped);

		}


		public void OnLoadComplete() {
			_currEditorCoroutine.stop ();
		}


		protected  List<MantleConsoleMessage> consoleMessages = null;
		public void OutputToInspectorConsole(string text, ConsoleMessageType messageType = ConsoleMessageType.Info, bool clearExistingText = false) {
			
			if (_tabEditor_Main == null) {
				_tabEditor_Main = new MantleEditorTab_Main(this);
			}
			_tabEditor_Main.OutputToInspectorConsole(text, messageType, clearExistingText);
		}

		public void RefreshInspector() {
			if (target == null) return;
			dirtyFlag = true;
			EditorUtility.SetDirty (target);

		}

		public void StopEditor()
		{
			UnityEditor.EditorApplication.isPlaying = false;
		}

		public bool IsEditorInPlayMode() {
			return UnityEditor.EditorApplication.isPlaying;
		}


		public void MarkAllSceneAsDirty()
		{
			EditorSceneManager.MarkAllScenesDirty();
			Debug.Log ("Editor Stopped.");
		}

		public void RegisterCreatedObjectUndo(GameObject go, string operationToUndo = "Load Map"){
			Undo.RegisterCreatedObjectUndo (go, operationToUndo);
		}

		public void ExportScene(string exportMethod) {
			//EntityPrefabExporter.ExportMantleTerrainToTileBundles(); //asset bundles banned since unity 5.4 ..
		}

		public void DestroyObjectImmediate(GameObject go) {
			Undo.DestroyObjectImmediate (go);
		}

		protected void SetGUISkin(GUISkin _skin =  null) {

			// --  if wanting to customise the skin..

			if (_skin == null) {
				_skin = Resources.Load("EditorResources/MantleInspectorSkin") as GUISkin;
			}

			if (_skin != null) {
				GUI.skin = _skin;
			}

		}

		private void ShowSerializeButton() {

			if (GUILayout.Button("Serialize Project") ) {
				string path = Application.dataPath + "/MantleProject.xml";
				if (Mantle.Instance.SerializeProject(path)) {
					Debug.Log("Successfully serialized MantleProject to: " + path);
				} else {
					Debug.Log("Failed to serialize MantleProject to: " + path);
				}
			}

		}
		#endregion



	}

}



