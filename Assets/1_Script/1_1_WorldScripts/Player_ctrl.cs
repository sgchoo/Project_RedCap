using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

//Summary : 트리거에 걸리면 스크린 UI활성화

public class Player_ctrl : MonoBehaviour
{

    public GameObject CoinSound;
    public AudioSource stepSound;

    public float speed = 40;
    float jumpForce = 120f;

    float rot_speed = 120f;
    float dir_v;
    float rot_h;
  
    private bool isGround = true;

    public GameObject storyUI;
    public GameObject tutorialUI;

    public GameObject tutoralObjs;

    Rigidbody playerrigidbody;
    Animator anim;
    Vector3 moveDir;

    void Start()
    {
        playerrigidbody = this.GetComponent<Rigidbody>();
        stepSound = this.GetComponent<AudioSource>();
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        Move();
        Jump();
        StepSound();
        
    }

    void Move()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        moveDir = new Vector3(0f, 0f, moveZ).normalized;

        anim.SetBool("isRun", moveDir != Vector3.zero);

        transform.Translate(moveDir * Time.deltaTime * speed);
        this.transform.Rotate(Vector3.up * Time.deltaTime * rot_speed * moveX);
    }
 
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            playerrigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGround = false;
        }
        anim.SetFloat("jump_Float", playerrigidbody.velocity.y);
    }

    private void OnCollisionEnter(Collision collision)
    {
        playerrigidbody.velocity = Vector3.zero;
        playerrigidbody.angularVelocity = Vector3.zero;

        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }
     
        if(collision.gameObject.CompareTag("Coin"))
        {
            Instantiate(CoinSound);
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "TutorialTrigger")
        {
            tutoralObjs.SetActive(true);
            tutorialUI.SetActive(true);
        }

        else if (other.gameObject.name == "StoryTrigger")
        {
            storyUI.SetActive(true);
        }

        if (other.gameObject.name == "WoodLand")
        {
            tutoralObjs.SetActive(false);
        }

        if (other.gameObject.tag == "Ending")
        {
            MainGameManager.isEnded = true;
            SceneManager.LoadScene("LoadingScene");
        }
    }

    void StepSound()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)
            || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            stepSound.enabled = true;
        }
        else 
        {
            stepSound.enabled = false;
        }

    }
}
  