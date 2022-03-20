using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController2D : MonoBehaviour
{
  public float m_JumpForce = 400f;

  public float m_JetpackForce = 0f;
  public float m_JetpackForceIncrease = 10f;
  public float m_JetpackMaxForce = 200f;
  public float m_JetpackForceDecrease = 10f;
  public float m_JetpackMinForce = 50f;

  public float m_MovementSmoothing = .05f;

  public LayerMask m_WhatIsGround;
  public Transform m_GroundCheck;
  public Transform m_CeilingCheck;

  private float k_GroundedRadius = .2f;
  private bool m_Grounded;
  private float k_CeilingRadius = .2f;

  private Rigidbody2D m_Rigidbody2D;

  private Vector3 m_Velocity = Vector3.zero;

  private void Awake()
  {
    m_Rigidbody2D = GetComponent<Rigidbody2D>();
  }

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
    if (m_Grounded) {
      Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);

      m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
    }

    if (jetpack) {
      m_JetpackForce += m_JetpackForceIncrease;
      if(m_JetpackForce >= m_JetpackMaxForce) {
        m_JetpackForce = m_JetpackMaxForce;
      }
      m_Rigidbody2D.AddForce(new Vector2(0f, m_JetpackForce));
    } else {
      m_JetpackForce -= m_JetpackForceDecrease;
      if (m_JetpackForce <= m_JetpackMinForce) {
        m_JetpackForce = m_JetpackMinForce;
      }
    }
  }
}
