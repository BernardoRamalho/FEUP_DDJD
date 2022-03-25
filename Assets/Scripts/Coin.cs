using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Collectable
{
    public float scoreValue = 5.0f;

    public override void giveScore()
    {
        scoreManager.addScore(scoreValue);
    }
}
