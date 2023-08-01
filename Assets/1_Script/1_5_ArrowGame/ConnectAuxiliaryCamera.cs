using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectAuxiliaryCamera : MonoBehaviour
{
    public Camera mainCamera;
    public int auxiliaryCameraDisplayIndex;

    void Start()
    {
        GameObject auxiliaryCameraObject = new GameObject("Auxiliary Camera");
        Camera auxiliaryCamera = auxiliaryCameraObject.AddComponent<Camera>();
        auxiliaryCamera.targetDisplay = auxiliaryCameraDisplayIndex;
    }
}
