using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow_Mode_eff : MonoBehaviour
{
    public GameObject bowmode_Par;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Bow_Mode_Par();
    }



    

    void Bow_Mode_Par()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            
        {
            GameObject bow_m_Par = Instantiate(bowmode_Par);
            //Destroy(bow_m_Par, 1.5f);


        }

    }


}
