using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageBillboard : MonoBehaviour
{
    public Transform cam;

    private void Awake()
    {
        transform.forward = cam.forward;
    }
}
