using UnityEngine;

public class Diamond : Collectable
{
    private float currencyValue = 25.0f;
    public float ascendingVelocity = 1.0f;
    private bool isAscending = true;
    public int ascendingDuration = 100;
    private int movementTime = 0;
    protected override void giveCurrency()
    {
        scoreManager.addScore(currencyValue);
    }

    protected override void updateMovement()
    {
        if(transform.position.x < -screenBounds.x * 2){
            Destroy(this.gameObject);
            return;
        }

        movementTime++;

        if(movementTime == ascendingDuration){
            isAscending  = false;
        }

       if(isAscending){
            rb.velocity = new Vector2(-speed, ascendingVelocity);

       } else {
           rb.velocity = new Vector2(-speed, -ascendingVelocity);
       }
    }
}
