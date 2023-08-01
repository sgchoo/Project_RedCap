using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testsmoke : MonoBehaviour
{
    public ParticleSystem smoke;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //smoke.Play();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Smoke")
            //print("Ãâ·Â");
            smoke.Play();
    }


    

}
