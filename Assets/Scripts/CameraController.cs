using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Allows us to set a target for the camera to lock on to
    public Transform Target;
    // Allows us to change position of where the camera sits
    public Vector3 Offset;

    // Update is called once per frame
    void Update()
    {
        // Allows us to set camera position in the inspector
        transform.position = Target.position + Offset;
    }
}
