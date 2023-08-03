using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CametaTest : MonoBehaviour
{
    public Camera firstPersonCamera;
    public Camera overheadCamera;

    public void ShowOverheadView()
    {
        firstPersonCamera.enabled = false;
        overheadCamera.enabled = true;
    }

    public void ShowFirstPersonView()
    {
        firstPersonCamera.enabled = true;
        overheadCamera.enabled = false;
    }
}
