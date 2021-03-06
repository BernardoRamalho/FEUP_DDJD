using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugAI : Enemy
{
    private PlayerController2D character;

    public float maxHealth = 50.0f;
    public float health;
    public float acceleration = 10.0f;
    public Rigidbody2D rb;
    public int chargingTime = 75;
    public float scaleFactor = 0.005f;
    public float chargingSpeed = 1.7f;
    private Vector2 screenBounds;

    [HideInInspector] private int timer = 0;
    [HideInInspector] private bool isCharging = false;

    private enum State {
        Moving,
        Growing,
        Attacking
    }

    private State state = State.Moving;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        rb = this.GetComponent<Rigidbody2D>();
        character = FindObjectOfType<PlayerController2D>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {   
        switch(state){
            case State.Moving:
                Move();
                break;
            case State.Growing:
                Grow();
                break;
            case State.Attacking:
                Attack();
                break;
        }     
        
    }

    void Move(){
        float x = 0.0f;

        if(transform.position.x > (screenBounds.x- screenBounds.x/3)){
            x = -acceleration;   
        }

        if(x == 0.0f){
            state = State.Growing;
        }
 
        rb.velocity = new Vector2(x, 0.0f);
        
    }

    void Grow(){
        timer++;

        if(timer == chargingTime){
            state = State.Attacking;
            return;
        }

        transform.localScale = new Vector3(transform.localScale.x + scaleFactor, transform.localScale.y + scaleFactor, transform.localScale.z);
    }

    void Attack(){
        if(isCharging){
            if(transform.position.x < (-1 * screenBounds.x)){
                Destroy(gameObject);
            }
        }
        else{
            if(character == null){
                 rb.velocity = new Vector2(-1 * chargingSpeed, -1 * chargingSpeed);
                return;
            }

            float xDistance = character.transform.position.x - transform.position.x;
            float yDistance = character.transform.position.y - transform.position.y;

            rb.velocity = new Vector2(xDistance * chargingSpeed, yDistance * chargingSpeed);
            isCharging = true;
        }
    }

    void OnTriggerEnter2D (Collider2D hitInfo)
    {   
        if(hitInfo.name == "Bullet(Clone)"){
            TakeDamage(character.damage);
        }
        else if(hitInfo.name == "Player"){
            Destroy(gameObject);
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
}

