using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Summary : 게임 씬에서는 쓰레기통이 3개가 존재하며 버튼도 존재한다.
//          버튼을 누르면 해당 쓰레기통으로 오브젝트를 놓는다.
//          버튼이 눌리면 버튼 비활성화

public enum ThrowPosition
{
    Init,
    ToTarget1,
    ToTarget2,
    ToTarget3
}
public class TreshMove : MonoBehaviour
{
    public static bool isThrow = false;

    public Transform[] target = new Transform[3];


    public ThrowPosition treshTarget;

    private void Start()
    {
        treshTarget = ThrowPosition.Init;
    }

    private void Update()
    {
        TargetCheck();
    }

    void TargetCheck()
    {
        switch (treshTarget)
        {
            case ThrowPosition.Init:
                break;

            case ThrowPosition.ToTarget1:
                ThrowToTarget(0);
                BallGameManager.myAnswer = BallGameManager.myThink[0];
                isThrow = true;
                break;

            case ThrowPosition.ToTarget2:
                ThrowToTarget(1);
                BallGameManager.myAnswer = BallGameManager.myThink[1];
                isThrow = true;
                break;

            case ThrowPosition.ToTarget3:
                ThrowToTarget(2);
                BallGameManager.myAnswer = BallGameManager.myThink[2];
                isThrow = true;
                break;
        }
    }

    void ThrowToTarget(int num)
    {
        Vector3 dest = target[num].position + new Vector3(0, 5f, 0);  //위로 올리고  
        Vector3 fix = dest - new Vector3(0, 3 * Time.deltaTime, 0); //목적지를 내려가면서

        if (Mathf.Abs(transform.position.z - fix.z) > 4f)//(가까이 갈때까지)
            transform.position = Vector3.Slerp(transform.position, fix, 0.014f);//베지어 이동을
        else//가까이 오면 목적지로 바로 이동을 
            transform.position = Vector3.Lerp(transform.position, target[num].position, 0.01f);
    }

    public void TargetBtn1()
    {
        treshTarget = ThrowPosition.ToTarget1;
    }

    public void TargetBtn2()
    {
        treshTarget = ThrowPosition.ToTarget2;
    }

    public void TargetBtn3()
    {
        treshTarget = ThrowPosition.ToTarget3;
    }
}
