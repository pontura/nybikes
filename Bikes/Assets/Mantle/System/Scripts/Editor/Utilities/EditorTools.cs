using UnityEditor;
using UnityEngine;
using System;


namespace MantleEngine.Unity.Editor.Utilities
{

	public class EditorTools {

		private static GUIStyle _headingStyle = null;
		private static GUIStyle _headingBoldStyle = null;

		public static GUIStyle GetHeadingStyle() {

			if (_headingStyle == null) {
				_headingStyle = new GUIStyle(); _headingStyle.fontStyle = FontStyle.Bold; _headingStyle.alignment = TextAnchor.UpperLeft; _headingStyle.normal.textColor = new Color(1f, 1f, 1f); 
			}
			return  _headingStyle;
		}

		public static GUIStyle GetHeadingStyleBold() {
			
			if (_headingBoldStyle == null) {
				_headingBoldStyle = CloneStyle(EditorStyles.foldout,Color.white); 
				_headingBoldStyle.fontStyle = FontStyle.Bold;
			}
			return _headingBoldStyle;
		}

		public static void DrawSectionHeader(string title = "") {
			
			EditorGUILayout.Separator();
			GUILayout.Box("", new GUILayoutOption[]{GUILayout.ExpandWidth(true), GUILayout.Height(1)});
			if (title != "") {
				EditorGUILayout.LabelField(title, GetHeadingStyle());
			}
		}

		public static void DrawSectionSeparator(int amount = 1) {

			for (int i = 0; i < amount; i++) {
				EditorGUILayout.Separator();
			}


		}

		public static void HelpBox(string message, MessageType messageType = MessageType.Info) {
			
			EditorGUILayout.HelpBox(message, messageType,true);

		}

		public static GUIStyle CloneStyle(GUIStyle fromStyle, Color styleColor = default(Color), bool skipColor = false) {
			
			GUIStyle ret = new GUIStyle(fromStyle);
			if (!skipColor) {
				Color myStyleColor = styleColor;
				//ret.fontStyle = FontStyle.Bold;
				ret.normal.textColor = myStyleColor;
				ret.onNormal.textColor = myStyleColor;
				ret.hover.textColor = myStyleColor;
				ret.onHover.textColor = myStyleColor;
				ret.focused.textColor = myStyleColor;
				ret.onFocused.textColor = myStyleColor;
				ret.active.textColor = myStyleColor;
				ret.onActive.textColor = myStyleColor;
			}

			return ret;

		}

		public static GUIStyle ColorStyle(GUIStyle fromStyle, Color styleColor = default(Color)) {

			GUIStyle ret = new GUIStyle(fromStyle);

			Color myStyleColor = styleColor;
			//ret.fontStyle = FontStyle.Bold;
			ret.normal.textColor = myStyleColor;
			ret.onNormal.textColor = myStyleColor;
			ret.hover.textColor = myStyleColor;
			ret.onHover.textColor = myStyleColor;
			ret.focused.textColor = myStyleColor;
			ret.onFocused.textColor = myStyleColor;
			ret.active.textColor = myStyleColor;
			ret.onActive.textColor = myStyleColor;


			return ret;

		}




	}

}