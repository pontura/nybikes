using UnityEngine;
using System.Collections;

public class MainCameraController : MonoBehaviour {

    public float minValue;
    public float maxValue;

    public float anglesMin;
    public float anglesMax;

    void Start()
    {

    }
    public void SetNewZoomValue(float value)
    {
        float newZoomvalue = 0;
        newZoomvalue = ((maxValue - minValue)* value) + minValue;

        Vector3 pos = transform.position;
        pos.y = newZoomvalue;
        transform.position = pos;

        Vector3 rot = transform.localEulerAngles;
        if(value<0.3f)
            rot.x = anglesMin - (0.3f-value)*100;
        transform.localEulerAngles = rot;
    }
}
