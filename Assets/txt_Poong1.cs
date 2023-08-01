using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class txt_Poong1 : MonoBehaviour
{
    public TextMeshProUGUI tmp1;

   // public TextMeshProUGUI result_p;

    //public Text gettxt1;

    //public Transform targetObj1;
    //public Vector3 offset;

    public GameObject p1;
   
    //  public int ppp1;

    TextMeshProUGUI ptext1;




    public int myp1;    //인트값받아올그릇
    //public int myp2;
    //public int myp3;
    //public int myp4;
    //public int myp5;

    // Start is called before the first frame update
    void Start()
    {
        //tmp1 = GetComponent<TextMeshProUGUI>();


        tmp1.text = p1.gameObject.name;
        //print(tmp1.text);
        myp1 = int.Parse(tmp1.text);
        print(myp1);
        tmp1.text = "" + myp1;
        //ptext1 = GetComponent<TextMeshProUGUI>();
     

        //print(gameObject.name);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = targetObj1.position + offset;
    }



    //Text poong1 = GameObject.Find("txt_Num1").GetComponent<Text>();
    //poong1.text = gameObject.name; // 텍스트형
    //        ValueManager.myInt1 = int.Parse(poong1.text); // 인트형
    //Debug.Log(ValueManager.myInt1);
}
