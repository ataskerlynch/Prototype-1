using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    public Camera mainCamera;
    public Camera windscreenCamera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            // Toggle the active state of the cameras.
            mainCamera.enabled = !mainCamera.enabled;
            windscreenCamera.enabled = !windscreenCamera.enabled;
        }
    }
}
