using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMovement : MonoBehaviour
{

    public Transform transform;

    public float speed = 1f;

    public Vector3 resetFromPosition = new Vector3(-20, 0, 0);
    public Vector3 resetToPosition = new Vector3(20, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        transform.position = transform.position + new Vector3(-1f * speed * Time.deltaTime, 0, 0);
        if (transform.position.x < resetFromPosition.x)
        {
            transform.position = resetToPosition;
        }
    }

    void resetPosition()
    {
        transform.position = resetToPosition;
    }
}
