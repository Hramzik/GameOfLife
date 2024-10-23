
//--------------------------------------------------

using UnityEngine;

//--------------------------------------------------

public class CameraScroll: MonoBehaviour {

    public float scroll_speed = 5f;

    void Update () {

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll == 0) return;

        GetComponent<Camera> ().orthographicSize -= scroll_speed * scroll;
    }
}

//--------------------------------------------------

