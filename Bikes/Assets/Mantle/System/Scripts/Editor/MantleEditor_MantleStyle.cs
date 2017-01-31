using UnityEngine;
using UnityEditor;

using System.Collections;

namespace MantleEngine.PluginComponents 
{


	[CustomEditor(typeof(MantleStyleInterface)),CanEditMultipleObjects]
	public class MantleEditor_MantleStyle : Editor {

		private bool singleSideHeight = false;

		public override void OnInspectorGUI () {

			serializedObject.Update();

			DrawInspector();

			DrawInspectorBottom();

			serializedObject.ApplyModifiedProperties();
			if (singleSideHeight)
				serializedObject.FindProperty ("maxSideHeight").floatValue = serializedObject.FindProperty ("minSideHeight").floatValue;
		}

		protected virtual void DrawInspector(bool includeTerrainFillAndEdge = true,
			bool includeSideMaterial = true, bool singleSideHeight = false, bool forceSideInclusion = false) 
		{
			this.singleSideHeight = singleSideHeight;

			//<header from attribute in class is put here>
			EditorGUILayout.Separator();
			EditorList.Show(serializedObject.FindProperty("TopMaterial"), EditorListOption.Buttons_AddRemove | EditorListOption.ListLabel);
			EditorGUILayout.PropertyField(serializedObject.FindProperty("topUvMethod"));

			EditorGUILayout.Separator ();

			SerializedProperty property_includeSides = serializedObject.FindProperty ("includeSides");

			if (!forceSideInclusion) {
				EditorGUILayout.PropertyField (property_includeSides);
			}

			if (forceSideInclusion || property_includeSides.boolValue == true) {
				

				if (includeSideMaterial)
				{
					EditorList.Show (serializedObject.FindProperty ("SideMaterial"), EditorListOption.Buttons_AddRemove | EditorListOption.ListLabel);
					EditorGUILayout.PropertyField (serializedObject.FindProperty ("sideUvMethod"));
				}

				SerializedProperty sp_minSideHeight = serializedObject.FindProperty("minSideHeight");
				SerializedProperty sp_maxSideHeight = serializedObject.FindProperty("maxSideHeight");
				if (sp_maxSideHeight.floatValue == -1f && sp_minSideHeight.floatValue == -1f) {
					float defaultSideHeight = serializedObject.FindProperty("defaultSideHeight").floatValue;
					sp_minSideHeight.floatValue = sp_maxSideHeight.floatValue = defaultSideHeight;
				}

				string label = singleSideHeight ? "Side Height" : "Min Side Height";
				EditorGUILayout.PropertyField(sp_minSideHeight, new GUIContent(label), null);

				if (!singleSideHeight)
					EditorGUILayout.PropertyField(sp_maxSideHeight);

				//SerializedProperty spUseDefaultSideHeight = serializedObject.FindProperty("lockHeightToDefaultSideHeight");
				//EditorGUILayout.PropertyField(spUseDefaultSideHeight);
			}

			if (Mantle.ReleaseType != Mantle.ReleaseBuildType.UnityAssetStore) {
			//EditorGUILayout.HelpBox("Image Overlay is ignored if not set in Mante Datasource.", MessageType.Info);
				EditorGUILayout.PropertyField(serializedObject.FindProperty("imageOverlayMethod"));
			}



			//<header from attribute in class is put here>
			EditorGUILayout.Separator();
			SerializedProperty _pBypassSmallAreas = serializedObject.FindProperty("bypassSmallAreas");
			EditorGUILayout.PropertyField(_pBypassSmallAreas);
			if (_pBypassSmallAreas.boolValue) {
				EditorGUILayout.PropertyField(serializedObject.FindProperty("minAreaToFillSqrMeters"));
			}
			if (includeTerrainFillAndEdge) {
				EditorList.Show(serializedObject.FindProperty("TerrainFill"), EditorListOption.DynaList, "prefab");

				EditorGUILayout.Separator();
				EditorList.Show(serializedObject.FindProperty("TerrainEdge"), EditorListOption.DynaList, "prefab");
			}


		}

		protected virtual void DrawInspectorBottom() {

			if (!MantleUser.isUsingReleaseVersion()) {

				if (GUILayout.Button("Export as MantleStyleInterface")) {
					MantleMenuManager.CloneMantleStyleInterface<MantleStyleInterface>((MantleStyleInterface)target);
				}
				if (GUILayout.Button("Export as MantleStyle_TransNetworkInterface")) {
					MantleMenuManager.CloneMantleStyleInterface<MantleStyle_TransNetworkInterface>((MantleStyleInterface)target);
				}
			}
		}


	}




}


