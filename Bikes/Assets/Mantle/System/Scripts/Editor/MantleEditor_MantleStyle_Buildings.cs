using UnityEngine;
using UnityEditor;

using System.Collections;

namespace MantleEngine.PluginComponents 
{


	[CustomEditor(typeof(MantleStyle_BuildingsInterface)),CanEditMultipleObjects]
	public class MantleEditor_MantleStyle_Buildings : MantleEditor_MantleStyle {
		

		protected override void DrawInspector (bool includeTerrainFillAndEdge = true,
			bool includeSideMaterial = true, bool singleSideHeight = false, bool forceSideInclusion = false) {

			base.DrawInspector(includeTerrainFillAndEdge, forceSideInclusion: true);

			EditorGUILayout.Separator();
			EditorGUILayout.PropertyField(serializedObject.FindProperty("ignoreRealBuildingHeights"));

			EditorGUILayout.Separator();
			EditorGUILayout.PropertyField(serializedObject.FindProperty("groundLevelHeight"));
			EditorGUILayout.PropertyField(serializedObject.FindProperty("topLevelHeight"));

			EditorGUILayout.Separator();
			EditorList.Show(serializedObject.FindProperty("GroundLevelCladding"), EditorListOption.DynaList, "prefab");
			EditorGUILayout.Separator();
			EditorList.Show(serializedObject.FindProperty("MidSectionCladding"), EditorListOption.DynaList, "prefab");
			EditorGUILayout.Separator();
			EditorList.Show(serializedObject.FindProperty("TopLevelCladding"), EditorListOption.DynaList, "prefab");

				
		}

		protected override void DrawInspectorBottom() {

			if (!MantleUser.isUsingReleaseVersion()) {

				if (GUILayout.Button("Export to Scriptable Object")) {
					MantleMenuManager.CloneMantleStyleInterface<MantleStyle_BuildingsInterface>((MantleStyle_BuildingsInterface)target);
				}
			}
		}
			
	}

}


