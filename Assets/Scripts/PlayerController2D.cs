using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerController2D : MonoBehaviour
{
  public LayerMask m_WhatIsGround;
  public Transform m_GroundCheck;
  public Transform m_CeilingCheck;

  private float k_GroundedRadius = .2f;
  private bool m_Grounded;

  private Rigidbody2D m_Rigidbody2D;

  public MoveScript moveScript;
  public JetpackScript jetpackScript;
  public float damage = 10f;

  public bool shieldActive = true;

  public Animator animator;

  // Update is called once per frame
  private void FixedUpdate()
  {
    m_Grounded = false;

    Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
    for (int i = 0; i < colliders.Length; i++) {
      if (colliders[i].gameObject != gameObject) {
        m_Grounded = true;
      }
    }
  }

  public void activateShield() {
    shieldActive = true;
    animator.SetBool("ShieldActive", true);
  }

  public void deactivateShield() {
    shieldActive = false;
    animator.SetBool("ShieldActive", false);
  }

  void OnTriggerEnter2D (Collider2D hitInfo)
    {
      if(hitInfo.name.StartsWith("Floor")){
        return;
      }

      if(hitInfo.name.StartsWith("PowerUp")){
        return;
      }

      if(hitInfo.name.StartsWith("Obstacle")){
        if (shieldActive) {
          deactivateShield();
          return;
        } else {
          SceneManager.LoadScene("GameScene");
          return;
        }
      }

      if(hitInfo.name.StartsWith("Enemy")){
        if (shieldActive) {
          deactivateShield();
          return;
        } else {
          SceneManager.LoadScene("GameScene");
          return;
        }
      }
    }

  public void Move(float move, bool jetpack) {
    moveScript.Move(move);

    if (jetpack) {
      jetpackScript.Activate();
    }
  }
}
