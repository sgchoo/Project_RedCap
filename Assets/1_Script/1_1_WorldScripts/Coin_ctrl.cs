using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Timers;
using UnityEngine;

public class Coin_ctrl : MonoBehaviour
{
    //¸ð¼Ç
    public float moveSpeed = 20f;
    public float moveHeight = 1f;
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float newY = Mathf.Sin(Time.time * moveSpeed) * moveHeight + startPosition.y;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }

    private void OnCollisionEnter(Collision other)
    {
        MainGameManager.coin++;
    }
}
