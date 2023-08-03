using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Summary : 월드에서 얻은 코인을 Text에 표시한다.
//          doneCount를 이용해 트리거 및 울프오브젝트 관리
//          

public class MainGameManager : MonoBehaviour
{
    //코인 갯수 변수
    public static int coin = 0;

    //트리거 해체, 울프 오브젝트 비활성화 변수
    public static int doneCount = 0;

    public static bool getBack = false;
    public static bool isEnded = false;

    public Text coinText;
    public static GameObject objs;
    public GameObject[] triggerZones = new GameObject[3];
    public GameObject[] wolfs = new GameObject[3];

    public Text flowerText;
    public Text wineText;
    public Text breadText;

    public Image wolfQuestImg;
    public Text wolfQuestText;
    public Button wolfGameBtn;

    public GameObject endingTrigger;

    //InfoUI
    public GameObject infoUI;
    public Text titleText;
    public Text explainText;


    private void Awake()
    {
        ObjectInit();
        TriggerOff();
    }

    private void Update()
    {
        GetValue();
        CreateGrandma();
    }

    void ObjectInit()
    {
        coinText.text = "x : " + coin;

        
    }

    void GetValue()
    {
        coinText.text = "x : " + coin;
    }

    void TriggerOff()
    {
        switch (doneCount)
        {
            case 1:
                triggerZones[0].SetActive(false);
                //늑대 비활성화
                wolfs[0].SetActive(false);
                break;

            case 2:
                triggerZones[1].SetActive(false);
                //늑대 비활성화
                wolfs[1].SetActive(false);
                break;

            case 3:
                triggerZones[2].SetActive(false);
                //늑대 비활성화
                wolfs[2].SetActive(false);
                break;
        }
    }

    public void WolfGameBtn()
    {
        Player_ctrl player = objs.GetComponent<Player_ctrl>();
        player.speed = 12f;

        wolfQuestImg.gameObject.SetActive(false);
        wolfQuestText.gameObject.SetActive(false);
        wolfGameBtn.gameObject.SetActive(false);

        infoUI.SetActive(true);

        
        titleText.text = "";
        titleText.text = "늑대를 피해 길을 찾아가자!";

        explainText.text = "";
        explainText.text = "정해진 길을 찾아 목적지로 가야 해요. 단, 이동과 회전 기회는 정해져있어요." +
                           "\n잘못된 방향으로 가거나 움직일 수 있는 기회를 모두 사용하면" +
                           "\n하트가 사라져요." +
                           "\n3개의 하트가 모두 사라지면 늑대에게 잡아 먹히니 주의하세요!";
        

        Time.timeScale = 0f;
    }

    public void WolfGameStartBtn()
    {
        Time.timeScale = 1f;
        infoUI.SetActive(false);
        MainGameManager.objs.SetActive(false);

        if (doneCount == 0)
        {
            wolfs[0].SetActive(false);
            SceneManager.LoadScene("RoadGameScene3x3");
        }

        else if (doneCount == 1)
        {
            wolfs[1].SetActive(false);
            SceneManager.LoadScene("RoadGameScene4x4_1st");
        }

        else
        {
            wolfs[2].SetActive(false);
            SceneManager.LoadScene("RoadGameScene4x4_2nd");
        }
    }

    void CreateGrandma()
    {
        flowerText.text = "X " + ShopManager.flowerCount;
        wineText.text = "X " + ShopManager.wineCount;
        breadText.text = "X " + ShopManager.breadCount;

        if ((ShopManager.flowerCount == 1) && (ShopManager.wineCount == 1) && (ShopManager.breadCount == 1))
        {
            //할머니 지정 위치에 Instantiate();
            endingTrigger.SetActive(true);
            Debug.Log("조건 충족");
        }
    }
}
