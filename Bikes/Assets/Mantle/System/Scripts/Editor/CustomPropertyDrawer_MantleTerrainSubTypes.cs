using UnityEngine;
using UnityEditor;

using System.Collections;
using System.Collections.Generic;
using System.IO;



namespace MantleEngine.PluginComponents 
{


	//[CustomPropertyDrawer (typeof(MantleTerrainSubtype_Road))]
	public class MantleEditor_MantleTerrainSubtype : PropertyDrawer {

		protected Rect includeCheckboxRect ;
		protected Rect terrainSubtypeNameRect;
		protected Rect terrainSubtypePopup;
		protected Rect mantleStyleRect;

		protected SerializedProperty spInclude = null;
		protected SerializedProperty spSubtypeNameIndex = null;
		protected SerializedProperty spStyle = null;
		protected SerializedProperty spSubtypeName = null;

		protected float singleLineHeight = -1f;

		protected bool invalid = false;

		// Draw the property inside the given rect
		public override void OnGUI (Rect position, SerializedProperty property, GUIContent label) {
			// Using BeginProperty / EndProperty on the parent property means that
			// prefab override logic works on the entire property.
			LoadAndValidateFields(ref property);
			OnGuiMantleTerrainSubtype(ref position, ref property, ref label);
		}

		public virtual void LoadAndValidateFields(ref SerializedProperty property) {
			
			spInclude = property.FindPropertyRelative ("Include");
			spSubtypeName = property.FindPropertyRelative ("SubtypeName");
			spSubtypeNameIndex = property.FindPropertyRelative ("_subtypeNameDropdownIndex");
			spStyle = property.FindPropertyRelative ("style");

			if (spInclude.boolValue && spStyle.objectReferenceValue == null)
				invalid = true;
			else
				invalid = false;

			//if subtype name is empty, then assume this is a newly created element so populate with defaults.
			if (spSubtypeName.stringValue == null || spSubtypeName.stringValue.Trim() == "") {
				spInclude.boolValue = true;
				SetPopupIndex(spSubtypeNameIndex.intValue);
				spStyle.objectReferenceValue = GetDefaultStyleInterface();
			}
		}

		protected virtual MantleStyleInterface GetDefaultStyleInterface() {
			return MantleStyleInterface.GetSystemDefault();
		}

		public void OnGuiMantleTerrainSubtype(ref Rect position, ref SerializedProperty property, ref GUIContent label) 
		{
			if (!spInclude.boolValue)
				GUI.backgroundColor = new Color(0.7f, 0.7f, 0.7f);
			else if (invalid)
				GUI.backgroundColor = Color.red;

			EditorGUI.BeginProperty (position, label, property);

			position.height = singleLineHeight;

			// Draw label if speficied..
			if (label.text != "") {
				position = EditorGUI.PrefixLabel (position, GUIUtility.GetControlID (FocusType.Passive), label);
			}


			// Don't make child fields be indented
			var indent = EditorGUI.indentLevel;
			EditorGUI.indentLevel = 0;

			position.width -= 20f;
			//position.height -= 1f;
			Rect currPosition = position;  currPosition.x += 32; currPosition.width = currPosition.height;
			includeCheckboxRect =new  Rect (currPosition.x ,currPosition.y, currPosition.width, currPosition.height);

			currPosition.x += currPosition.width + 4; currPosition.width = 116;
			terrainSubtypeNameRect = new Rect (currPosition.x, currPosition.y, currPosition.width, currPosition.height);

			//currPosition.x += currPosition.width + 1; currPosition.width = currPosition.height * 1.1f;
			currPosition.x += 0; currPosition.width = currPosition.width + 1 + currPosition.height * 1.1f;
			terrainSubtypePopup = new Rect (currPosition.x ,currPosition.y, currPosition.width, currPosition.height);

			float minWidth = 32f;
			//int remainingWidth = (int)(Mathf.Max(minWidth, position.width - (currPosition.x-position.x )))  ;
			int remainingWidth = (int)(Mathf.Max(minWidth, position.width - currPosition.width - (currPosition.x-position.x )+ currPosition.height))  ;
			currPosition.x += currPosition.width +3f; currPosition.width = remainingWidth;
			mantleStyleRect = new Rect (currPosition.x ,currPosition.y, currPosition.width, currPosition.height);

			OnGuiMantleTerrainSubtype_ShowPopup(ref position, ref property, ref label);

			EditorGUI.PropertyField (includeCheckboxRect, spInclude, GUIContent.none);
			EditorGUI.PropertyField (mantleStyleRect, spStyle, new GUIContent());

			//..for more elements in child, insert other call to virtual function overriden here..
			OnGuiMantleTerrainSubtype_CustomControls(ref position, ref property, ref label);

			// Set indent back to what it was
			EditorGUI.indentLevel = indent;

			EditorGUI.EndProperty ();

			GUI.backgroundColor = Color.white;
		}





		public virtual void OnGuiMantleTerrainSubtype_ShowPopup(ref Rect position, ref SerializedProperty property, ref GUIContent label) {



			// popup functionality..
			EditorGUI.BeginChangeCheck ();

			//..show a popup..

			//GUIStyle bStyle = new GUIStyle(); bStyle.
			spSubtypeNameIndex.intValue = EditorGUI.Popup(terrainSubtypePopup,  spSubtypeNameIndex.intValue, GetPopupContents()); 


			//..if popup updated then update the text field..
			if (EditorGUI.EndChangeCheck ()) {
				spSubtypeName.stringValue = GetPopupValueAtIndex(spSubtypeNameIndex.intValue);
			}

			Draw_SubtypeNameField();

		}

		//Draw readonly subtype name feild..

		public void Draw_SubtypeNameField() {
			GUIStyle bbg = GUI.skin.button;
			Color orig = bbg.normal.textColor;
			bbg.normal.textColor = new Color(0.760784f, 0.45490f, 0f);
			EditorGUI.LabelField (terrainSubtypeNameRect, spSubtypeName.stringValue, bbg);
			bbg.normal.textColor = orig;
		}

		public void SetPopupIndex(int index) {
			
			spSubtypeNameIndex.intValue = index;
			spSubtypeName.stringValue = GetPopupValueAtIndex(spSubtypeNameIndex.intValue);
			Draw_SubtypeNameField();
		}

		public virtual string[] GetPopupContents() {

			string[] contents = new string[]{};
			return contents;
		}

		public virtual string GetPopupValueAtIndex(int index) {
			return "";
		}

		public static string[] LoadCommonTypes(string configFileName, bool forceRefresh = false) {

			string path = Application.dataPath + "/" + Mantle.MANTLE_CONFIG_PATH + configFileName;

			List<string> types = new List<string>();

			if (!File.Exists(path)) {
				types.Add("Error: Missing Mantle\\Config\\" + configFileName + "!");
				Mantle.Instance.PrintMessage("Unable to load '"+path+"'",ConsoleMessageType.Error);
			} else {
				using (StreamReader sr = new StreamReader(path)) {
					string line = "";
					while ((line = sr.ReadLine()) != null) {
						line = line.Trim();
						types.Add(line);
					} 
				}
			}

			return types.ToArray();

		}



		public virtual void OnGuiMantleTerrainSubtype_CustomControls(ref Rect position, ref SerializedProperty property, ref GUIContent label) {

		

		}

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {

			if (singleLineHeight < 0f) {
				singleLineHeight = base.GetPropertyHeight(property, label);
			}

			return singleLineHeight;


		}
			

	}

}


