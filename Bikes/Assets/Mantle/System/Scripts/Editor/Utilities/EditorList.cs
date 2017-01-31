using UnityEditor;
using UnityEngine;
using System;


namespace MantleEngine.PluginComponents {
		
	[Flags]
	public enum EditorListOption {
		None = 0,
		ListSize = 1,
		ListLabel = 2,
		ElementLabels = 4,
		Buttons_AddRemove = 8,
		Buttons_MoveUpDown = 16,
		DynaList = Buttons_AddRemove | ListLabel | ElementLabels | Buttons_MoveUpDown,
		Default = ListSize | ListLabel | ElementLabels,
		NoElementLabels = ListSize | ListLabel,
		All = Default | Buttons_AddRemove
	}

	public static class EditorList {

		private static GUIContent
			moveButtonDownContent = new GUIContent("\u2193", "move down"),
			moveButtonUpContent = new GUIContent("\u2191", "up down"),
			duplicateButtonContent = new GUIContent("+", "duplicate"),
			deleteButtonContent = new GUIContent("-", "delete"),
			addButtonContent = new GUIContent("+", "add element");

		private static GUILayoutOption miniButtonWidth = GUILayout.Width(20f);

		public static void Show (SerializedProperty list, EditorListOption options = EditorListOption.Default, string labelOverride = "") {

			if (!list.isArray) {
				EditorGUILayout.HelpBox(list.name + " is neither an array nor a list!", MessageType.Error);
				return;
			}

			bool
				showListLabel = (options & EditorListOption.ListLabel) != 0,
				showListSize = (options & EditorListOption.ListSize) != 0;

			if (showListLabel) {
				EditorGUILayout.PropertyField(list);
				EditorGUI.indentLevel += 1;
			}
			if (!showListLabel || list.isExpanded) {
				SerializedProperty size = list.FindPropertyRelative("Array.size");
				if (showListSize) {
					EditorGUILayout.PropertyField(size);
				}
				if (size.hasMultipleDifferentValues) {
					EditorGUILayout.HelpBox("Not showing lists with different sizes.", MessageType.Info);
				}
				else {
					ShowElements(list, options, labelOverride);
				}
			}

			if (showListLabel) {
				EditorGUI.indentLevel -= 1;
			}

		}

		private static void ShowElements (SerializedProperty list, EditorListOption options,  string labelProperty = "" ) {

			bool
				showElementLabels = (options & EditorListOption.ElementLabels) != 0,
				showButtons = (options & EditorListOption.Buttons_AddRemove) != 0 || (options & EditorListOption.Buttons_MoveUpDown) != 0 ;

			for (int i = 0; i < list.arraySize; i++) {
				SerializedProperty elem = list.GetArrayElementAtIndex(i);
				string labelPropertyDescription = labelProperty;

				if (showButtons) {
					EditorGUILayout.BeginHorizontal();
				}
				if (showElementLabels) {
					if (labelProperty == "") {
						labelPropertyDescription = "Element " + i + "  ";
					} else {
						SerializedProperty it = elem.Copy ();
						while (it.Next (true)) { // or NextVisible, also, the bool argument specifies whether to enter on children or not
							if (it.name == labelProperty) {
								if (it.objectReferenceValue != null) {
									labelPropertyDescription = i + ") " + it.objectReferenceValue.ToString();
								} else {
									labelPropertyDescription = i + ") New " + labelProperty;
								}
								break;
							}
						}
					}
					
					EditorGUILayout.PropertyField(elem, new GUIContent (labelPropertyDescription), elem.hasChildren);

				}
				else {
					EditorGUILayout.PropertyField(elem, GUIContent.none, elem.hasChildren);
				}
				if (showButtons) {
					ShowButtons(list, i, options);
					EditorGUILayout.EndHorizontal();
				}
			}

			// show the  large button if no elements yet exist..
			if (showButtons && list.arraySize == 0 && GUILayout.Button(addButtonContent, EditorStyles.miniButton)) {
				list.arraySize += 1;
				list.GetArrayElementAtIndex(list.arraySize-1).isExpanded = true;
			}
		}

		private static void ShowButtons (SerializedProperty list, int index, EditorListOption options) {

			bool
				showButtons_AddRemove = (options & EditorListOption.Buttons_AddRemove) != 0 ,
				showButtons_MoveUpDown = (options & EditorListOption.Buttons_MoveUpDown) != 0;
				
			if (showButtons_MoveUpDown) {
				if (GUILayout.Button(moveButtonUpContent, EditorStyles.miniButtonLeft, miniButtonWidth)) {
					list.MoveArrayElement(index, index - 1);
				}
				if (GUILayout.Button(moveButtonDownContent, EditorStyles.miniButtonMid, miniButtonWidth)) {
					list.MoveArrayElement(index, index + 1);
				}
			}
				
			if (showButtons_AddRemove) {
				if (GUILayout.Button(duplicateButtonContent, EditorStyles.miniButtonMid, miniButtonWidth)) {
					list.InsertArrayElementAtIndex(index);
					list.GetArrayElementAtIndex(index).isExpanded = true;
					//Debug.Log(elem.ToString());
				}
				if (GUILayout.Button(deleteButtonContent, EditorStyles.miniButtonRight, miniButtonWidth)) {
					int oldSize = list.arraySize;
					list.DeleteArrayElementAtIndex(index);
					if (list.arraySize == oldSize) {
						list.DeleteArrayElementAtIndex(index);
					}
				}
			}
		}
	}

}