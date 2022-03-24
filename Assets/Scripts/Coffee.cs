using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coffee : MonoBehaviour
{
    public float speed = 10.0f;
    private Rigidbody2D rb;
    private Vector2 screenBounds;

    public float normalShootingDelay;
    public float improvedShootingDelay;
    public float effectDuration;
    public bool effectActive = false;

    // Start is called before the first frame update
    void Awake()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-speed, 0);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -screenBounds.x * 2 && !effectActive){
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D (Collider2D hitInfo)
    {
        if (hitInfo.name == "Player"){
            StartPowerUp(hitInfo.gameObject);
            HideSprite();
            StartCoroutine(EndPowerUp(hitInfo.gameObject));
        }
    }

    private void StartPowerUp(GameObject playerGameObject) {
        MovementScript script = playerGameObject.GetComponent<MovementScript>();
        script.shootingDelay = improvedShootingDelay;
        effectActive = true;
    }

    private void HideSprite() {
      this.GetComponent<SpriteRenderer>().enabled = false;
    }

    IEnumerator EndPowerUp(GameObject playerGameObject)
    {
        yield return new WaitForSeconds(effectDuration);
        MovementScript script = playerGameObject.GetComponent<MovementScript>();
        script.shootingDelay = normalShootingDelay;
        Destroy(gameObject);
    }
}
