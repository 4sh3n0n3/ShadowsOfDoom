﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator animator;

    public float speed = 40f;
    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * speed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }

    public void OnJumpEvent()
    {
        animator.SetBool("isJumping", true);
    }

    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("isCrouching", isCrouching);
    }

    public void OnLanding()
    {
        animator.SetBool("isJumping", false);
    }

    private void FixedUpdate()
    {
        float modifiedSpeed;
        if ((controller.MousePos.x < transform.position.x && horizontalMove < 0) || (controller.MousePos.x > transform.position.x && horizontalMove > 0))
        {
            modifiedSpeed = horizontalMove;
        } else
        {
            modifiedSpeed = horizontalMove / 2;
        }
        controller.Move(modifiedSpeed * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
