using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Textbillboard : MonoBehaviour
{
    public GameObject cam;
    private void Start()
    {
       
    }

    private void LateUpdate()
    {
        if (cam != null)
        {
            transform.LookAt(cam.transform);
            transform.Rotate(0, 180, 0);
        }
    }
}
