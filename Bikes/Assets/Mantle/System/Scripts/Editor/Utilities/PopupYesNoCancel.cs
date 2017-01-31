using UnityEngine;
using UnityEditor;

public class PopupYesNoCancel : EditorWindow
{
	public delegate void OnButtonSelected();
	private  event OnButtonSelected onYesButtonSelected;

	private bool isInit = false;
	private string _body = "Set this content via the Init() function.";

	public void Init(string title, string body, OnButtonSelected yesDelegate) {
		
		this.titleContent = new GUIContent(title);
		_body = body;

		if (position == default(Rect)) {
			position = new Rect(Screen.width / 2, Screen.height / 2, 250, 150);
		}
		this.position = position;

		onYesButtonSelected = yesDelegate;

		this.ShowUtility();


	}

	void Init()
	{
		

		isInit = true;
	}

	void OnGUI()
	{
		if (!isInit) {Init();}
		GUILayout.Space(10);
		EditorGUILayout.LabelField(_body,EditorStyles.wordWrappedLabel);
		GUILayout.Space(20);
		if (GUILayout.Button("Yes")) {
			if (onYesButtonSelected != null) {onYesButtonSelected();}
			this.Close();
		}
		if (GUILayout.Button("No")) this.Close();
		if (GUILayout.Button("Cancel")) this.Close();
	}
}