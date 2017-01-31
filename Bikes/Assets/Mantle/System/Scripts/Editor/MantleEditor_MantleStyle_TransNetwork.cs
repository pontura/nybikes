using UnityEngine;
using UnityEditor;

using System.Collections;

namespace MantleEngine.PluginComponents 
{


	[CustomEditor(typeof(MantleStyle_TransNetworkInterface)),CanEditMultipleObjects]
	public class MantleEditor_MantleStyle_TransNetwork : MantleEditor_MantleStyle {
		

		protected override void DrawInspector (bool includeTerrainFillAndEdge = true,
			bool includeSideMaterial = true, bool singleSideHeight = false, bool forceSideInclusion = false) 
		{
			base.DrawInspector(false, false, true);

			EditorGUILayout.PropertyField(serializedObject.FindProperty("ignoreTunnels"));
			EditorGUILayout.PropertyField(serializedObject.FindProperty("ignoreBridges"));
			EditorGUILayout.PropertyField(serializedObject.FindProperty("BridgeRampLength"));
			EditorList.Show(serializedObject.FindProperty("IntersectionMaterial"), EditorListOption.Buttons_AddRemove | EditorListOption.ListLabel);
			EditorList.Show (serializedObject.FindProperty ("BridgeMaterial"), EditorListOption.Buttons_AddRemove | EditorListOption.ListLabel);

			EditorGUILayout.Separator();
			EditorList.Show(serializedObject.FindProperty("TransportEdging"), EditorListOption.DynaList, "prefab");

			/*
			EditorGUILayout.Separator();
			EditorGUILayout.PropertyField(serializedObject.FindProperty("groundLevelHeight"));
			EditorGUILayout.PropertyField(serializedObject.FindProperty("topLevelHeight"));

			EditorGUILayout.Separator();
			EditorList.Show(serializedObject.FindProperty("GroundLevelCladding"), EditorListOption.DynaList, "prefab");
			EditorGUILayout.Separator();
			EditorList.Show(serializedObject.FindProperty("MidSectionCladding"), EditorListOption.DynaList, "prefab");
			EditorGUILayout.Separator();
			EditorList.Show(serializedObject.FindProperty("TopLevelCladding"), EditorListOption.DynaList, "prefab");
				*/
		}

		protected override void DrawInspectorBottom() {

			if (!MantleUser.isUsingReleaseVersion()) {

				if (GUILayout.Button("Export to Scriptable Object")) {
					MantleMenuManager.CloneMantleStyleInterface<MantleStyle_TransNetworkInterface>((MantleStyle_TransNetworkInterface)target);
				}
			}
		}
			
	}

}


