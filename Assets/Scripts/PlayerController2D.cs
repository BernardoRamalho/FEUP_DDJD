using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController2D : MonoBehaviour
{
  public LayerMask m_WhatIsGround;
  public Transform m_GroundCheck;
  public Transform m_CeilingCheck;

  private float k_GroundedRadius = .2f;
  private bool m_Grounded;
  private float k_CeilingRadius = .2f;

  private Rigidbody2D m_Rigidbody2D;

  public MoveScript moveScript;
  public JetpackScript jetpackScript;

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

  private void OnLandingEvent() {
    m_Grounded = true;
  }

  private void OnCeilingEvent() {

  }

  public void Move(float move, bool jetpack) {
    /*if (m_Grounded) {
        moveScript.Move(move);
    }*/
    moveScript.Move(move);

    if (jetpack) {
      jetpackScript.Activate();
    }
  }
}
