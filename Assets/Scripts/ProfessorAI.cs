using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfessorAI : Enemy
{

    private PlayerController2D character;

    public float acceleration = 3.0f;
    public Weapon weapon;
    public Rigidbody2D rb;
    public int shootingRate = 100;

    public Health healthScript;

    [HideInInspector]
    private int shootingTimer = 0;

    private Vector2 screenBounds;

    private Animator anim;

    // Start is called before the first frame update

    public float moveSpeed;
    void Start()
    {
        anim = GetComponent<Animator>();

        rb = this.GetComponent<Rigidbody2D>();
        character = FindObjectOfType<PlayerController2D>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,Camera.main.transform.position.z));
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
        healthScript.health -= dmg;

        if(healthScript.health <= 0)
        {
            Destroy(gameObject);
        }
    }
    void Move(){
        float xMovement = 0.0f;

        if(transform.position.x > (screenBounds.x - screenBounds.x/3)){
            xMovement = -acceleration * 3;
        }

        if(character.transform.position.y - transform.position.y > 0.25 ){
            rb.velocity = new Vector2(xMovement, acceleration);

        }else if(character.transform.position.y - transform.position.y < - 0.25){
            rb.velocity = new Vector2(xMovement, -1 * acceleration);

        }else{
            rb.velocity = new Vector2(xMovement, 0.0f);
        }
    }

    void Attack() {
        shootingTimer++;

        if(shootingTimer >= shootingRate){
            if(healthScript.maxHealth / healthScript.health > 3.0){
                
                anim.Play("Professor_Shoot2");
                weapon.SpecialPower();
            }else{
                Debug.Log(anim);
                anim.Play("Professor_Shoot");
                weapon.Shoot();
            }
            shootingTimer = 0;
        }
    }
}
