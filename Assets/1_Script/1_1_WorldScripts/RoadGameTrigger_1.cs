using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoadGameTrigger_1 : MonoBehaviour
{
    public Image wolfQuestImg;
    public Text wolfQuestText;
    public Button wolfGameBtn;

    //늑대 게임 시작부분
    private void OnTriggerEnter(Collider other)
    {
        Player_ctrl player = MainGameManager.objs.GetComponent<Player_ctrl>();
        player.speed = 0f;

        if (gameObject.name == "RoadGame_1st")
        {
            wolfQuestText.text = "";
            WolfGameText(MainGameManager.doneCount);
        }

        else if (gameObject.name == "RoadGame_2nd")
        {
            wolfQuestText.text = "";
            WolfGameText(MainGameManager.doneCount);
        }

        else if (gameObject.name == "RoadGame_3rd")
        {
            wolfQuestText.text = "";
            WolfGameText(MainGameManager.doneCount);
        }
    }

    void WolfGameText(int wolfcount)
    {
        //퀘스트 이미지 및 버튼 활성화
        wolfQuestImg.gameObject.SetActive(true);
        wolfQuestText.gameObject.SetActive(true);
        wolfGameBtn.gameObject.SetActive(true);

        wolfQuestText.text = "";

        if (wolfcount == 0)
        {
            string comment = "늑대가 나타났어요\n늑대를 피해서 이동해요!";
            StartCoroutine(DelayChat(comment, 0.1f));
        }

        else if (wolfcount == 1)
        {
            string comment = "늑대가 다시 나타났어요!\n늑대가 함정을 준비했다고 해요. 조심해서 이동하세요!";
            StartCoroutine(DelayChat(comment, 0.1f));
        }

        else
        {
            string comment = "늑대가 마지막으로 나타났어요!\n 이번엔 함정을 많이 두었다고 해요. 조심해서 이동하세요!";
            StartCoroutine(DelayChat(comment, 0.1f));
        }
    }

    //스크린UI 코루틴
    IEnumerator DelayChat(string content, float delay)
    {
        for (int i = 0; i < content.Length; i++)
        {
            wolfQuestText.text += "" + $"{content[i]}";
            yield return new WaitForSeconds(delay);
        }
    }
}
