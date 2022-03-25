using UnityEngine;

public class Diamond : Collectable
{
    public float scoreValue = 25.0f;

    public override void giveScore()
    {
        scoreManager.addScore(scoreValue);
    }
}
