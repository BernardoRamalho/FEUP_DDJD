using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChargedBullet : MonoBehaviour
{   
    public float speed = 10f;
    public Rigidbody2D rb;
    public int direction = -1;
    public float damage = 10f;
    private Vector2 screenBounds;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
 

        anim = GetComponent<Animator>();

        rb.velocity =  transform.right * speed * direction;
        
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,Camera.main.transform.position.z));

    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x > screenBounds.x * 2 || transform.position.x < screenBounds.x * -2){
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D (Collider2D hitInfo)
    {   
        Debug.Log(hitInfo.name);
        if(hitInfo.name != "Player"){
            return;
        }
        rb.velocity =  transform.right * 0;
        anim.Play("Enemy_Charged_Bullet_Hit");
        Destroy(gameObject,0.25f);
    }
}
