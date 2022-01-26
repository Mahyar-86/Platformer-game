using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController2D controller;

    private float horizontal = 0f;

    public float runSpeed = 40f;

    private bool jump= false;

    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal") * runSpeed;
        
        animator.SetFloat("Speed",Mathf.Abs(horizontal));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("Jump",true);
        }
    }

    private void FixedUpdate()
    {
        controller.Move(horizontal * Time.fixedDeltaTime,false,jump);
        jump = false;
    }

    public void OnLanding()
    {
        animator.SetBool("Jump",false);
    }
}
