using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//Summary : 일정 거리가 되면 말풍선 활성화

enum Wolf2State
{
    Idle,
    Quest
}

public class WolfControl_2 : MonoBehaviour
{
    //플레이어 퀘스트 가능 거리
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
        //말풍선 이미지 비활성화
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
            //퀘스트 이미지 및 버튼 비활성화
            chatBubble.gameObject.SetActive(true);
            textTitle.text = "";
            textTitle.text = "잘 도망갔더군!\n보석을 주면 안잡아먹지~!";
        }

        if (Vector3.Distance(transform.position, target.position) > questDistance)
        {
            w2State = Wolf2State.Idle;
        }
    }
}
