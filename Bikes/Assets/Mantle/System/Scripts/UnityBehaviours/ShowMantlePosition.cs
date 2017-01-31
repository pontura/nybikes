using UnityEngine;
using System.Collections;
using MantleEngine;

using MantleEngine.PluginComponents;
using MantleEngine.Geographics;


public class ShowMantlePosition : MonoBehaviour {

	public Vector2 LatLngFromTransformPos;
	public Vector3 UnityPosFromLatLng;

	private Vector3 _lastProcessedPos = -Vector3.one;


	void Update () {
	
		if (Mantle.sceneRunning && _lastProcessedPos != transform.position) {

			_lastProcessedPos = transform.position;

			GenericGeoLocation loc = Mantle.ProjectManager.ActiveProject.Geofence.ConvertXYZToLatLng(transform.position);
			LatLngFromTransformPos = loc.ToVector2();

			UnityPosFromLatLng =  Mantle.ProjectManager.ActiveProject.Geofence.ConvertLatLngToXYZ(loc);

		}
	}
}
