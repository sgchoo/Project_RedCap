using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoadGameTrigger_1 : MonoBehaviour
{
    public Image wolfQuestImg;
    public Text wolfQuestText;
    public Button wolfGameBtn;

    //���� ���� ���ۺκ�
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
        //����Ʈ �̹��� �� ��ư Ȱ��ȭ
        wolfQuestImg.gameObject.SetActive(true);
        wolfQuestText.gameObject.SetActive(true);
        wolfGameBtn.gameObject.SetActive(true);

        wolfQuestText.text = "";

        if (wolfcount == 0)
        {
            string comment = "���밡 ��Ÿ�����\n���븦 ���ؼ� �̵��ؿ�!";
            StartCoroutine(DelayChat(comment, 0.1f));
        }

        else if (wolfcount == 1)
        {
            string comment = "���밡 �ٽ� ��Ÿ�����!\n���밡 ������ �غ��ߴٰ� �ؿ�. �����ؼ� �̵��ϼ���!";
            StartCoroutine(DelayChat(comment, 0.1f));
        }

        else
        {
            string comment = "���밡 ���������� ��Ÿ�����!\n �̹��� ������ ���� �ξ��ٰ� �ؿ�. �����ؼ� �̵��ϼ���!";
            StartCoroutine(DelayChat(comment, 0.1f));
        }
    }

    //��ũ��UI �ڷ�ƾ
    IEnumerator DelayChat(string content, float delay)
    {
        for (int i = 0; i < content.Length; i++)
        {
            wolfQuestText.text += "" + $"{content[i]}";
            yield return new WaitForSeconds(delay);
        }
    }
}
