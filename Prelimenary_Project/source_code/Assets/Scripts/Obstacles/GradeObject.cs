using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GradeObject : Obstacle
{
    public Health healthScript;

    public void TakeDamage (int dmg)
    {
        healthScript.health -= dmg;

        if(healthScript.health <= 0)
        {
            Destroy(gameObject);
        }
    }


    void OnTriggerEnter2D (Collider2D hitInfo)
    {

        if (hitInfo.name == "Bullet(Clone)") {
            TakeDamage(1);
        }
        else if (hitInfo.name == "Player") {
            Destroy(gameObject);
        }
        else if (hitInfo.name == "Shield") {
            Destroy(gameObject);
        }
    }
}
