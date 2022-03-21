using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLimitsScript : MonoBehaviour
{

    private Rigidbody2D m_Rigidbody2D;
    private BoxCollider2D m_BoxCollider2D;

    private float characterHeight;
    private float characterWidth;

    private void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        m_BoxCollider2D = GetComponent<BoxCollider2D>();

        characterHeight = m_BoxCollider2D.size.y;
        characterWidth = m_BoxCollider2D.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 minScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        Vector3 maxScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minScreenBounds.x + 1, maxScreenBounds.x - 1), Mathf.Clamp(transform.position.y, minScreenBounds.y + 1, maxScreenBounds.y - 1), transform.position.z);
        
        if (transform.position.y > maxScreenBounds.y - 1.1)
            m_Rigidbody2D.velocity = new Vector3(0, 0, 0);
    }
}
