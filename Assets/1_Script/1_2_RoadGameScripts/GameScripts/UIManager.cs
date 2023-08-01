using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Summary : 앞 뒤 위 아래버튼을 누르면 이동 카운터 한개씩 감소 - ok
//          회전 누를 시 회전 카운터 감소 - ok


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
                moveCntText.text = "이동 횟수 : " + RoadGameManager.moveCount;
                rotCntText.text = "회전 횟수 : " + RoadGameManager.rotCount;
                break;

            case 1:
                moveCntText.text = "이동 횟수 : " + RoadGameManager.moveCount2;
                rotCntText.text = "회전 횟수 : " + RoadGameManager.rotCount2;
                break;

            case 2:
                moveCntText.text = "이동 횟수 : " + RoadGameManager.moveCount3;
                rotCntText.text = "회전 횟수 : " + RoadGameManager.rotCount3;
                break;
        }
    }

    void ButtonCheck()
    {
        //무브 카운트 체크
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

        //회전 카운트 체크
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

        //남은 목숨 체크
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
                moveCntText.text = "이동 횟수 : " + RoadGameManager.moveCount;
                rotCntText.text = "회전 횟수 : " + RoadGameManager.rotCount;
                break;

            case 1:
                moveCntText.text = "이동 횟수 : " + RoadGameManager.moveCount2;
                rotCntText.text = "회전 횟수 : " + RoadGameManager.rotCount2;
                break;

            case 2:
                moveCntText.text = "이동 횟수 : " + RoadGameManager.moveCount3;
                rotCntText.text = "회전 횟수 : " + RoadGameManager.rotCount3;
                break;
        }
    }
}
