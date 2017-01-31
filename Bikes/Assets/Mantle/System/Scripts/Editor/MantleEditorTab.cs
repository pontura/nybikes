using UnityEngine;
using UnityEditor;


using MantleEngine.Unity.Editor.Utilities;
using System;


namespace MantleEngine.PluginComponents 
{
		
	public class MantleEditorTab
	{
		
		protected MantleEditorTabManager editorParent;

		protected GUIStyle mStyleNormal = null;
		protected GUIStyle mStyleNormal_Left = null;
		protected GUIStyle mStyleBold = null;
		protected GUIStyle mStyleBold_Left = null;
		protected GUIStyle mStyleButton = null;
		protected GUIStyle mStyleCloseButton = null;
		protected GUIStyle mStyleHeader = null;
		protected GUIStyle mStyleQuietLink = null;
		protected GUIStyle mStyleLink = null;
		protected GUIStyle mStyleBackground = null;
		protected GUIStyle mStyleTextArea = null;
		protected GUIStyle mStyleToggle = null;

		protected Texture2D texMainHeader = null;
		protected Texture2D texWindowBackground = null;
		protected Texture2D texButton = null;
		protected Texture2D texButtonDown = null;
		protected Texture2D texCloseButton = null;
		protected Texture2D texCloseButtonDown = null;
		protected bool _buttonClickedLastRender = false;



		public MantleEditorTab(MantleEditorTabManager editorParent) {
			Refresh(editorParent);
		}

		public virtual void Refresh(MantleEditorTabManager editorParent ) {

			this.editorParent = editorParent;

			Color textColor;
			ColorUtility.TryParseHtmlString("#ffffff", out textColor); 

			Color quietLinkOnFocusedColor;
			ColorUtility.TryParseHtmlString("#ffffff", out quietLinkOnFocusedColor);

			Color linkNormalColor;
			ColorUtility.TryParseHtmlString("#ffffff", out linkNormalColor);

			Color linkOnFocusedColor;
			ColorUtility.TryParseHtmlString("#FF6700", out linkOnFocusedColor);

			Color buttonBackgroundColor;
			ColorUtility.TryParseHtmlString("#ff3e00", out buttonBackgroundColor); 

			Color buttonBackgroundPressedColor;
			ColorUtility.TryParseHtmlString("#8a6044", out buttonBackgroundPressedColor);

			Color buttonTextColor;
			ColorUtility.TryParseHtmlString("#ffffff", out buttonTextColor); 

			Color buttonCloseTextColor;
			ColorUtility.TryParseHtmlString("#ffffff", out buttonCloseTextColor); 

			Color buttonTextPressedColor;
			ColorUtility.TryParseHtmlString("#000000", out buttonTextPressedColor); 


			texMainHeader =  Resources.Load("EditorResources/AboutPane_HeaderLogo") as Texture2D;
			texButton = Resources.Load("EditorResources/ButtonSlice") as Texture2D;
			texButtonDown = Resources.Load("EditorResources/ButtonSliceDown") as Texture2D;
			texCloseButton = Resources.Load("EditorResources/CloseButtonSlice") as Texture2D;
			texCloseButtonDown = Resources.Load("EditorResources/CloseButtonSliceDown") as Texture2D;

			Color windowBackgroundColor ;
			ColorUtility.TryParseHtmlString("#404040", out windowBackgroundColor);
			texWindowBackground =  new Texture2D(1, 1, TextureFormat.RGBA32, false); texWindowBackground.SetPixel(0,0,windowBackgroundColor); texWindowBackground.Apply();

			//mStyleNormal
			mStyleNormal = new GUIStyle(EditorStyles.centeredGreyMiniLabel);
			mStyleNormal.fontSize = 12;
			mStyleNormal.normal.textColor = textColor;
			mStyleNormal.wordWrap = true;
			//mStyleNormal.normal.background = texWindowBackground;

			mStyleNormal_Left = new GUIStyle(mStyleNormal);
			mStyleNormal_Left.alignment = TextAnchor.MiddleLeft;

			//mStyleBold
			mStyleBold = new GUIStyle(mStyleNormal);
			mStyleBold.fontSize = 12;
			mStyleBold.fontStyle = FontStyle.Bold;

			mStyleBold_Left = new GUIStyle(mStyleBold);
			mStyleBold_Left.alignment = TextAnchor.MiddleLeft;


			//mStyleButton
			mStyleButton =  new GUIStyle(mStyleBold);
			mStyleButton.normal.textColor = buttonTextColor;
			mStyleButton.normal.background = texButton;
			mStyleButton.active.background = texButtonDown;

			//mStyleCloseButton
			mStyleCloseButton =  new GUIStyle(mStyleButton);
			mStyleCloseButton.border = new RectOffset(4,4,4,4);
			mStyleCloseButton.normal.textColor = buttonCloseTextColor;
			mStyleCloseButton.normal.background = texCloseButton;
			mStyleCloseButton.active.background = texCloseButtonDown;


			//mStyleHeader
			mStyleHeader = new GUIStyle(mStyleButton);
			Texture2D texHeaderButtonBackground = new Texture2D(1,1); texHeaderButtonBackground.SetPixel(0,0, windowBackgroundColor); texHeaderButtonBackground.Apply();
			mStyleHeader.normal.background = texHeaderButtonBackground;
			mStyleHeader.active.background = texHeaderButtonBackground;

			//mStyleButton cont'd
			//Texture2D texPressedButtonBackground = new Texture2D(1,1); texPressedButtonBackground.SetPixel(0,0, buttonBackgroundPressedColor); texPressedButtonBackground.Apply();
			mStyleButton.active.textColor = buttonTextPressedColor;
			//mStyleButton.active.background = texPressedButtonBackground;

			mStyleButton.border = new RectOffset(4,4,4,4);
			mStyleButton.fixedHeight = 40;
			mStyleButton.alignment = TextAnchor.MiddleCenter;

			//mStyleQuietLink 
			mStyleQuietLink = new GUIStyle(mStyleBold);
			mStyleQuietLink.active.textColor = quietLinkOnFocusedColor;

			//mStyleLink 
			mStyleLink = new GUIStyle(mStyleBold);
			mStyleLink.normal.textColor = linkOnFocusedColor;
			mStyleLink.hover.textColor = linkOnFocusedColor;
			mStyleLink.focused.textColor = linkOnFocusedColor;

			//mStyleBackground
			mStyleBackground =  new GUIStyle(EditorStyles.helpBox);
			mStyleBackground.normal.background = texWindowBackground;

			//mStyleTextArea
			mStyleTextArea = new GUIStyle(GUI.skin.box);
			mStyleTextArea.richText = true; //http://docs.unity3d.com/ScriptReference/GUIText-richText.html
			mStyleTextArea.wordWrap = true;
			mStyleTextArea.alignment = TextAnchor.MiddleLeft;
			mStyleTextArea.fontSize = 12;
			mStyleTextArea.normal.textColor = textColor;


			mStyleToggle = EditorTools.ColorStyle( new GUIStyle(EditorStyles.toggle), Color.white);
			mStyleToggle.fontSize = 12;


		}
			


		public virtual void DrawGUI()
		{
			
			Draw_WindowBackground();




		}

		protected virtual void Draw_WindowBackground() {
			
			GUI.DrawTexture(new Rect(0, 0, editorParent.position.width, 2000f), texWindowBackground, ScaleMode.StretchToFill);

		}

		protected void Draw_MantleTitle() {

			if(GUILayout.Button(texMainHeader, mStyleHeader)) {
				Application.OpenURL("http://www.mantle.tech");
				_buttonClickedLastRender = true;
			}

			EditorTools.DrawSectionHeader();
		}

		private string _verDesc = "";

		protected void Draw_MantleCopyright() {
			if (_verDesc == "") {
				_verDesc = "(Release for " + Mantle.ReleaseType.ToString() + ")";
			}

			EditorTools.DrawSectionSeparator();
			string text = String.Format("Mantle™ for Unity {0}\nCopyright 2016 Mantle Technologies, London, UK\n{1}" ,Mantle.VersionNumber, _verDesc) ;
			GUILayout.Label(text, mStyleNormal);
			if(GUILayout.Button("www.mantle.tech",mStyleQuietLink)) {
				Application.OpenURL("http://www.mantle.tech");
				_buttonClickedLastRender = true;
			}
		}

		protected void DrawURLButton(string description, string url) {
			_buttonClickedLastRender = true;
			if(GUILayout.Button(description, mStyleButton)) {
				Application.OpenURL(url);
			}
		}


	}

}