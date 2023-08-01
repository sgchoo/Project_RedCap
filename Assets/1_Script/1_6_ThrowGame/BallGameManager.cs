using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Summary : 문제를 풀고 쓰레기를 던진 후(SLerp)
//          정답을 맞춘 후 씬 이동
//          문제는 랜덤값으로 나오며
//          정답 위치 또한 랜덤으로 정해진다
//          정답이라면 정답 카운트 증가
//          오답이라면 하트 차감
//          하트가 전부 차감되면 게임 오버

//          공이 던저지면 ValueManager 스크립트 비활성화(코루틴사용)
//          잠시 뒤 활성화하여 랜덤값 재생성

public class BallGameManager : MonoBehaviour
{
    //정보 관련 변수
    public static int myAnswer;
    public static int[] myThink = new int[3];
    public static int correctAnswer;

    //카운트 변수
    public int correctCnt = 0;
    public int remainCnt = 5;
    int coinPlusCount;


    bool calculate = false;

    public GameObject valueManager;
    public GameObject tresh;
    public Text[] examples = new Text[3];
    public Text QuestionText;
    public Image[] hearts = new Image[5];
    public Text correctCntText;
    public Text remainCntText;

    public Image clearImg;
    public Image defeatImg;

    public Button targetBtn1;
    public Button targetBtn2;
    public Button targetBtn3;

    Vector3 originPos;

    private void Start()
    {
        originPos = tresh.transform.position;
        coinPlusCount = 0;

        UIInit();
    }

    private void Update()
    {
        SetQuestion(ValueManager_Ball.ranNum, ValueManager_Ball.ranQuestion);
        SetTextsandValues();
        GetAnswer();
        BtnState();
        GameState();
    }

    void UIInit()
    {
        correctCntText.text = $"맞춘 갯수 : {correctCnt} / 3";
        remainCntText.text = $"남은 기회 : {remainCnt} / 5";
        clearImg.gameObject.SetActive(false);
        defeatImg.gameObject.SetActive(false);
    }

    //정답 산출 함수
    void SetQuestion(int num, int question)
    {
        for (int i = 0; i < 1000; i++)
        {
            if ((i + num) == question)
            {
                correctAnswer = i;
                //Debug.Log(correctAnswer);
                break;
            }
        }
    }

    void SetTextsandValues()
    {
        //쓰레기통 Text 출력 함수
        examples[ValueManager_Ball.ranPosition].text = "" + correctAnswer;
        myThink[ValueManager_Ball.ranPosition] = correctAnswer;

        for (int j = 0; j < 3; j++)
        {
            if (j != ValueManager_Ball.ranPosition)
            {
                examples[j].text = "" + ValueManager_Ball.ranWrong[j];
                myThink[j] = ValueManager_Ball.ranWrong[j];
            }
        }

        //문제 출제 함수
        QuestionText.text = $"() + {ValueManager_Ball.ranNum} = {ValueManager_Ball.ranQuestion} 일 때,"
                            + "() = ?";  
    }

    void GetAnswer()
    {
        if (calculate == false && TreshMove.isThrow == true)
        {
            if (myAnswer == correctAnswer)
            {
                correctCnt++;
                correctCntText.text = $"맞춘 갯수 : {correctCnt} / 3";
                calculate = true;
            }
            remainCnt--;
            remainCntText.text = $"남은 기회 : {remainCnt} / 5";
            calculate = true;
        }
    }

    void BtnState()
    {
        if (TreshMove.isThrow == true)
        {
            targetBtn1.interactable = false;
            targetBtn2.interactable = false;
            targetBtn3.interactable = false;
            StartCoroutine(ResetValue());
        }

        else
        {
            targetBtn1.interactable = true;
            targetBtn2.interactable = true;
            targetBtn3.interactable = true;
        }
    }

    //변수 재생성 코루틴
    IEnumerator ResetValue()
    {
        yield return null;

        ValueManager_Ball manager = GameObject.Find("ValueManager").GetComponent<ValueManager_Ball>();
        manager.enabled = false;

        yield return new WaitForSeconds(1.5f);
        tresh.GetComponent<TreshMove>().treshTarget = ThrowPosition.Init;
        tresh.transform.position = originPos;
        TreshMove.isThrow = false;
        calculate = false;
        manager.enabled = true;
    }

    void GameState()
    {
        if (correctCnt == 3 && coinPlusCount == 0)
        {
            clearImg.gameObject.SetActive(true);

            //게임 종료되면 버튼 비활성화
            targetBtn1.interactable = false;
            targetBtn2.interactable = false;
            targetBtn3.interactable = false;

            Invoke("GetBackWorld", 3f);

            MainGameManager.coin += 20;
            coinPlusCount++;
        }

        else if (remainCnt == 0)
        {
            defeatImg.gameObject.SetActive(true);

            //게임 종료되면 버튼 비활성화
            targetBtn1.interactable = false;
            targetBtn2.interactable = false;
            targetBtn3.interactable = false;

            Invoke("GetBackWorld", 3f);
        }
    }

    void GetBackWorld()
    {
        SceneManager.LoadScene("LoadingScene");
    }
}
