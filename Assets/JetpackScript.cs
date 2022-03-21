using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetpackScript : MonoBehaviour
{

    private Rigidbody2D m_Rigidbody2D;

    public float m_JetpackForce = 0f;
    public float m_JetpackForceIncrease = 10f;
    public float m_JetpackMaxForce = 200f;
    public float m_JetpackForceDecrease = 10f;
    public float m_JetpackMinForce = 50f;

    private void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void IncreaseForce()
    {
        m_JetpackForce += m_JetpackForceIncrease;
        if (m_JetpackForce >= m_JetpackMaxForce)
        {
            m_JetpackForce = m_JetpackMaxForce;
        }
    }

    public void DecreaseForce()
    {
        m_JetpackForce -= m_JetpackForceDecrease;
        if (m_JetpackForce <= m_JetpackMinForce)
        {
            m_JetpackForce = m_JetpackMinForce;
        }
    }

    public void Activate()
    {
        m_Rigidbody2D.AddForce(new Vector2(0f, m_JetpackForce));
    }
}
