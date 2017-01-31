using UnityEngine;
using UnityEditor;


using MantleEngine.Unity.Editor.Utilities;


namespace MantleEngine.PluginComponents 
{
		
	public class MantleEditorTab_About : MantleEditorTab
	{
		

		public MantleEditorTab_About(MantleEditorTabManager editorParent) : base (editorParent) {
			
		}

		public override void DrawGUI()
		{
			
			Draw_WindowBackground();

			Draw_MantleCloseButton();
			Draw_MantleTitle();
			Draw_MantleCopyright();
			Draw_MantleTeam();
			Draw_MantleSupport();
			Draw_MantleSocial();
			Draw_MantleCredits();


		}



		protected void Draw_MantleTeam() {
			
			EditorTools.DrawSectionSeparator();
			GUILayout.Label("Developed by Mantle Team London:", mStyleNormal);
			GUILayout.Label("Development", mStyleBold);
			GUILayout.Label("Isaac Dart\nSam Amantea-Collins", mStyleNormal);
			GUILayout.Label("Design", mStyleBold);
			GUILayout.Label("Dean Gifford\nYvonne Jackson\n", mStyleNormal);

		}

		protected void Draw_MantleSupport() {

			EditorTools.DrawSectionSeparator();
			DrawURLButton("Register Mantle (Website)", "http://eepurl.com/cariMz");
			DrawURLButton("Tutorial Videos (YouTube)", "https://www.youtube.com/c/MantleTech");
			DrawURLButton("QuickStart Guide (PDF)","http://www.mantle.tech/quickstart/");

		}


		protected void Draw_MantleSocial() {
			EditorTools.DrawSectionSeparator();
			GUILayout.Label("\nHow can we make Mantle better?", mStyleBold);
			GUILayout.Label("Suggestions, improvements, bugs, comments and sharing the amazing things you create with Mantle are ALWAYS welcome!", mStyleNormal);
			GUILayout.Label("Contact us at any of the details below, we want to hear from you.\n", mStyleNormal);

			EditorTools.DrawSectionSeparator();

			GUILayout.BeginHorizontal();
			DrawURLButton("Website", "http://www.mantle.tech");
			DrawURLButton("Forum", "http://www.mantle.tech/forum/");
			DrawURLButton("Twitter", "https://twitter.com/MantleTech");
			DrawURLButton("Facebook", "https://www.facebook.com/mantle.technologies/");
			GUILayout.EndHorizontal();
			EditorTools.DrawSectionHeader();
		}

		Vector2 scrollPos = Vector2.zero;
		protected void Draw_MantleCredits() {

//			GUILayout.FlexibleSpace();
//			scrollPos = GUILayout.BeginScrollView (scrollPos, GUILayout.ExpandHeight(true));
//			GUILayout.BeginVertical("box", GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));

			EditorTools.DrawSectionSeparator();
			GUILayout.Label("\nMantle makes use of technology from:\n", mStyleBold);

			//GUILayout.BeginVertical();
			GUILayout.Label("OpenStreetMap", mStyleNormal);
			if(GUILayout.Button("https://www.openstreetmap.org\n", mStyleLink)) {
				Application.OpenURL("https://www.openstreetmap.org");
				_buttonClickedLastRender = true;
			}

			GUILayout.Label("Mapbox", mStyleNormal);
			if(GUILayout.Button("https://mapbox.com\n", mStyleLink)) {
				Application.OpenURL("https://mapbox.com/");
				_buttonClickedLastRender = true;
			}

			GUILayout.Label("Mapzen", mStyleNormal);
			if(GUILayout.Button("https://mapzen.com\n", mStyleLink)) {
				Application.OpenURL("https://mapzen.com/");
				_buttonClickedLastRender = true;
			}


			EditorTools.DrawSectionSeparator();
			GUILayout.Label("Triangle.NET for Unity", mStyleNormal);
			if(GUILayout.Button("github.com/parahunter/triangle-net-for-unity", mStyleLink)) {
				Application.OpenURL("https://github.com/parahunter/triangle-net-for-unity");
				_buttonClickedLastRender = true;
			}
			GUILayout.Label("by Jonathan Shewchuk\n", mStyleNormal);

			EditorTools.DrawSectionSeparator();
			GUILayout.Label("Clipper", mStyleNormal);
			if(GUILayout.Button("angusj.com/delphi/clipper.php", mStyleLink)) {
				Application.OpenURL("http://www.angusj.com/delphi/clipper.php");
				_buttonClickedLastRender = true;
			}
			GUILayout.Label("by Angus Johnson\n", mStyleNormal);

			EditorTools.DrawSectionSeparator();
			GUILayout.Label("PROJ.4", mStyleNormal);
			if(GUILayout.Button("github.com/OSGeo/proj.4/wiki", mStyleLink)) {
				Application.OpenURL("https://github.com/OSGeo/proj.4/wiki");
				_buttonClickedLastRender = true;
			}
			GUILayout.Label("by Frank Warmerdam\n", mStyleNormal);

//			GUILayout.EndVertical();
//			GUILayout.EndScrollView();
//			GUILayout.FlexibleSpace();
		}



		protected void Draw_MantleCloseButton() {

			GUILayout.Space(-10);

			if (GUILayout.Button("[ close ]", mStyleCloseButton, GUILayout.Height(30))) {
				editorParent.currentTab = MantleEditorTabManager.GuiTab.Main; 
			}

		}


	}

}