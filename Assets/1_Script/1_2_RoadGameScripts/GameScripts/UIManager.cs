using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Summary : �� �� �� �Ʒ���ư�� ������ �̵� ī���� �Ѱ��� ���� - ok
//          ȸ�� ���� �� ȸ�� ī���� ���� - ok


public class UIManager : MonoBehaviour
{
    public GameObject rGM;

    public Button moveBtn;
    public Button leftBtn;
    public Button rightBtn;
    public Text moveCntText;
    public Text rotCntText;

    private void Start()
    {
        ButtonAndTextInit();
    }

    private void Update()
    {
        ButtonCheck();
    }

    void ButtonAndTextInit()
    {
        moveBtn.interactable = true;
        leftBtn.interactable = true;
        rightBtn.interactable = true;

        

        switch (MainGameManager.doneCount)
        {
            case 0:
                moveCntText.text = "�̵� Ƚ�� : " + RoadGameManager.moveCount;
                rotCntText.text = "ȸ�� Ƚ�� : " + RoadGameManager.rotCount;
                break;

            case 1:
                moveCntText.text = "�̵� Ƚ�� : " + RoadGameManager.moveCount2;
                rotCntText.text = "ȸ�� Ƚ�� : " + RoadGameManager.rotCount2;
                break;

            case 2:
                moveCntText.text = "�̵� Ƚ�� : " + RoadGameManager.moveCount3;
                rotCntText.text = "ȸ�� Ƚ�� : " + RoadGameManager.rotCount3;
                break;
        }
    }

    void ButtonCheck()
    {
        //���� ī��Ʈ üũ
        if (RoadGameManager.moveCount == 0 ||
            RoadGameManager.moveCount2 == 0 ||
            RoadGameManager.moveCount3 == 0)
        {
            moveBtn.interactable = false;
        }
        else
        {
            moveBtn.interactable = true;
        }

        //ȸ�� ī��Ʈ üũ
        if (RoadGameManager.rotCount == 0 ||
            RoadGameManager.rotCount2 == 0 ||
            RoadGameManager.rotCount3 == 0)
        {
            leftBtn.interactable = false;
            leftBtn.transform.GetChild(0).gameObject.SetActive(false);

            rightBtn.interactable = false;
        }
        else
        {
            leftBtn.interactable = true;
            leftBtn.transform.GetChild(0).gameObject.SetActive(true);

            rightBtn.interactable = true;
        }

        //���� ��� üũ
        if (rGM.GetComponent<RoadGameManager>().heartCnt == 0)
        {
            moveBtn.interactable = false;

            leftBtn.interactable = false;
            leftBtn.transform.GetChild(0).gameObject.SetActive(false);

            rightBtn.interactable = false;
        }

        switch (MainGameManager.doneCount)
        {
            case 0:
                moveCntText.text = "�̵� Ƚ�� : " + RoadGameManager.moveCount;
                rotCntText.text = "ȸ�� Ƚ�� : " + RoadGameManager.rotCount;
                break;

            case 1:
                moveCntText.text = "�̵� Ƚ�� : " + RoadGameManager.moveCount2;
                rotCntText.text = "ȸ�� Ƚ�� : " + RoadGameManager.rotCount2;
                break;

            case 2:
                moveCntText.text = "�̵� Ƚ�� : " + RoadGameManager.moveCount3;
                rotCntText.text = "ȸ�� Ƚ�� : " + RoadGameManager.rotCount3;
                break;
        }
    }
}
