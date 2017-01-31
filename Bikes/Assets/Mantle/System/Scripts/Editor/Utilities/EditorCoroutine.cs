using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;
using UnityEditor;
using Random = UnityEngine.Random;

namespace MantleEngine.PluginComponents 
{

	public class EditorCoroutine
	{

		protected event Mantle.CoroutineStopped onEditorCoroutineStoppedE;

		public static EditorCoroutine start( IEnumerator _routine, Mantle.CoroutineStopped onEditorCoroutineStopped = null )
		{

			EditorCoroutine coroutine = new EditorCoroutine(_routine);
			if (onEditorCoroutineStopped != null) {
				coroutine.onEditorCoroutineStoppedE += onEditorCoroutineStopped;
			}
			coroutine.start();
			return coroutine;
		}
		
		readonly IEnumerator routine;
		EditorCoroutine( IEnumerator _routine )
		{
			routine = _routine;
		}
		
		void start()
		{
			//Debug.Log("start");
			EditorApplication.update += update;
		}
		public void stop()
		{
			//Debug.Log("stop");
			EditorApplication.update -= update;
			//Debug.LogWarning (">>>> EditorCoroutine STOP .");

			//Throw event here to notify listeners of completion..
			if (onEditorCoroutineStoppedE != null) {onEditorCoroutineStoppedE();}
		}
		
		void update()
		{
			if (!routine.MoveNext ()) {
				stop ();
			} else {
				//Debug.LogWarning(">>>> EditorCoroutine update >>>>");
			}
		}
	}
}
