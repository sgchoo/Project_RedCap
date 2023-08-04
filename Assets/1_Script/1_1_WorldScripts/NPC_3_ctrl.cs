using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

//Summary : Idle, Recog, Quest enum 함수 생성
//          Idle때는 애니메이션 재생
//          일정 거리 이내로 다가오면 Idle -> Recog

//          Recog때는 느낌표 이미지 띄운후 애니메이션은 Idle
//          일정 거리 이내로 다가오면 Recog -> Quest

//          Quest떄는 버튼 및 이미지 생성되며 특정 키 입력하면
//          월드에서 이미지 및 텍스트 실행
//          네 버튼 누르면 다음 씬
//          아니요 버튼 누르면 Quest -> Idle
//          일정 거리보다 멀어지면 Quest -> Idle

public enum NPC3State
{
    Idle,
    Recog,
    Quest
}

public class NPC_3_ctrl : MonoBehaviour
{
    //플레이어 감지 가능 거리
    public float recogDistance = 10f;
    //플레이어 퀘스트 가능 거리
    public float questDistance = 3f;

    Transform target;
    public Image mark;
    [SerializeField] private TextMeshPro textTitle;

    public GameObject quest;
    public Image questImg;
    public Text questText;

    //InfoUI
    public GameObject infoUI;
    public Text titleText;
    public Text explainText;
    public Button button;

    NPC3State n3State;

    //애니메이션
    Animator animator;



    private void Awake()
    {
        target = GameObject.Find("Player").transform;
    }

    private void Start()
    {
        SetInit();

        //애니메이션
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        StateCheck();
       
    }

    void SetInit()
    {
        n3State = NPC3State.Idle;
    }

    void StateCheck()
    {
        switch (n3State)
        {
            case NPC3State.Idle:
                Idle();
                break;

            case NPC3State.Recog:
                Recog();
                break;

            case NPC3State.Quest:
                Quest();
                break;
        }
    }

    void Idle()
    {
        //Idle애니메이션 실행

        //애니메이션 기본값
        animator.SetBool("exit_bool", true);

        mark.gameObject.SetActive(false);

        if (Vector3.Distance(transform.position, target.position) < recogDistance)
        {
            n3State = NPC3State.Recog;
        }
    }

    void Recog()
    {
        //애니메이션 기본값
        animator.SetBool("exit_bool", true);

        transform.forward = -target.forward;

        //말풍선 이미지 실행 및 방향 설정
        mark.gameObject.SetActive(true);
        textTitle.text = "";
        textTitle.text = "안녕 내 이름은 토우키야\n 나랑 화살쏘기 게임하자.";

        if (Vector3.Distance(transform.position, target.position) < questDistance)
        {
            n3State = NPC3State.Quest;
        }

        if (Vector3.Distance(transform.position, target.position) > recogDistance)
        {
            n3State = NPC3State.Idle;
        }
    }

    void Quest()
    {
        //애니메이션 실행? 만약 넣는다면 애니메이션 파라미터 bool값

        textTitle.text = "";
        textTitle.text = "활을 쏘고 싶으면 F키를 눌러줘!";

        transform.forward = -target.forward;

        if (Input.GetKeyDown(KeyCode.F))
        {
            //애니메이션 정지
            animator.SetBool("exit_bool", false);

            //퀘스트 이미지 및 버튼 활성화
            quest.SetActive(true);
            questImg.gameObject.SetActive(true);
            questText.gameObject.SetActive(true);

            mark.gameObject.SetActive(false);

            questText.text = "";
            StartCoroutine(DelayChat("머리가 똑똑해지는 숫자 비교 활 게임이야.", 0.1f));
        }

        if (Vector3.Distance(transform.position, target.position) > questDistance)
        {
            //퀘스트 이미지 및 버튼 비활성화
            quest.SetActive(false);
            questImg.gameObject.SetActive(false);
            questText.gameObject.SetActive(false);

            mark.gameObject.SetActive(true);
            textTitle.text = "";

            questText.text = "";

            n3State = NPC3State.Recog;
        }
    }

    IEnumerator DelayChat(string content, float delay)
    {
        for (int i = 0; i < content.Length; i++)
        {
            questText.text += "" + $"{content[i]}";
            yield return new WaitForSeconds(delay);
        }
    }

    public void YesBtn()
    {
        quest.SetActive(false);
        questImg.gameObject.SetActive(false);
        questText.gameObject.SetActive(false);

        questText.text = "";

        infoUI.SetActive(true);
        button.gameObject.SetActive(true);

        titleText.text = "";
        titleText.text = "화살로 풍선을 맞혀 사칙 연산을 계산해보자!";

        explainText.text = "";
        explainText.text = "풍선 5개중 3개의 숫자 풍선을 맞춘다" +
                           "\n맞춘 풍선으로 왼쪽 식을 완성!" +
                           "\n그 다음으로 등장하는 흰색 풍선 하나를 맞춘 후 예상되는 결과값을 두고" +
                           "\n그 다음에 등장하는 대소 비교 풍선을 맞혀 올바른 식을 만들면 성공!";

        Player_ctrl player = MainGameManager.objs.GetComponent<Player_ctrl>();
        player.speed = 0f;

        ////씬 넘기기
        //MainGameManager.getBack = true;
        //SceneManager.LoadScene("Mini_MouseDragInfo");
    }

    public void NoBtn()
    {
        quest.SetActive(false);
        infoUI.SetActive(false);
        questImg.gameObject.SetActive(false);
        questText.gameObject.SetActive(false);

        questText.text = "";
    }

    public void InfoToGameStartBtn()
    {
        //씬 넘기기
        Player_ctrl player = MainGameManager.objs.GetComponent<Player_ctrl>();
        player.speed = 12f;

        MainGameManager.getBack = true;
        infoUI.SetActive(false);
        button.gameObject.SetActive(false);
        MainGameManager.objs.SetActive(false);
        SceneManager.LoadScene("ArrowGameScene");
    }
}
