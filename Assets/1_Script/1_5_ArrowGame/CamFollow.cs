using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Summary : ī�޶�� �÷��̾� ������ ��ġ�� ����ؼ�
//          �÷��̾ �i�� �����
//          x�ุ �����̱⶧���� Lerp�Լ��� �̿��ؼ� �ε巴�� ������� �����

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
