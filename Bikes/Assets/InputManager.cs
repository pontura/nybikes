using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

    private Vector3 lastPos;
    public Vector3 direction;
    public GameObject camera;

	void Start () {
	
	}

    bool ignoreThis;
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            ignoreThis = false;
            if (Input.mousePosition.y < 195) ignoreThis = true;
            if (Input.mousePosition.x > 1700) ignoreThis = true;
            lastPos = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0) && !ignoreThis)
        {
            direction = Input.mousePosition - lastPos;
            lastPos = Input.mousePosition;
            MoveCamera();
        }
        if (Input.GetMouseButtonUp(0))
        {
            lastPos = Vector3.zero;
            direction = lastPos;
            ignoreThis = false;
        }
    }
    void MoveCamera()
    {
        Vector3 pos = camera.transform.localPosition;
        pos.x -= direction.x/3;
        pos.z -= direction.y/3;
        camera.transform.localPosition = pos;
    }
}
