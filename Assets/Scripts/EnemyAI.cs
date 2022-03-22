using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    private PlayerController2D character;
    public float health = 100.0f;
    public float acceleration = 3.0f;
    public Weapon weapon;
    public Rigidbody2D rb;
    public int shootingRate = 100;

    [HideInInspector]
    private int shootingTimer = 0;

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
        Move();
        
        Attack();
    }

    void OnTriggerEnter2D (Collider2D hitInfo)
    { 
        if(hitInfo.name == "Bullet(Clone)"){
            TakeDamage(character.damage);
        }
    }

    private void TakeDamage (float dmg)
    {
        health -= dmg;

        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
    void Move(){
        if(character.transform.position.y - transform.position.y > 0.25 ){
            rb.velocity = new Vector2(0.0f, acceleration);
        }else if(character.transform.position.y - transform.position.y < - 0.25){
            rb.velocity = new Vector2(0.0f, -1 * acceleration);
        }else{
            rb.velocity = new Vector2(0.0f, 0.0f);
        }
    }

    void Attack() {
        shootingTimer++;

        if(shootingTimer >= shootingRate){
            weapon.Shoot();
            shootingTimer = 0;
        } 
    }
}
