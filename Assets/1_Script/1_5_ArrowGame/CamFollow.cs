using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Summary : 카메라와 플레이어 사이의 위치를 계산해서
//          플레이어를 쫒게 만든다
//          x축만 움직이기때문에 Lerp함수를 이용해서 부드럽게 따라오게 만든다

public class CamFollow : MonoBehaviour
{
    public Transform player;

    Vector3 offset;

    void Start()
    {
        CamOffset();
    }

    void Update()
    {
        CamPosition();
    }

    void CamOffset()
    {
        offset = this.transform.position - player.position;
    }

    void CamPosition()
    {
        this.transform.position = player.position + offset;

        //this.transform.position = Vector3.Lerp(player.position, offset, 0.125f);
    }
}
