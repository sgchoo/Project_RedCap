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

public enum NPC2State
{
    Idle,
    Recog,
    Quest
}

public class NPC_2_ctrl : MonoBehaviour
{
    //플레이어 감지 가능 거리
    public float recogDistance = 10f;
    //플레이어 퀘스트 가능 거리
    public float questDistance = 3f;

    //bool isChat = false;

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

    NPC2State n2State;

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
        n2State = NPC2State.Idle;
    }

    void StateCheck()
    {
        switch (n2State)
        {
            case NPC2State.Idle:
                Idle();
                break;

            case NPC2State.Recog:
                Recog();
                break;

            case NPC2State.Quest:
                Quest();
                break;
        }
    }

    void Idle()
    {
        //Idle애니메이션 실행

        //애니메이션 기본값
        animator.SetBool("exit_bool", true);

        transform.forward = -target.forward;

        mark.gameObject.SetActive(false);

        if (Vector3.Distance(transform.position, target.position) < recogDistance)
        {
            n2State = NPC2State.Recog;
        }
    }

    void Recog()
    {
        //Idle애니메이션 실행

        //애니메이션 기본값
        animator.SetBool("exit_bool", true);


        transform.forward = -target.forward;

        //말풍선 이미지 실행 및 방향 설정
        mark.gameObject.SetActive(true);
        textTitle.text = "";
        textTitle.text = "안녕! 내 이름은 도리야.\n나랑 공 던지기 놀이 할래? ";

        if (Vector3.Distance(transform.position, target.position) < questDistance)
        {
            n2State = NPC2State.Quest;
        }

        if (Vector3.Distance(transform.position, target.position) > recogDistance)
        {
            n2State = NPC2State.Idle;
        }
    }

    void Quest()
    {
        //애니메이션 실행? 만약 넣는다면 애니메이션 파라미터 bool값

        textTitle.text = "";
        textTitle.text = "F키를 누르면 놀 수 있어!";

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
            StartCoroutine(DelayChat("안녕 친구야 나랑 열기구에 공 넣기 놀이하자.", 0.1f));
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

            n2State = NPC2State.Recog;
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
        titleText.text = "열기구에 공을 넣어보자!";

        explainText.text = "";
        explainText.text = "우리 도리 친구가 열기구에 공을 넣으며 놀고싶대요!" +
                           "\n1,2,3열기구에는 각각 문제에 대한 정답 또는 오답 숫자가 적혀있어요!" +
                           "\n5개의 공들을 1,2,3 열기구 중 정답이 적혀있는 열기구 숫자를 눌러" +
                           "\n공을 3번 넣어주세요!";

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
        SceneManager.LoadScene("BallGameScene");
    }
}
