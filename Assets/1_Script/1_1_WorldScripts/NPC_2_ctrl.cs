using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

//Summary : Idle, Recog, Quest enum �Լ� ����
//          Idle���� �ִϸ��̼� ���
//          ���� �Ÿ� �̳��� �ٰ����� Idle -> Recog

//          Recog���� ����ǥ �̹��� ����� �ִϸ��̼��� Idle
//          ���� �Ÿ� �̳��� �ٰ����� Recog -> Quest

//          Quest���� ��ư �� �̹��� �����Ǹ� Ư�� Ű �Է��ϸ�
//          ���忡�� �̹��� �� �ؽ�Ʈ ����
//          �� ��ư ������ ���� ��
//          �ƴϿ� ��ư ������ Quest -> Idle
//          ���� �Ÿ����� �־����� Quest -> Idle

public enum NPC2State
{
    Idle,
    Recog,
    Quest
}

public class NPC_2_ctrl : MonoBehaviour
{
    //�÷��̾� ���� ���� �Ÿ�
    public float recogDistance = 10f;
    //�÷��̾� ����Ʈ ���� �Ÿ�
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

    //�ִϸ��̼�
    Animator animator;

    private void Awake()
    {
        target = GameObject.Find("Player").transform;
    }

    private void Start()
    {
        SetInit();

        //�ִϸ��̼�
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
        //Idle�ִϸ��̼� ����

        //�ִϸ��̼� �⺻��
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
        //Idle�ִϸ��̼� ����

        //�ִϸ��̼� �⺻��
        animator.SetBool("exit_bool", true);


        transform.forward = -target.forward;

        //��ǳ�� �̹��� ���� �� ���� ����
        mark.gameObject.SetActive(true);
        textTitle.text = "";
        textTitle.text = "�ȳ�! �� �̸��� ������.\n���� �� ������ ���� �ҷ�? ";

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
        //�ִϸ��̼� ����? ���� �ִ´ٸ� �ִϸ��̼� �Ķ���� bool��

        textTitle.text = "";
        textTitle.text = "FŰ�� ������ �� �� �־�!";

        transform.forward = -target.forward;

        if (Input.GetKeyDown(KeyCode.F))
        {
            //�ִϸ��̼� ����
            animator.SetBool("exit_bool", false);

            //����Ʈ �̹��� �� ��ư Ȱ��ȭ
            quest.SetActive(true);
            questImg.gameObject.SetActive(true);
            questText.gameObject.SetActive(true);

            mark.gameObject.SetActive(false);

            questText.text = "";
            StartCoroutine(DelayChat("�ȳ� ģ���� ���� ���ⱸ�� �� �ֱ� ��������.", 0.1f));
        }

        if (Vector3.Distance(transform.position, target.position) > questDistance)
        {
            //����Ʈ �̹��� �� ��ư ��Ȱ��ȭ
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
        titleText.text = "���ⱸ�� ���� �־��!";

        explainText.text = "";
        explainText.text = "�츮 ���� ģ���� ���ⱸ�� ���� ������ ���ʹ��!" +
                           "\n1,2,3���ⱸ���� ���� ������ ���� ���� �Ǵ� ���� ���ڰ� �����־��!" +
                           "\n5���� ������ 1,2,3 ���ⱸ �� ������ �����ִ� ���ⱸ ���ڸ� ����" +
                           "\n���� 3�� �־��ּ���!";

        Player_ctrl player = MainGameManager.objs.GetComponent<Player_ctrl>();
        player.speed = 0f;

        ////�� �ѱ��
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
        //�� �ѱ��
        Player_ctrl player = MainGameManager.objs.GetComponent<Player_ctrl>();
        player.speed = 12f;

        MainGameManager.getBack = true;
        infoUI.SetActive(false);
        button.gameObject.SetActive(false);
        MainGameManager.objs.SetActive(false);
        SceneManager.LoadScene("BallGameScene");
    }
}
