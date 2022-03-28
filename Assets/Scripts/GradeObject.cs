using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GradeObject : Obstacle
{
    public int health = 3;

    public void TakeDamage (int dmg)
    {
        health -= dmg;

        if(health <= 0)
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
