using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coffee : PowerUp
{
    public float normalShootingDelay;
    public float improvedShootingDelay;
    public float effectDuration;
    public bool effectActive = false;

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

    protected override void StartPowerUp(GameObject playerGameObject) {
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
