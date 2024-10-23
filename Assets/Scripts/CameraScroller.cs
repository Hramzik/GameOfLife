
//--------------------------------------------------

using UnityEngine;

//--------------------------------------------------

public class CameraScroll: MonoBehaviour {

    public float scroll_speed = 5f;

    void Update () {

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll == 0) return;

        Vector3 new_position = transform.position;
        new_position.z += scroll * scroll_speed;
        transform.position = new_position;
    }
}

//--------------------------------------------------

