using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collectable : MonoBehaviour
{
    protected float speed = 10.0f;
    protected Rigidbody2D rb;
    protected Vector2 screenBounds;
    protected CurrencyManager currencyManager;

    
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        
        rb.velocity = new Vector2(-speed, 0);

        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,Camera.main.transform.position.z));

        currencyManager = FindObjectOfType<CurrencyManager>();
    }


    // Update is called once per frame
    void Update()
    {
        updateMovement();
    }

    void OnTriggerEnter2D (Collider2D hitInfo)
    { 
        if(hitInfo.name == "Player"){
            Destroy(gameObject);
            giveCurrency();
        }
    }

    public void incrementSpeed(float speedIncrement){
        speed = speed + speedIncrement;
    }
    protected abstract void giveCurrency();

    protected abstract void updateMovement();
}
