using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Summary : ������ Ǯ�� �����⸦ ���� ��(SLerp)
//          ������ ���� �� �� �̵�
//          ������ ���������� ������
//          ���� ��ġ ���� �������� ��������
//          �����̶�� ���� ī��Ʈ ����
//          �����̶�� ��Ʈ ����
//          ��Ʈ�� ���� �����Ǹ� ���� ����

//          ���� �������� ValueManager ��ũ��Ʈ ��Ȱ��ȭ(�ڷ�ƾ���)
//          ��� �� Ȱ��ȭ�Ͽ� ������ �����

public class BallGameManager : MonoBehaviour
{
    //���� ���� ����
    public static int myAnswer;
    public static int[] myThink = new int[3];
    public static int correctAnswer;

    //ī��Ʈ ����
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
        correctCntText.text = $"���� ���� : {correctCnt} / 3";
        remainCntText.text = $"���� ��ȸ : {remainCnt} / 5";
        clearImg.gameObject.SetActive(false);
        defeatImg.gameObject.SetActive(false);
    }

    //���� ���� �Լ�
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
        //�������� Text ��� �Լ�
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

        //���� ���� �Լ�
        QuestionText.text = $"() + {ValueManager_Ball.ranNum} = {ValueManager_Ball.ranQuestion} �� ��,"
                            + "() = ?";  
    }

    void GetAnswer()
    {
        if (calculate == false && TreshMove.isThrow == true)
        {
            if (myAnswer == correctAnswer)
            {
                correctCnt++;
                correctCntText.text = $"���� ���� : {correctCnt} / 3";
                calculate = true;
            }
            remainCnt--;
            remainCntText.text = $"���� ��ȸ : {remainCnt} / 5";
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

    //���� ����� �ڷ�ƾ
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

            //���� ����Ǹ� ��ư ��Ȱ��ȭ
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

            //���� ����Ǹ� ��ư ��Ȱ��ȭ
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
