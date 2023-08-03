using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//Summary : ���� �Ÿ��� �Ǹ� ��ǳ�� Ȱ��ȭ

enum WolfState
{
    Idle,
    Quest
}

public class WolfControl : MonoBehaviour
{
    //�÷��̾� ����Ʈ ���� �Ÿ�
    float questDistance = 20f;

    Transform target;
    public Image chatBubble;
    [SerializeField] private TextMeshPro textTitle;

    WolfState wState;

    private void Awake()
    {
        target = GameObject.Find("Player").transform;
    }

    private void Start()
    {
        wState = WolfState.Idle;
    }

    private void Update()
    {
        StateCheck();
    }

    void StateCheck()
    {
        switch (wState)
        {
            case WolfState.Idle:
                Idle();
                break;

            case WolfState.Quest:
                Quest();
                break;
        }
    }

    void Idle()
    {
        //��ǳ�� �̹��� ��Ȱ��ȭ
        chatBubble.gameObject.SetActive(false);

        if (Vector3.Distance(transform.position, target.position) < questDistance)
        {
            wState = WolfState.Quest;
        }
    }

    void Quest()
    {
        if (Vector3.Distance(transform.position, target.position) < questDistance)
        {
            //����Ʈ �̹��� �� ��ư ��Ȱ��ȭ
            chatBubble.gameObject.SetActive(true);
            textTitle.text = "";
            textTitle.text = "������!\n������ �ָ� ����Ƹ���~!";
        }

        if (Vector3.Distance(transform.position, target.position) > questDistance)
        {
            wState = WolfState.Idle;
        }
    }
}
