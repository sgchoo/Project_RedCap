using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupManager : MonoBehaviour
{
    public GameObject gr1;
    public GameObject gr2;
    public GameObject gr3;
    //public static GameObject[] groups = new GameObject[3];

    AudioSource pangpare;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GrOnOff();
    }

    public void GrOnOff()
    {


        if (Poong.collcount == 3)
        {

            gr1.SetActive(false);
            gr2.SetActive(true);

            pang_sound();

            Poong.collcount = 0;



        }

       


    }


    void pang_sound()
    {
        pangpare = this.GetComponent<AudioSource>();
        pangpare.loop = false;
        pangpare.playOnAwake = false;

        if (pangpare.isPlaying == true) //재생중이면
        {
            pangpare.Stop();   //멈추고
        }
        pangpare.Play();
    }

    //private void OnTriggerEnter(Collider other)
    //{

    //    if (other.gameObject.CompareTag("2Group") && gameObject.CompareTag("Arrow"))
    //    {
    //        print("충돌");
         
    //    }


    //    }

}
