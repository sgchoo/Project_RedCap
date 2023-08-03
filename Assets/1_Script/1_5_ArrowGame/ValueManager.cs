using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueManager : MonoBehaviour
{
    //값 대입 변수
    public static int myInt1;
    public static int myInt2;
    public static int myInt3;


    


    //public static GameObject gr2;

    //합산 값 함수
    public static int left_sic;

    public static int Calc()
    {
        left_sic = myInt1 + myInt2 + myInt3;

        return left_sic;
    }

    //void findGr2()
    //{
    //    gr2 = GameObject.Find("2Group");
    //}


   
}
