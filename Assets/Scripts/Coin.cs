using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Collectable
{
    private float currencyValue = 5.0f;

    protected override void giveCurrency()
    {
        scoreManager.addScore(currencyValue);
    }

    protected override void updateMovement()
    {
        if(transform.position.x < -screenBounds.x * 2){
            Destroy(this.gameObject);
        }
    }
}
