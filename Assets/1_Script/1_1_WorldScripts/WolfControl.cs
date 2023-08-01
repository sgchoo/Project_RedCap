using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//Summary : 일정 거리가 되면 말풍선 활성화

enum WolfState
{
    Idle,
    Quest
}

public class WolfControl : MonoBehaviour
{
    //플레이어 퀘스트 가능 거리
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
        //말풍선 이미지 비활성화
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
            //퀘스트 이미지 및 버튼 비활성화
            chatBubble.gameObject.SetActive(true);
            textTitle.text = "";
            textTitle.text = "으르렁!\n보석을 주면 안잡아먹지~!";
        }

        if (Vector3.Distance(transform.position, target.position) > questDistance)
        {
            wState = WolfState.Idle;
        }
    }
}
