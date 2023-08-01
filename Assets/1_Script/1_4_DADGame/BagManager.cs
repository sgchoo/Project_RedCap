using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BagManager : MonoBehaviour
{

    public int blueCount;
    public int greenCount;
    public int redCount;
    public int Life = 3;
    int goodPoint = 0;
    bool mistake = false;
    int coinPlusCount;

    public Text BlueRanNum;
    public Text GreenRanNum;
    public Text RedRanNum;
    public Text CorrectScore;
    public Text LifeExplain;


    public Image Life1;
    public Image Life2;
    public Image Life3;

    public Image gameClear;
    public Image gameOver;

    // Start is called before the first frame update
    void Start()
    {
        coinPlusCount = 0;
        blueCount = Random.Range(1, 4);
        greenCount = Random.Range(1, 4);
        redCount = Random.Range(1, 4);
        BlueRanNum.text = "X " + blueCount.ToString();
        RedRanNum.text = " X " + redCount.ToString();
        GreenRanNum.text = " X " + greenCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        AllMistake();
        All100();
        CorrectScore.text = "���� Ƚ�� : " + goodPoint.ToString();
        LifeExplain.text = "���� ��ȸ : " + Life.ToString();


    }
    void AllMistake()
    {
        if (mistake == true && Life == 3)
        {
            Life1.gameObject.SetActive(false);
            Life = 2;
            blueCount = Random.Range(1, 4);
            greenCount = Random.Range(1, 4);
            redCount = Random.Range(1, 4);
            BlueRanNum.text = "X " + blueCount.ToString();
            RedRanNum.text = " X " + redCount.ToString();
            GreenRanNum.text = " X " + greenCount.ToString();
            mistake = false;


        }
        if (mistake == true && Life == 2)
        {
            Life2.gameObject.SetActive(false);
            Life = 1;
            blueCount = Random.Range(1, 4);
            greenCount = Random.Range(1, 4);
            redCount = Random.Range(1, 4);
            BlueRanNum.text = "X " + blueCount.ToString();
            RedRanNum.text = " X " + redCount.ToString();
            GreenRanNum.text = " X " + greenCount.ToString();
            mistake = false;


        }
        if (mistake == true && Life == 1)
        {
            Life3.gameObject.SetActive(false);
            Life = 0;
            blueCount = Random.Range(1, 4);
            greenCount = Random.Range(1, 4);
            redCount = Random.Range(1, 4);
            BlueRanNum.text = "X " + blueCount.ToString();
            RedRanNum.text = " X " + redCount.ToString();
            GreenRanNum.text = " X " + greenCount.ToString();


        }
        if (mistake == true && Life == 0)
        {
            gameOver.gameObject.SetActive(true);     //���� ����

            //3�� �� �� �ѱ��
            Invoke("BackMainScene", 3f);
        }
    }


    void All100()
    {
        if(blueCount == 0 && redCount == 0 && greenCount == 0 && goodPoint == 0)
        {
            blueCount = Random.Range(1, 4);
            greenCount = Random.Range(1, 4);
            redCount = Random.Range(1, 4);
            BlueRanNum.text = "X " + blueCount.ToString();
            RedRanNum.text = " X " + redCount.ToString();
            GreenRanNum.text = " X " + greenCount.ToString();
            goodPoint++;


        }
        if (blueCount == 0 && redCount == 0 && greenCount == 0 && goodPoint == 1)
        {
            blueCount = Random.Range(1, 4);
            greenCount = Random.Range(1, 4);
            redCount = Random.Range(1, 4);
            BlueRanNum.text = "X " + blueCount.ToString();
            RedRanNum.text = " X " + redCount.ToString();
            GreenRanNum.text = " X " + greenCount.ToString();            
            goodPoint++;


        }
        if (blueCount == 0 && redCount == 0 && greenCount == 0 && goodPoint == 2)
        {
            blueCount = Random.Range(1, 4);
            greenCount = Random.Range(1, 4);
            redCount = Random.Range(1, 4);
            BlueRanNum.text = "X " + blueCount.ToString();
            RedRanNum.text = " X " + redCount.ToString();
            GreenRanNum.text = " X " + greenCount.ToString();
            goodPoint++;


        }
        if (goodPoint == 3 && coinPlusCount == 0)
        {
                
            MainGameManager.coin += 20;
            coinPlusCount++;
            gameClear.gameObject.SetActive(true);     //���� Ŭ����

            //3�� �� �� �ѱ��
            Invoke("BackMainScene", 3f);
        }
    }

    //�κ�ũ ����� �� �ѱ�� �Լ�
    void BackMainScene()
    {
        SceneManager.LoadScene("LoadingScene");
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "BlueBall")
        {
            blueCount--;
            if(blueCount < 0)
            {
                mistake = true;
            }
        }
        else if(other.gameObject.tag == "GreenBall")
        {
            greenCount--;
            if (greenCount < 0)
            {
                mistake = true;
            }

        }
        else if(other.gameObject.tag == "RedBall")
        {
            redCount--;
            if (redCount < 0)
            {
                mistake = true;
            }
        }
    }
}
