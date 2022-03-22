using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    private PlayerController2D character;
    public float health = 100.0f;
    public float acceleration = 3.0f;
    public Weapon weapon;

    public int shootingRate = 0;

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
        if(character.transform.position.y - transform.position.y > 0.25 ){
            rb.velocity = new Vector2(0.0f, acceleration);
        }else if(character.transform.position.y - transform.position.y < - 0.25){
            rb.velocity = new Vector2(0.0f, -1 * acceleration);
        }else{
            rb.velocity = new Vector2(0.0f, 0.0f);
        }
        shootingRate++;

        if(shootingRate == 100){
            weapon.Shoot();
            shootingRate = 0;
        } 

    }
}
