using UnityEngine;
using UnityEditor;

using System.Collections;

namespace MantleEngine.PluginComponents 
{

	/*
	//[CustomPropertyDrawer (typeof(MantleTerrainType))]
	public class MantleEditor_MantleTerrainType : PropertyDrawer {

		private float _startPropertyHeight = 16f;
		private float  _propertyHeight = 16f;

		// Draw the property inside the given rect
		public override void OnGUI (Rect position, SerializedProperty property, GUIContent label) {
			// Using BeginProperty / EndProperty on the parent property means that
			// prefab override logic works on the entire property.

			float rectHeight = _propertyHeight = _startPropertyHeight; 
			float startPositionY = position.y + rectHeight;
			_propertyHeight = startPositionY;

			//return;

			EditorGUI.BeginProperty (position, label, property);



			// Draw label
			position = EditorGUI.PrefixLabel (position, GUIUtility.GetControlID (FocusType.Passive), label);

			// Don't make child fields be indented..
			var indent = EditorGUI.indentLevel;
			EditorGUI.indentLevel = 0;

			// Calculate rects
			Rect currRect;
			currRect = new Rect (position.x, position.y, position.width, position.height); position.y += rectHeight;

			if (EditorGUI.PropertyField (currRect, property.FindPropertyRelative ("DefaultTerrain"), false)) {
				rectHeight = 100; 
				currRect = new Rect (position.x, position.y, position.width, rectHeight);  position.y += rectHeight; 
			}

			rectHeight = _startPropertyHeight;
			currRect = new Rect (position.x, position.y, position.width, rectHeight); position.y += rectHeight;

			EditorGUI.PrefixLabel (currRect, GUIUtility.GetControlID (FocusType.Passive), new GUIContent ("End of TerrainType"));
			position.y += currRect.height;

			// Set indent back to what it was
			EditorGUI.indentLevel = indent;

			_propertyHeight = position.y - startPositionY;

			EditorGUI.EndProperty ();
		}

		public override float GetPropertyHeight (SerializedProperty property, GUIContent label)
		{
			return _propertyHeight;

		}


	}

	*/

}


