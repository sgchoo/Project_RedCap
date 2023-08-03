using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickBall : MonoBehaviour
{
    public GameObject Balls;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnBall();
    }

    public void SpawnBall()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Instantiate(Balls);
        }
        
    }
    

}
