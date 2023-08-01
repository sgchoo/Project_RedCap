using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Summary : ������ ���� ��
//          BallGameManager�� �� ����
//          BallGameManager���� ���� ��������
//          �ڷ�ƾ���� ��ũ��Ʈ ��Ȱ��ȭ �� 1.5f�� �� Ȱ��ȭ
//          Enable�Լ��� 1�� �����

public class ValueManager_Ball : MonoBehaviour
{
    //������ ���� ����
    public static int ranNum = 0;
    public static int ranQuestion = 0;
    public static int[] ranWrong = new int[3];
    public static int ranPosition = 0;

    //��ũ��Ʈor���� ������Ʈ Ȱ��ȭ������ �ѹ� ����
    void OnEnable()
    {
        GetRandomNumber();
    }

    private void Start()
    {
        
    }

    void GetRandomNumber()
    {
        ranNum = UnityEngine.Random.Range(10, 20);
        ranQuestion = UnityEngine.Random.Range(40, 60);
        ranWrong[0] = UnityEngine.Random.Range(20, 30);
        ranWrong[1] = UnityEngine.Random.Range(30, 40);
        ranWrong[2] = UnityEngine.Random.Range(40, 50);

        while (BallGameManager.correctAnswer == ranWrong[0]
               || BallGameManager.correctAnswer == ranWrong[1]
               || BallGameManager.correctAnswer == ranWrong[2])
        {
            ranWrong[0] = UnityEngine.Random.Range(20, 30);
            ranWrong[1] = UnityEngine.Random.Range(30, 40);
            ranWrong[2] = UnityEngine.Random.Range(40, 50);
        }

        ranPosition = UnityEngine.Random.Range(0, 3);
    }
}
