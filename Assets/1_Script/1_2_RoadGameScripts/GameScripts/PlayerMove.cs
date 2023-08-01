using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Summary : UI버튼(앞 뒤 위 아래 회전) 누를 시 이동 - ok
//          회전 버튼 누를시 Go버튼 UI역시 회전

public enum PlayerState
{
    Idle,
    Move
}

public class PlayerMove : MonoBehaviour
{
    float curTime = 0;
    float moveSpeed = 6f;

    public Button goBtn;
    Animator anim;

    public PlayerState pState;

    private void Start()
    {
        pState = PlayerState.Idle;
        anim = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        PlayerCheck();
    }

    public void PlayerCheck()
    {
        switch (pState)
        {
            case PlayerState.Idle:
                Idle();
                break;

            case PlayerState.Move:
                Move();
                break;
        }
    }

    void Idle()
    {
        //애니메이션
        
        moveSpeed = 3.2f;
        anim.SetBool("isRun", false);
    }

    void Move()
    {
        //애니메이션
        anim.SetBool("isRun",true);

        transform.position += transform.right * moveSpeed * Time.deltaTime;

        curTime += Time.deltaTime;

        if (curTime >= 1.2f)
        {
            pState = PlayerState.Idle;
            curTime = 0;
            switch (MainGameManager.doneCount)
            {
                case 0:
                    RoadGameManager.moveCount--;
                    break;

                case 1:
                    RoadGameManager.moveCount2--;
                    break;

                case 2:
                    RoadGameManager.moveCount3--;
                    break;
            }
        }
    }

    public void GoBtn()
    {
        pState = PlayerState.Move;
    }

    public void LeftRotBtn()
    {
        transform.Rotate(new Vector3(0, -90, 0));
        goBtn.transform.Rotate(new Vector3(0, 0, 90));
        switch (MainGameManager.doneCount)
        {
            case 0:
                RoadGameManager.rotCount--;
                break;

            case 1:
                RoadGameManager.rotCount2--;
                break;

            case 2:
                RoadGameManager.rotCount3--;
                break;
        }
    }

    public void RightRoBtn()
    {
        transform.Rotate(new Vector3(0, 90, 0));
        goBtn.transform.Rotate(new Vector3(0, 0, -90));
        switch (MainGameManager.doneCount)
        {
            case 0:
                RoadGameManager.rotCount--;
                break;

            case 1:
                RoadGameManager.rotCount2--;
                break;

            case 2:
                RoadGameManager.rotCount3--;
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "OutZone" || other.gameObject.tag == "Obstacle")
        {
            RoadGameManager.isOut = true;
            pState = PlayerState.Idle;
            moveSpeed = 0f;
            curTime = 0;
        }

        if (other.gameObject.tag == "Goal")
        {
            RoadGameManager.isGoal = true;
        }
    }
}
