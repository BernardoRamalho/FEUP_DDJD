using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public PlayerController2D playerController;
    public Weapon shootingController;

    public Animator animator;
    public Transform transform;

    Rigidbody2D rigidbody2D;

    float horizontalMove = 0f;

    bool jetpacking = false;

    public bool canShoot = true;
    public float shootingDelay;

    public float landingActivationVelocity = 0.0f;

    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
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
            animator.SetBool("IsLanding", false);
        }

        if (rigidbody2D.velocity.y < landingActivationVelocity)
        {
            animator.SetBool("IsLanding", true);
            animator.SetBool("IsJumping", false);
        }

        if (Input.GetButtonDown("Fire1") && canShoot)
        {
            shootingController.Shoot();
            canShoot = false;
            StartCoroutine(ShootDelay());
        }
    }

    IEnumerator ShootDelay()
    {
        yield return new WaitForSeconds(shootingDelay);
        canShoot = true;
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
        animator.SetBool("IsJumping", false);
    }
}
