using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Poong3 : MonoBehaviour
{
    public Image clearImg;
    public Image defeatImg;

    int coinPlusCount = 0;

    bool iswin; //최종값 성공 여부 확인

    //public GameObject g_over; //게임오버 이미지 뜨게하는 부분 설정

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
                print("실패했습니다");
                LB.gameObject.SetActive(true);
                defeatImg.gameObject.SetActive(true);
                EndGame();

            }
            else
            {
                LB.gameObject.SetActive(true);
                print("성공했습니다");
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
                print("실패했습니다");
                EQ.gameObject.SetActive(true);
                defeatImg.gameObject.SetActive(true);
                EndGame();


            }
            else
            {
                print("성공했습니다");
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
                print("실패했습니다");
                RB.gameObject.SetActive(true);
                defeatImg.gameObject.SetActive(true);
                EndGame();

            }
            else
            {
                print("성공했습니다");
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
