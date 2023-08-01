using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Summary : ���� �������� ���������� 3���� �����ϸ� ��ư�� �����Ѵ�.
//          ��ư�� ������ �ش� ������������ ������Ʈ�� ���´�.
//          ��ư�� ������ ��ư ��Ȱ��ȭ

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
        Vector3 dest = target[num].position + new Vector3(0, 5f, 0);  //���� �ø���  
        Vector3 fix = dest - new Vector3(0, 3 * Time.deltaTime, 0); //�������� �������鼭

        if (Mathf.Abs(transform.position.z - fix.z) > 4f)//(������ ��������)
            transform.position = Vector3.Slerp(transform.position, fix, 0.014f);//������ �̵���
        else//������ ���� �������� �ٷ� �̵��� 
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
