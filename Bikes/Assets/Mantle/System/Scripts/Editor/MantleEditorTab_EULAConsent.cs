using UnityEngine;
using UnityEditor;


using MantleEngine.Unity.Editor.Utilities;
using MantleEngine.IO;


namespace MantleEngine.PluginComponents 
{
		
	public class MantleEditorTab_EULAConsent : MantleEditorTab
	{
		
			
		private string EULAConsentText = "" ;
		Vector2 scrollPos;
		bool isUserAgreed = false;


		public MantleEditorTab_EULAConsent(MantleEditorTabManager editorParent) : base(editorParent) {

			scrollPos = default(Vector2);
			RefreshEULAText();

		}

		protected void RefreshEULAText() {
			string filePathEULA =  Application.dataPath + "/" + Mantle.MANTLE_FILE_NAME_EULA;
			EULAConsentText = SystemFileIO.GetTextFromFile(filePathEULA);

		}
					


		public override void DrawGUI()
		{
			
			Draw_WindowBackground();

			//Draw_MantleTitle();
			Draw_MantleCopyright();
			Draw_MantleEULA();


		}

	


		protected void Draw_MantleEULA() {
			
			EditorTools.DrawSectionSeparator(2);

			GUILayout.Label("End-User License Agreement", mStyleBold_Left);
			GUILayout.Label("Please read the following license agreement carefully.", mStyleNormal_Left);
			EditorTools.DrawSectionSeparator();

			scrollPos = GUILayout.BeginScrollView (scrollPos,  mStyleTextArea, GUILayout.Height (400));

				GUILayout.Box(EULAConsentText, mStyleTextArea); 

			GUILayout.EndScrollView();

			EditorTools.DrawSectionSeparator();
			isUserAgreed = GUILayout.Toggle(isUserAgreed,"  I accept the terms in the license agreement.", mStyleToggle);
			EditorTools.DrawSectionSeparator();
			if (isUserAgreed) {
				if (GUILayout.Button("Next >", mStyleButton)) {; //, GUILayout.Width(100));
					MantleUser.SetEULAConsentToken();
					editorParent.currentTab = MantleEditorTabManager.GuiTab.Main;
				}
			}

		}





	}

}