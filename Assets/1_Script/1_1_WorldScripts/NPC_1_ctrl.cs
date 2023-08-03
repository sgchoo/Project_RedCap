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

public enum NPCState
{
    Idle,
    Recog,
    Quest
}

public class NPC_1_ctrl : MonoBehaviour
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

    NPCState nState;

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
        nState = NPCState.Idle;
        textTitle.text = "";
    }

    void StateCheck()
    {
        switch (nState)
        {
            case NPCState.Idle:
                Idle();
                break;

            case NPCState.Recog:
                Recog();
                break;

            case NPCState.Quest:
                Quest();
                break;
        }
    }

    void Idle()
    {
        //Idle애니메이션 실행

        //애니메이션 기본값
        animator.SetBool("exit_bool", true);


        transform.forward = -target.forward;//뒤돌아봐서 -로 수정

        //말풍선 이미지 비활성화
        mark.gameObject.SetActive(false);

        if (Vector3.Distance(transform.position, target.position) < recogDistance)
        {
            nState = NPCState.Recog;
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
        textTitle.text = "친구야 나 좀 도와줘\n공이 든 상자를 쏟았어. 가까이 와줘.";

        if (Vector3.Distance(transform.position, target.position) < questDistance)
        {
            nState = NPCState.Quest;
        }

        if (Vector3.Distance(transform.position, target.position) > recogDistance)
        {
            nState = NPCState.Idle;
        }
    }

    void Quest()
    {
        //애니메이션 실행? 만약 넣는다면 애니메이션 파라미터 bool값

        textTitle.text = "";
        textTitle.text = "도와줄거면 F키를 눌러줘!";

        transform.forward = - target.forward;

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
            StartCoroutine(DelayChat("안녕 내 이름은 다람이야. \n나 좀 도와줄래?", 0.1f));
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
            
            nState = NPCState.Recog;
        }
    }

    //스크린UI 코루틴
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
        titleText.text = "쏟아진 공을 상자에 넣자";

        explainText.text = "";
        explainText.text = "파란색 공, 초록색 공, 빨간색 공을 마우스로 클릭한 상태에서" + 
                           "\n\n오른쪽에 위치한 상자에 끌어서 넣어서 정리해주세요." + 
                           "\n\n총 3번 정리를 해야하며 갯수대로 넣지 않는다면 생명이 깎여요.";

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
        SceneManager.LoadScene("Mini_MouseDrag");
    }
}
