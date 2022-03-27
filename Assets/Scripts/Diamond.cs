using UnityEngine;

public class Diamond : Collectable
{
    private int currencyValue = 15;
    public float ascendingVelocity = 1.0f;
    private bool isAscending = true;
    public int ascendingDuration = 100;
    private int movementTime = 0;
    protected override void giveCurrency()
    {
        currencyManager.addCurrency(currencyValue);
    }

    protected override void updateMovement()
    {
        if(transform.position.x < -screenBounds.x * 2){
            Destroy(this.gameObject);
            return;
        }

        movementTime = isAscending ?  movementTime + 1 : movementTime - 1;

        if(movementTime == ascendingDuration || movementTime == 0){
            isAscending  = !isAscending;
            return;
        }

       if(isAscending){
            rb.velocity = new Vector2(-speed, ascendingVelocity / movementTime);

       } else {
           rb.velocity = new Vector2(-speed, -ascendingVelocity / movementTime);
       }
    }
}
