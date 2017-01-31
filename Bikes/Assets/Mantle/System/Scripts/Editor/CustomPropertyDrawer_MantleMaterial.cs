using UnityEngine;
using UnityEditor;

using System.Collections;
using System.Collections.Generic;
using System.IO;



namespace MantleEngine.PluginComponents 
{


	[CustomPropertyDrawer (typeof(MantleMaterial))]
	public class MantleEditor_MantleMaterial : PropertyDrawer {


		protected Rect label1Rect;
		protected Rect mat1Rect;
		protected Rect label2Rect;
		protected Rect mat2Rect;


		protected float singleLineHeight = -1f;

		// Draw the property inside the given rect
		public override void OnGUI (Rect position, SerializedProperty property, GUIContent label) {
			// Using BeginProperty / EndProperty on the parent property means that
			// prefab override logic works on the entire property.

			OnGuiMantleMaterial(ref position, ref property, ref label);


		}


		public void OnGuiMantleMaterial(ref Rect position, ref SerializedProperty property, ref GUIContent label) {

			EditorGUI.BeginProperty (position, label, property);

			position.height = singleLineHeight;

			// Draw label if speficied..
//			if (label.text != "") {
//				position = EditorGUI.PrefixLabel (position, GUIUtility.GetControlID (FocusType.Passive), label);
//			}


			// Don't make child fields be indented
			var indent = EditorGUI.indentLevel;
			EditorGUI.indentLevel = 0;

			Rect currPosition = position;

			float indentWidth = 20f, label1Width = 30f, label2Width = 65f, controlGap = 8f;

			float fieldWidth = (currPosition.width - indentWidth - label1Width - label2Width - controlGap*2f) * 0.5f;
			currPosition.x = indentWidth;
			currPosition.width = label1Width;
			label1Rect = new Rect (currPosition.x, currPosition.y, currPosition.width, currPosition.height);

			currPosition.x += currPosition.width + controlGap;  currPosition.width = fieldWidth;
			mat1Rect = new Rect (currPosition.x, currPosition.y, currPosition.width, currPosition.height);

			currPosition.x += currPosition.width + controlGap; currPosition.width = label2Width;
			label2Rect = new Rect (currPosition.x, currPosition.y, currPosition.width, currPosition.height);

			currPosition.x += currPosition.width + controlGap; currPosition.width = fieldWidth;
			mat2Rect = new Rect (currPosition.x, currPosition.y, currPosition.width, currPosition.height);

			EditorGUI.LabelField (label1Rect, "Main","");
			//EditorGUI.PropertyField (mat1Rect, property.FindPropertyRelative ("mainMaterial"), new GUIContent (""));
			EditorGUI.PropertyField (mat1Rect, property.FindPropertyRelative ("mainMaterial"), new GUIContent (""));

			EditorGUI.LabelField (label2Rect, "Secondary");
			EditorGUI.PropertyField (mat2Rect, property.FindPropertyRelative ("secondaryMaterial"), new GUIContent (""));


			// Set indent back to what it was
			EditorGUI.indentLevel = indent;

			EditorGUI.EndProperty ();

		}




		public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {

			if (singleLineHeight < 0f) {
				singleLineHeight = base.GetPropertyHeight(property, label);
			}

			return singleLineHeight;


		}


	}

}


