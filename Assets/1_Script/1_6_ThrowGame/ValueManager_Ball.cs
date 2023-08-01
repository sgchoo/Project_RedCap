using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Summary : 랜덤값 생성 후
//          BallGameManager에 값 전달
//          BallGameManager에서 공이 던져지면
//          코루틴으로 스크립트 비활성화 및 1.5f초 후 활성화
//          Enable함수로 1번 재실행

public class ValueManager_Ball : MonoBehaviour
{
    //랜덤값 대입 변수
    public static int ranNum = 0;
    public static int ranQuestion = 0;
    public static int[] ranWrong = new int[3];
    public static int ranPosition = 0;

    //스크립트or게임 오브젝트 활성화때마다 한번 실행
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
