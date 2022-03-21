using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{

    private Rigidbody2D m_Rigidbody2D;

    private Vector3 m_Velocity = Vector3.zero;
    public float m_MovementSmoothing = .05f;

    private void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Move(float speed)
    {
        Vector3 targetVelocity = new Vector2(speed * 10f, m_Rigidbody2D.velocity.y);

        m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
    }
}
