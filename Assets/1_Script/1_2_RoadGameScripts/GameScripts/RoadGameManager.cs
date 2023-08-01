using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Summary : 두 카운터 모두 소진이 됐으나 목표지점에 도달하지 못할 시 하트 차감
//          벽 넘어서 가면 하트 차감 - Trigger 함수에서 구현
//          카운터가 남았으나 목표지점에 도달하면 성공
//          카운터가 모두 소진 됐으나 목표지점에 도달하면 성공
//          하트 감소 후 원래 포지션 및 회전으로 돌아오기
//          하트 모두 소진 시 게임 실패
//          여기서 씬 넘어갈것.

public class RoadGameManager : MonoBehaviour
{
    public int heartCnt = 3;

    //3x3게임
    public static int moveCount = 4;
    public static int rotCount = 2;

    //4x4 첫번째 게임
    public static int moveCount2 = 6;
    public static int rotCount2 = 3;

    //4x4 두번째 게임
    public static int moveCount3 = 6;
    public static int rotCount3 = 3;

    public static bool isOut = false;
    public static bool isGoal = false;
    bool loseCoin = false;

    public Transform player;
    public Button goBtn;

    public Image[] heart = new Image[3];
    public Image clearImg;
    public Image defeatImg;

    Vector3 originPos;
    Quaternion originRot;

    private void Start()
    {
        PlayerInit();
        ImgInit();
    }

    private void Update()
    {
        HeartCount();
        DefeatCheck();
        ClearCheck();
    }

    void PlayerInit()
    {
        originPos = player.position;
        originRot = player.rotation;

        loseCoin = false;
    }

    void ImgInit()
    {
        heart[0].gameObject.SetActive(true);
        heart[1].gameObject.SetActive(true);
        heart[2].gameObject.SetActive(true);

        clearImg.gameObject.SetActive(false);
        defeatImg.gameObject.SetActive(false);
    }

    void HeartCount()
    {
        if (MainGameManager.doneCount == 0)
        {
            if ((moveCount == 0 && rotCount == 0 && isGoal == false) || (isOut == true))
            {
                heartCnt--;
                heart[heartCnt].gameObject.SetActive(false);

                player.position = originPos;
                player.rotation = originRot;
                goBtn.transform.rotation = originRot;

                moveCount = 4;
                rotCount = 2;
                isOut = false;
                StartCoroutine(ChangeColor());
            }
        }

        else if (MainGameManager.doneCount == 1)
        {
            if ((moveCount2 == 0 && rotCount2 == 0 && isGoal == false) || (isOut == true))
            {
                heartCnt--;
                heart[heartCnt].gameObject.SetActive(false);

                player.position = originPos;
                player.rotation = originRot;
                goBtn.transform.rotation = originRot;

                moveCount2 = 6;
                rotCount2 = 3;
                isOut = false;
                StartCoroutine(ChangeColor());
            }
        }

        else
        {
            if ((moveCount3 == 0 && rotCount3 == 0 && isGoal == false) || (isOut == true))
            {
                heartCnt--;
                heart[heartCnt].gameObject.SetActive(false);

                player.position = originPos;
                player.rotation = originRot;
                goBtn.transform.rotation = originRot;

                moveCount3 = 6;
                rotCount3 = 3;
                isOut = false;
                StartCoroutine(ChangeColor());
            }
        }
    }

    IEnumerator ChangeColor()
    {
        MeshRenderer mat = player.GetComponent<MeshRenderer>();
        mat.material.color = new Color32(1, 1, 1, 150);

        yield return new WaitForSeconds(0.5f);

        mat.material.color = new Color32(43, 30, 217, 255);

        yield return new WaitForSeconds(0.5f);

        mat.material.color = new Color32(1, 1, 1, 150);

        yield return new WaitForSeconds(0.5f);

        mat.material.color = new Color32(43, 30, 217, 255);
    }

    void ClearCheck()
    {
        if (MainGameManager.doneCount == 0)
        {
            if ((heartCnt > 0) && (moveCount >= 0) && (rotCount >= 0) && (isGoal == true))
            {
                isGoal = false;
                MainGameManager.getBack = true;
                clearImg.gameObject.SetActive(true);
                Invoke("GetBackWorld", 3f);
            }
        }

        else if (MainGameManager.doneCount == 1)
        {
            if ((heartCnt > 0) && (moveCount2 >= 0) && (rotCount2 >= 0) && (isGoal == true))
            {
                isGoal = false;
                MainGameManager.getBack = true;
                clearImg.gameObject.SetActive(true);
                Invoke("GetBackWorld", 3f);
            }
        }

        else
        {
            if ((heartCnt > 0) && (moveCount3 >= 0) && (rotCount3 >= 0) && (isGoal == true))
            {
                isGoal = false;
                MainGameManager.getBack = true;
                clearImg.gameObject.SetActive(true);
                Invoke("GetBackWorld", 3f);
            }
        }
        
    }

    void DefeatCheck()
    {
        if (heartCnt == 0)
        {
            if (loseCoin == false)
            {
                MainGameManager.coin -= 20;
                if (MainGameManager.coin < 0)
                {
                    MainGameManager.coin = 0;
                }
                loseCoin = true;
            }
            
            MainGameManager.getBack = true;
            defeatImg.gameObject.SetActive(true);
            Invoke("GetBackWorld", 3f);

        }
    }

    void GetBackWorld()
    {
        if (MainGameManager.getBack == true)
        {
            MainGameManager.doneCount++;
            MainGameManager.getBack = false;
        }
        
        SceneManager.LoadScene("LoadingScene");
    }
}
