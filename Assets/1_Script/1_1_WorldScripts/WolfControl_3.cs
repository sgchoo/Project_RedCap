using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//Summary : ���� �Ÿ��� �Ǹ� ��ǳ�� Ȱ��ȭ

enum Wolf3State
{
    Idle,
    Quest
}

public class WolfControl_3 : MonoBehaviour
{
    //�÷��̾� ����Ʈ ���� �Ÿ�
    float questDistance = 20f;

    Transform target;
    public Image chatBubble;
    [SerializeField] private TextMeshPro textTitle;

    Wolf3State w3State;

    private void Awake()
    {
        target = GameObject.Find("Player").transform;
    }

    private void Start()
    {
        w3State = Wolf3State.Idle;
    }

    private void Update()
    {
        StateCheck();
    }

    void StateCheck()
    {
        switch (w3State)
        {
            case Wolf3State.Idle:
                Idle();
                break;

            case Wolf3State.Quest:
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
            w3State = Wolf3State.Quest;
        }
    }

    void Quest()
    {

        if (Vector3.Distance(transform.position, target.position) < questDistance)
        {
            //����Ʈ �̹��� �� ��ư ��Ȱ��ȭ
            chatBubble.gameObject.SetActive(true);
            textTitle.text = "";
            textTitle.text = "�̹��� ���� �� ������!\n������ �ָ� ����Ƹ���~!";
        }

        if (Vector3.Distance(transform.position, target.position) > questDistance)
        {
            w3State = Wolf3State.Idle;
        }
    }
}
