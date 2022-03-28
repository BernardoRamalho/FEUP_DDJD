using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : PowerUp
{
    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -screenBounds.x * 2){
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D (Collider2D hitInfo)
    {
        if (hitInfo.name == "Player"){
            StartPowerUp(hitInfo.gameObject);
            Destroy(this.gameObject);
        }
    }

    protected override void StartPowerUp(GameObject playerGameObject) {
        PlayerController2D script = playerGameObject.GetComponent<PlayerController2D>();

        script.activateShield();
    }
}
