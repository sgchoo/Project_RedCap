using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//Summary : ���� �Ÿ��� �Ǹ� ��ǳ�� Ȱ��ȭ

enum Wolf2State
{
    Idle,
    Quest
}

public class WolfControl_2 : MonoBehaviour
{
    //�÷��̾� ����Ʈ ���� �Ÿ�
    float questDistance = 20f;

    Transform target;
    public Image chatBubble;
    [SerializeField] private TextMeshPro textTitle;

    Wolf2State w2State;

    private void Awake()
    {
        target = GameObject.Find("Player").transform;
    }

    private void Start()
    {
        w2State = Wolf2State.Idle;
    }

    private void Update()
    {
        StateCheck();
    }

    void StateCheck()
    {
        switch (w2State)
        {
            case Wolf2State.Idle:
                Idle();
                break;

            case Wolf2State.Quest:
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
            w2State = Wolf2State.Quest;
        }
    }

    void Quest()
    {

        if (Vector3.Distance(transform.position, target.position) < questDistance)
        {
            //����Ʈ �̹��� �� ��ư ��Ȱ��ȭ
            chatBubble.gameObject.SetActive(true);
            textTitle.text = "";
            textTitle.text = "�� ����������!\n������ �ָ� ����Ƹ���~!";
        }

        if (Vector3.Distance(transform.position, target.position) > questDistance)
        {
            w2State = Wolf2State.Idle;
        }
    }
}
