using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Collectable
{
    private int currencyValue = 1;

    protected override void giveCurrency()
    {
        currencyManager.addCurrency(currencyValue);
    }

    protected override void updateMovement()
    {
        if(transform.position.x < -screenBounds.x * 2){
            Destroy(this.gameObject);
        }
    }
}
