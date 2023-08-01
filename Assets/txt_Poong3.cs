using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class txt_Poong3 : MonoBehaviour
{
    public TextMeshProUGUI tmp3;

    // public TextMeshProUGUI result_p;

    //public Text gettxt1;

    //public Transform targetObj1;
    //public Vector3 offset;

    public GameObject p3;

    //  public int ppp1;

    TextMeshProUGUI ptext3;




    public int myp3;    //인트값받아올그릇
    //public int myp2;
    //public int myp3;
    //public int myp4;
    //public int myp5;

    // Start is called before the first frame update
    void Start()
    {
        //tmp1 = GetComponent<TextMeshProUGUI>();


        tmp3.text = p3.gameObject.name;
        //print(tmp1.text);
        myp3 = int.Parse(tmp3.text);
        print(myp3);
        tmp3.text = "" + myp3;
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