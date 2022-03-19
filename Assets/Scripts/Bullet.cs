using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{   
    public float speed = 20f;
    public Rigidbody2D rb;

    private Vector2 screenBounds;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,Camera.main.transform.position.z));

    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x > screenBounds.x * 2){
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D ()
    {
        Destroy(gameObject);
    }
}
