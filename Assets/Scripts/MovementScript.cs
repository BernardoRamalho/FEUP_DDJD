using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public Transform transform;

    public float runSpeed = 40f;
    public float jetpackMaxSpeed = 5f;
    public float jetpackSpeed = 0f;

    float horizontalMove = 0f;

    bool jump = false;
    bool jetpacking = false;

    float lastY;
    public float landingActivationY = 1.0f;

    void Start()
    {
        lastY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }

        if (Input.GetButton("Jump"))
        {
            jetpacking = true;
        }

        if (lastY > transform.position.y && transform.position.y < landingActivationY)
        {
            animator.SetBool("IsLanding", true);
        }

        lastY = transform.position.y;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        animator.SetBool("IsJumping", false);
        animator.SetBool("IsLanding", false);
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, jump, jetpacking);
        jump = false;
        jetpacking = false;
    }
}
