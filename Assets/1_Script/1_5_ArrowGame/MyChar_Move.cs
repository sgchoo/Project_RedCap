using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//���� ������(����) ���¸� ���� �ڷ�Ÿ��
//public enum ActionMode
//{
//    Move,
//    ArrorMode
//}




public class MyChar_Move : MonoBehaviour
{

    public GameObject bowmode_Par;

    AudioSource shoot_wav;

    //public int bowCount;

    public GameObject BowCamSnd;

    public float speed = 5;

    public float sensitivity = 5.0f;  // ���콺 ����

    //public GameObject subCamera; -> ȸ�ǰ�� ����

    public GameObject arrowCamera;

    public GameObject mainCamera;

    public Transform arrow;
    public Transform firePos;


    public GameObject Findlr;
   

    //ActionMode My_act;


    void Start()
    {
       
    }

   
    void Update()
    {
        ////dir_x = Input.GetButtonDown("Vertical");
        ////this.transform.position += Vector3.right * Time.deltaTime * speed;

        //float h = Input.GetAxis("Horizontal");  // -1 0 1
        //   // -1 0 1
        //Vector3 dir = new Vector3(h, 0, 0);     // ����
        //this.transform.position += dir * Time.deltaTime * speed;
        WalkMode();
        ArrorMode();

      //  ArrowSnd();
        //if (BowCamSnd.activeSelf == true)
        //{
        //    Arrow_Ready_Snd();
        //}


    }


    void WalkMode()
    {
        float h = Input.GetAxis("Horizontal");  // -1 0 1
                                                // -1 0 1
        Vector3 dir = new Vector3(h, 0, 0);     // ����
        this.transform.position += dir * Time.deltaTime * speed;
        
        if(Input.GetMouseButton(1) == true || Input.GetMouseButtonUp(1) == true)
        {
            this.transform.position = new Vector3(0, 1, 0);
        }


    }



   

    //void myAction()
    //{
    //    switch(My_act)
    //    {
    //        case ActionMode.Move:
    //    }
    //}


    void Arrow_shoot()
    {

        shoot_wav = this.GetComponent<AudioSource>();
        shoot_wav.loop = false;
        shoot_wav.playOnAwake = false;

        if (shoot_wav.isPlaying == true) //������̸�
        {
            shoot_wav.Stop();   //���߰�
        }
        shoot_wav.Play();



    }

    //void ArrowSnd()
    //{
    //    if (Input.GetMouseButtonDown(1) == true)
    //    {
    //        BowCamSnd.SetActive(true);
    //    }
    //}

    

    void ArrorMode()
    {
        if (Input.GetMouseButton(1) == true)
        {

            BowCamSnd.SetActive(true);
            bowmode_Par.SetActive(true);

      

            //subCamera.gameObject.SetActive(true); -> ȸ�ǰ�� ����
            arrowCamera.gameObject.SetActive(true);
            mainCamera.gameObject.SetActive(false);

            LineRenderer lrOnOff =  Findlr.GetComponent<LineRenderer>();
            lrOnOff.enabled = true;

            float mouseX = Input.GetAxis("Mouse X") * sensitivity;  // ���콺 X�� �̵���
            float mouseY = Input.GetAxis("Mouse Y") * sensitivity;  // ���콺 Y�� �̵���

            transform.Rotate(-mouseY, mouseX, 0);  // ī�޶� ȸ��
                                                   // Vector3 dir = new Vector3(0, 0, 0);



            






            if (Input.GetMouseButtonDown(0) == true)
            {
                //Transform temp = Instantiate(this.arrow);
                //temp.transform.position = firePos.transform.position;
                Instantiate(arrow, firePos.position, firePos.rotation);

                //shoot_wav.Play();
                Arrow_shoot();


            }
        }

        else if (Input.GetMouseButtonUp(1) == true)
        {

            bowmode_Par.SetActive(false);
            LineRenderer lrOnOff = Findlr.GetComponent<LineRenderer>();
            lrOnOff.enabled = false;
           

            //subCamera.gameObject.SetActive(false); -> ȸ�ǰ�� ����
            arrowCamera.gameObject.SetActive(false);
            mainCamera.gameObject.SetActive(true);


            float h = Input.GetAxis("Horizontal");  // -1 0 1
                                                    // -1 0 1
            Vector3 dir = new Vector3(h, 0, 0);     // ����
            this.transform.position += dir * Time.deltaTime * speed;

            BowCamSnd.SetActive(false);

        }

      
    }
}
