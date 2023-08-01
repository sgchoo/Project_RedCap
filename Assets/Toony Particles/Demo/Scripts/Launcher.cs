using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    public Rigidbody prefab;
    public float time = 1.50f;
    public float Speed = 5.0f;

    private Rigidbody rb;
    void Start()
    {
        InvokeRepeating("Launch", 1.0f, time);
    }

    void Launch()
    {
        if (prefab) { 
            if(rb == null && gameObject.activeInHierarchy == true)
            {
                rb = Instantiate(prefab, transform.position, transform.rotation);
                rb.velocity = new Vector3(0, 0, Speed);
                rb.transform.SetParent(this.transform);
            }
            
        }
    }
}
