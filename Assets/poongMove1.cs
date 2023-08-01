using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poongMove1 : MonoBehaviour
{
    
    public float amplitude = 0.5f; // Ç³¼±ÀÇ ÁøÆø
    public float frequency = 1f; // Ç³¼±ÀÇ ÁÖÆÄ¼ö
    public float speed = 1f; // Ç³¼±ÀÇ ¼Óµµ

    private Vector3 startPos; // Ç³¼±ÀÇ ÃÊ±â À§Ä¡

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
