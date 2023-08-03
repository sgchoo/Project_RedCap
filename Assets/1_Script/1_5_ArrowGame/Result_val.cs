using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result_val : MonoBehaviour
{
    //Text result_val1;
    //public Text result_val2;
    //public Text result_val3;
    //public Text result_val4;

    //public int aa = 6;
    //public int bb = 9;
    //public int cc = 15;
    //public int dd = 20;




    //private void Awake()
    //{
    //    int aa = 6;
    //    gameObject.name = aa.ToString();
    //}
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
        //    print("충돌함");

        //}

        Destroy(this.gameObject);


        if (Poong.collcount == 1)
        {
            ////Text result_val1 = GameObject.Find("txt2_Num1").GetComponent<Text>();
            //// result_val1.text = gameObject.name; // 텍스트형
            //if(result_val1 == 6)
            //{
            //    Text result_val1 = GameObject.Find("txt2_Num1").GetComponent<Text>();
            //    Debug.Log(result_val1);
            //}
            
            //else if (bb == 9)
            //{
            //    Debug.Log(bb);
            //}

            //else if (cc == 15)
            //{
            //    Debug.Log(cc);
            //}

            //else if (dd == 20)
            //{
            //    Debug.Log(dd);
            //}
            // print(result_val1);






        }

        //else if (collcount2 == 2)
        //{
        //    Text poong2 = GameObject.Find("txt_Num2").GetComponent<Text>();
        //    poong2.text = gameObject.name;
        //    ValueManager.myInt2 = int.Parse(poong2.text); // 인트형
        //    Debug.Log(ValueManager.myInt2);
        //}

        //else if (collcount2 == 3)
        //{
        //    Text poong3 = GameObject.Find("txt_Num3").GetComponent<Text>();
        //    poong3.text = gameObject.name;
        //    ValueManager.myInt3 = int.Parse(poong3.text);


        //}
    }
}
