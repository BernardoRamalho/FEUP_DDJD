using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public PlayerController2D playerController;
    public Weapon shootingController;

    public Animator animator;
    public Transform transform;

    float horizontalMove = 0f;

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
        horizontalMove = Input.GetAxisRaw("Horizontal");

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButton("Jump"))
        {
            jetpacking = true;
            animator.SetBool("IsJumping", true);
        }

        if (lastY > transform.position.y && transform.position.y < landingActivationY)
        {
            animator.SetBool("IsLanding", true);
        }

        lastY = transform.position.y;

        if (Input.GetButtonDown("Fire1"))
        {
            shootingController.Shoot();
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        animator.SetBool("IsJumping", false);
        animator.SetBool("IsLanding", false);
    }

    void FixedUpdate()
    {
        playerController.Move(horizontalMove, jetpacking);
        jetpacking = false;
    }
}
