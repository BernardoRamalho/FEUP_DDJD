using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GradeObject : MonoBehaviour
{
    public float speed = 10.0f;
    public int health = 3;
    private Rigidbody2D rb;
    private Vector2 screenBounds;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-speed, 0);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,Camera.main.transform.position.z));
    }

    public void TakeDamage (int dmg)
    {
        health -= dmg;

        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < -screenBounds.x * 2){
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D (Collider2D hitInfo)
    { 
        if(hitInfo.name == "Bullet(Clone)"){
            TakeDamage(1);
        }
        else if(hitInfo.name == "Player"){
            Destroy(gameObject);
        }
    }
}
