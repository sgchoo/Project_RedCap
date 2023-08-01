using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poongMove1 : MonoBehaviour
{
    
    public float amplitude = 0.5f; // ǳ���� ����
    public float frequency = 1f; // ǳ���� ���ļ�
    public float speed = 1f; // ǳ���� �ӵ�

    private Vector3 startPos; // ǳ���� �ʱ� ��ġ

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float newY = startPos.y - amplitude * Mathf.Sin(frequency * Time.time * speed);
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
