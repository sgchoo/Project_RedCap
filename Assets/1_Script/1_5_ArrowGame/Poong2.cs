using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//public enum value
//{
//    val1,val2,val3,val4
//}

public class Poong2 : MonoBehaviour
{

    public Text result_value;

    public static int value;
    //int value2;
    //int value3;
    //int value4;


    public GameObject poong2_1;
    public GameObject poong2_2;
    public GameObject poong2_3;
    public GameObject poong2_4;

    //value myval;

    public GameObject group3On;

    public GameObject temp_pangpare;




    void Start()
    {

    }



    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        //if (other.CompareTag("Arrow"))
        //{
        //    print("Ãæµ¹ÇÔ");

        //}

        Destroy(this.gameObject);

        //if (Poong.collcount == 1)
        //{

        //    switch (myval)
        //    {
        //        case (value.val1):
        //            print(val1);

        //        break;
        //    }
        //}


        if (gameObject.name == "Sphere6")
        {
            Group3Onplz();
            //Invoke("Group3Onplz()", 0.3f);
            value = 6;

            //Text result_value = GameObject.Find("txt2_Num1").GetComponent<Text>();

            result_value.text = "" + value;
            Destroy(poong2_2);
            Destroy(poong2_3);
            Destroy(poong2_4);

            Poong.collcount = 0;


        }

        else if (gameObject.name == "Sphere9")
        {
            Group3Onplz();
            //Invoke("Group3Onplz()", 0.3f);
            value = 9;
            result_value.text = "" + value;
            Destroy(poong2_1);
            Destroy(poong2_3);
            Destroy(poong2_4);

            Poong.collcount = 0;
        }

        else if (gameObject.name == "Sphere15")
        {
            Group3Onplz();
            // Invoke("Group3Onplz()", 0.3f);
            value = 15;
            result_value.text = "" + value;
            Destroy(poong2_1);
            Destroy(poong2_2);
            Destroy(poong2_4);

            Poong.collcount = 0;
        }



        else if (gameObject.name == "Sphere20")
        {
            Group3Onplz();
            //  Invoke("Group3Onplz()", 0.3f);
            value = 20;
            result_value.text = "" + value;
            Destroy(poong2_1);
            Destroy(poong2_2);
            Destroy(poong2_3);

            Poong.collcount = 0;
        }




    }


    void Group3Onplz()
    {
        group3On.SetActive(true);

        temp_pangpare.SetActive(true);


    }


}
        
