using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Poong3 : MonoBehaviour
{
    public Image clearImg;
    public Image defeatImg;

    int coinPlusCount = 0;

    bool iswin; //������ ���� ���� Ȯ��

    //public GameObject g_over; //���ӿ��� �̹��� �߰��ϴ� �κ� ����

    public RawImage RB;
    public RawImage LB;
    public RawImage EQ;

    void Start()
    {

    }

  
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        

        Destroy(this.gameObject);

        int tot_leftsic = ValueManager.Calc();
        //print(tot_leftsic);

        int tot_rightsic = Poong2.value;
        //print(tot_rightsic);

        if (gameObject.name == "leftbig")
        {


            iswin = tot_leftsic > tot_rightsic;
            print(iswin);
           
            if (iswin == false)
            {
                print("�����߽��ϴ�");
                LB.gameObject.SetActive(true);
                defeatImg.gameObject.SetActive(true);
                EndGame();

            }
            else
            {
                LB.gameObject.SetActive(true);
                print("�����߽��ϴ�");
                clearImg.gameObject.SetActive(true);
                EndGame();
                if (coinPlusCount == 0)
                {


                    MainGameManager.coin += 20;
                    coinPlusCount++;
                }


            }

        }

        else if (gameObject.name == "equal")
        {

            iswin = tot_leftsic == tot_rightsic;
            print(iswin);

            if (iswin == false)
            {
                print("�����߽��ϴ�");
                EQ.gameObject.SetActive(true);
                defeatImg.gameObject.SetActive(true);
                EndGame();


            }
            else
            {
                print("�����߽��ϴ�");
                EQ.gameObject.SetActive(true);
                clearImg.gameObject.SetActive(true);
                EndGame();
                if (coinPlusCount == 0)
                {


                    MainGameManager.coin += 20;
                    coinPlusCount++;
                }


            }
        }

        else if (gameObject.name == "rightbig")
        {

            iswin = tot_leftsic < tot_rightsic;
            print(iswin);

            if (iswin == false)
            {
                print("�����߽��ϴ�");
                RB.gameObject.SetActive(true);
                defeatImg.gameObject.SetActive(true);
                EndGame();

            }
            else
            {
                print("�����߽��ϴ�");
                RB.gameObject.SetActive(true);
                clearImg.gameObject.SetActive(true);
                EndGame();
                if (coinPlusCount == 0)
                {


                    MainGameManager.coin += 20;
                    coinPlusCount++;
                }


            }
        }

    


        }

    void EndGame()
    {
        //Time.timeScale = 0f;
        //g_over.SetActive(true);
    }
            


    
}
