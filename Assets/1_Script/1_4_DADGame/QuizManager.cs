using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    BlueMouseDrag bmd;

    public int BlueBallCount;
    public int GreenBallCount;
    public int RedBallCount;
    public Text BlueRanNum;
    public Text GreenRanNum;
    public Text RedRanNum;
    
    // Start is called before the first frame update
    void Start()
    {
        BlueBallCount = Random.Range(1,3);
        //bmd.ballHit = false;
        
       

}

// Update is called once per frame
void Update()
    {
        BlueRanNum.text = BlueBallCount.ToString();
    }

}
