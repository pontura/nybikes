using UnityEngine;
using UnityEditor;

using System.Collections;

namespace MantleEngine.PluginComponents 
{


	[CustomPropertyDrawer (typeof(MantleTerrainSubtype_RoadInterface))]
	public class MantleEditor_MantleTerrainSubtype_Road : MantleEditor_MantleTerrainSubtype {

		protected SerializedProperty spRoadWidth = null;

		public override string[] GetPopupContents() {
			return LoadCommonTypes("TerrainTypesRoadList.txt");
		}

		public override string GetPopupValueAtIndex(int index) {
			return GetPopupContents()[index];
		}


		public override void LoadAndValidateFields(ref SerializedProperty property) {
			base.LoadAndValidateFields(ref property);

			spRoadWidth = property.FindPropertyRelative ("roadWidth");
			if (spRoadWidth.floatValue == 0f) {spRoadWidth.floatValue = 1f;} //default to 1 here..
		}

		protected override MantleStyleInterface GetDefaultStyleInterface() {
			return MantleStyle_TransNetworkInterface.GetSystemDefault();
		}


		public override void OnGuiMantleTerrainSubtype_CustomControls(ref Rect position, ref SerializedProperty property, ref GUIContent label) {
			
			Rect currRect = position; currRect.x = mantleStyleRect.x; currRect.y += 16; currRect.width = 64;
			var terrainSubtypeNameRect_Label = new Rect (currRect.x, currRect.y, currRect.width, currRect.height);

			currRect.x +=  currRect.width; currRect.width = 64;
			var terrainSubtypeNameRect_Text = new Rect (currRect.x, currRect.y, currRect.width, currRect.height);
			int totalWidth = (int)(terrainSubtypeNameRect_Text.x + terrainSubtypeNameRect_Text.width - terrainSubtypeNameRect_Label.x) + 16;
			if (mantleStyleRect.width < totalWidth) {
				int leftDisplacement = totalWidth - (int)mantleStyleRect.width;
				terrainSubtypeNameRect_Text.x -=leftDisplacement;
				terrainSubtypeNameRect_Label.x -= leftDisplacement;
			}

			EditorGUI.LabelField(terrainSubtypeNameRect_Label, "Width");
			EditorGUI.PropertyField (terrainSubtypeNameRect_Text, spRoadWidth,  GUIContent.none, true );
			//EditorGUI.Slider (terrainSubtypeNameRect_Text, property.FindPropertyRelative ("roadWidth"), 0.2f, 40f);

		}




		public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
			if (singleLineHeight < 0f) {
				singleLineHeight = base.GetPropertyHeight(property, label);
			}
			return singleLineHeight * 2f;
		}



	}




}


