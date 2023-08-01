using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_stop : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("exit_bool", true);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            animator.SetBool("exit_bool", false);
        }
    }
}
