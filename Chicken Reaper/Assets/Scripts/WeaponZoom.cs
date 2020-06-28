using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera playerCamera;
    [SerializeField] RigidbodyFirstPersonController fpsController;
    [SerializeField] float zoomedInFOV = 25f;
    [SerializeField] float zoomedOutFOV = 60f;
    [SerializeField] float zoomedInSensitivity = 0.75f;
    [SerializeField] float zoomedOutSensitivity = 3f;

    private void OnDisable()
    {
        fpsController.mouseLook.XSensitivity = zoomedOutSensitivity;
        fpsController.mouseLook.YSensitivity = zoomedOutSensitivity;
        playerCamera.fieldOfView = zoomedOutFOV;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(1))
        {           
            fpsController.mouseLook.XSensitivity = zoomedInSensitivity;
            fpsController.mouseLook.YSensitivity = zoomedInSensitivity;
            playerCamera.fieldOfView = zoomedInFOV;
        }

        else
        {
            fpsController.mouseLook.XSensitivity = zoomedOutSensitivity;
            fpsController.mouseLook.YSensitivity = zoomedOutSensitivity;
            playerCamera.fieldOfView = zoomedOutFOV;
        }
    }
}
