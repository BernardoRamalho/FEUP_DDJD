using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetpackScript : MonoBehaviour
{

    private Rigidbody2D m_Rigidbody2D;

    public float m_JetpackForce = 50f;

    private void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Activate()
    {
        m_Rigidbody2D.AddForce(new Vector2(0f, m_JetpackForce));
    }
}
