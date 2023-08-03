using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Summary : ���忡�� ���� ������ Text�� ǥ���Ѵ�.
//          doneCount�� �̿��� Ʈ���� �� ����������Ʈ ����
//          

public class MainGameManager : MonoBehaviour
{
    //���� ���� ����
    public static int coin = 0;

    //Ʈ���� ��ü, ���� ������Ʈ ��Ȱ��ȭ ����
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
                //���� ��Ȱ��ȭ
                wolfs[0].SetActive(false);
                break;

            case 2:
                triggerZones[1].SetActive(false);
                //���� ��Ȱ��ȭ
                wolfs[1].SetActive(false);
                break;

            case 3:
                triggerZones[2].SetActive(false);
                //���� ��Ȱ��ȭ
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
        titleText.text = "���븦 ���� ���� ã�ư���!";

        explainText.text = "";
        explainText.text = "������ ���� ã�� �������� ���� �ؿ�. ��, �̵��� ȸ�� ��ȸ�� �������־��." +
                           "\n�߸��� �������� ���ų� ������ �� �ִ� ��ȸ�� ��� ����ϸ�" +
                           "\n��Ʈ�� �������." +
                           "\n3���� ��Ʈ�� ��� ������� ���뿡�� ��� ������ �����ϼ���!";
        

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
            //�ҸӴ� ���� ��ġ�� Instantiate();
            endingTrigger.SetActive(true);
            Debug.Log("���� ����");
        }
    }
}
