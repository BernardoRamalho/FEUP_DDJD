using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    private PlayerController2D character;
    public float health = 100.0f;
    public float acceleration = 3.0f;
    
    public Rigidbody2D rb;
    // Start is called before the first frame update

    public float moveSpeed;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        character = FindObjectOfType<PlayerController2D>();
    }

    // Update is called once per frame
    void Update()
    {   
        Debug.Log(character.transform.position.y);
        if(character.transform.position.y > transform.position.y){
            rb.velocity = new Vector2(0.0f,acceleration);
            Debug.Log(transform.position);
        }else if(character.transform.position.y < transform.position.y){
            rb.velocity = new Vector2(0.0f, -1 * acceleration);
        }
       
        
        //transform.position = Vector3.MoveTowards(transform.position,)
    }
}
