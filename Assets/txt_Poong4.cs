using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class txt_Poong4 : MonoBehaviour
{
    public TextMeshProUGUI tmp4;

    // public TextMeshProUGUI result_p;

    //public Text gettxt1;

    //public Transform targetObj1;
    //public Vector3 offset;

    public GameObject p4;

    //  public int ppp1;

    TextMeshProUGUI ptext4;




    public int myp4;    //인트값받아올그릇
    //public int myp2;
    //public int myp3;
    //public int myp4;
    //public int myp5;

    // Start is called before the first frame update
    void Start()
    {
        //tmp1 = GetComponent<TextMeshProUGUI>();


        tmp4.text = p4.gameObject.name;
        //print(tmp1.text);
        myp4 = int.Parse(tmp4.text);
        print(myp4);
        tmp4.text = "" + myp4;
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
