using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMovement : MonoBehaviour
{
    public float speed = 1f;

    public float resetFromX = -24f;
    public float resetToX = 24f;

     private ScoreManager scoreManager;

    void Start(){
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    void FixedUpdate()
    {   
        
        speed = 5.0f + scoreManager.scoreCount / 150.0f;

        transform.position = transform.position + new Vector3(-1f * speed * Time.deltaTime, 0, 0);
        
        if (transform.position.x < resetFromX)
        {
            resetPosition();
        }
    }

    void resetPosition()
    {
        transform.position = new Vector3(resetToX, transform.position.y, transform.position.z);
    }
}
