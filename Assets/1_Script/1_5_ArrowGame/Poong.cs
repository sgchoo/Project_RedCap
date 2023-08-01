using UnityEngine;
using UnityEngine.UI;

public class Poong : MonoBehaviour
{

   

    public int minValue = 1; // 랜덤 값의 최소값
    public int maxValue = 10; // 랜덤 값의 최대값

    Text poong1;
    Text poong2;
    Text poong3;

    //GameObject myGameobj = GameObject.Find("Cube");


    public static int collcount;

    public void Awake()
    {
        int randomNumber = Random.Range(minValue, maxValue); // 랜덤 숫자 생성
        gameObject.name = randomNumber.ToString(); // 객체의 이름에 랜덤 숫자 할당
      


    }

    private void Start()
    {
        collcount = 0;
        //myGameobj.SetActive(false);
    }

  


    public void OnTriggerEnter(Collider other)
    {
        //if (other.CompareTag("Arrow"))
        //{
        //    print("충돌함");

        //}

        Destroy(this.gameObject);
        

        if (collcount == 1)
        {
            Text poong1 = GameObject.Find("txt_Num1").GetComponent<Text>();
            poong1.text = gameObject.name; // 텍스트형
            ValueManager.myInt1 = int.Parse(poong1.text); // 인트형
            Debug.Log(ValueManager.myInt1);
            



            //print(myGameobj);
            //myGameobj.SetActive(true);

            //코드안됨 애로우에서 시도


        }

        else if (collcount == 2)
        {
            Text poong2 = GameObject.Find("txt_Num2").GetComponent<Text>();
            poong2.text = gameObject.name;
            ValueManager.myInt2 = int.Parse(poong2.text); // 인트형
            Debug.Log(ValueManager.myInt2);
            
        }

        else if (collcount == 3)
        {
            Text poong3 = GameObject.Find("txt_Num3").GetComponent<Text>();
            poong3.text = gameObject.name;
            ValueManager.myInt3 = int.Parse(poong3.text);
            

            //GameObject.Find("1Group").SetActive(false);



            //Debug.Log(ValueManager.myInt3);

            //Text result = GameObject.Find("txt_Num4").GetComponent<Text>();  /* 합계 텍스트를 받고 출력하는 코드부분
            //ValueManager.Calc();
            //result.text = ValueManager.Calc().ToString();

            //Debug.Log(ValueManager.Calc());                                   */
        }





        //else if (collcount == 4)
        //{
            
        //}
        
    }
}
