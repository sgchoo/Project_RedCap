using UnityEngine;
using UnityEngine.UI;

public class Poong : MonoBehaviour
{

   

    public int minValue = 1; // ���� ���� �ּҰ�
    public int maxValue = 10; // ���� ���� �ִ밪

    Text poong1;
    Text poong2;
    Text poong3;

    //GameObject myGameobj = GameObject.Find("Cube");


    public static int collcount;

    public void Awake()
    {
        int randomNumber = Random.Range(minValue, maxValue); // ���� ���� ����
        gameObject.name = randomNumber.ToString(); // ��ü�� �̸��� ���� ���� �Ҵ�
      


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
        //    print("�浹��");

        //}

        Destroy(this.gameObject);
        

        if (collcount == 1)
        {
            Text poong1 = GameObject.Find("txt_Num1").GetComponent<Text>();
            poong1.text = gameObject.name; // �ؽ�Ʈ��
            ValueManager.myInt1 = int.Parse(poong1.text); // ��Ʈ��
            Debug.Log(ValueManager.myInt1);
            



            //print(myGameobj);
            //myGameobj.SetActive(true);

            //�ڵ�ȵ� �ַο쿡�� �õ�


        }

        else if (collcount == 2)
        {
            Text poong2 = GameObject.Find("txt_Num2").GetComponent<Text>();
            poong2.text = gameObject.name;
            ValueManager.myInt2 = int.Parse(poong2.text); // ��Ʈ��
            Debug.Log(ValueManager.myInt2);
            
        }

        else if (collcount == 3)
        {
            Text poong3 = GameObject.Find("txt_Num3").GetComponent<Text>();
            poong3.text = gameObject.name;
            ValueManager.myInt3 = int.Parse(poong3.text);
            

            //GameObject.Find("1Group").SetActive(false);



            //Debug.Log(ValueManager.myInt3);

            //Text result = GameObject.Find("txt_Num4").GetComponent<Text>();  /* �հ� �ؽ�Ʈ�� �ް� ����ϴ� �ڵ�κ�
            //ValueManager.Calc();
            //result.text = ValueManager.Calc().ToString();

            //Debug.Log(ValueManager.Calc());                                   */
        }





        //else if (collcount == 4)
        //{
            
        //}
        
    }
}
