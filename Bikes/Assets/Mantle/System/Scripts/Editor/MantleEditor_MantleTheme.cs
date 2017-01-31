using UnityEngine;
using UnityEditor;

using System.Collections;
using System;
using MantleEngine.Unity.Editor.Utilities;

namespace MantleEngine.PluginComponents 
{


	[CustomEditor(typeof(MantleThemeInterface)),CanEditMultipleObjects]
	public class MantleEditor_MantleTheme : Editor {
		
		public override void OnInspectorGUI () {

			serializedObject.Update();

			EditorGUILayout.Separator();
			EditorGUILayout.PropertyField(serializedObject.FindProperty("ThemeName"));

			EditorGUILayout.Separator();
			EditorGUILayout.PropertyField(serializedObject.FindProperty("IncludeTerrainFill"));
			EditorGUILayout.PropertyField(serializedObject.FindProperty("IncludeTerrainEdge"));
			EditorGUILayout.PropertyField (serializedObject.FindProperty ("IncludeBuildingCladding"));

			EditorTools.DrawSectionHeader("Landuse");
			EditorList.Show(serializedObject.FindProperty("LandUseToRender"), EditorListOption.Buttons_AddRemove | EditorListOption.ListLabel);
			EditorGUILayout.PropertyField(serializedObject.FindProperty("LanduseTerrain"), new GUIContent ("LandUse Settings"), true);

			EditorTools.DrawSectionHeader("Water");
			EditorList.Show(serializedObject.FindProperty("WaterToRender"), EditorListOption.Buttons_AddRemove | EditorListOption.ListLabel);
			EditorGUILayout.PropertyField(serializedObject.FindProperty("WaterTerrain"), new GUIContent ("Water Settings"), true);

			EditorTools.DrawSectionHeader("Buildings");
			EditorList.Show(serializedObject.FindProperty("BuildingsToRender"), EditorListOption.Buttons_AddRemove | EditorListOption.ListLabel);
			EditorGUILayout.PropertyField(serializedObject.FindProperty("BuildingTerrain"), new GUIContent ("Building Settings"), true);

			EditorTools.DrawSectionHeader("Transport");
			EditorList.Show(serializedObject.FindProperty("TransportToRender"), EditorListOption.Buttons_AddRemove | EditorListOption.Buttons_MoveUpDown | EditorListOption.ListLabel, "Order"); 
			EditorGUILayout.PropertyField(serializedObject.FindProperty("RoadTerrain"), new GUIContent ("Transport Settings"), true);
		
			EditorTools.DrawSectionHeader("Earth");
			EditorList.Show(serializedObject.FindProperty("EarthToRender"), EditorListOption.Buttons_AddRemove | EditorListOption.ListLabel);
			EditorGUILayout.PropertyField(serializedObject.FindProperty("EarthTerrain"), new GUIContent ("Earth Settings"), true);


			EditorGUILayout.Separator();

			if (!MantleUser.isUsingReleaseVersion()) {
				
				if (GUILayout.Button("Export to Scriptable Object")) {
					MantleMenuManager.CloneMantleTheme((MantleThemeInterface)target);
				}
			}

			serializedObject.ApplyModifiedProperties();


		}


	}




}


