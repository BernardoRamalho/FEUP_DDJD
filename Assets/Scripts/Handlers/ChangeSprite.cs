using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    public Sprite firstSprite;
    public Sprite secondSprite;

    private bool firstSpriteActive = true;

    private void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    public void SwitchSprite()
    {
        if (firstSpriteActive) {
            spriteRenderer.sprite = secondSprite;
            firstSpriteActive = false;
        } else {
            spriteRenderer.sprite = firstSprite;
            firstSpriteActive = true;
        }
    }
}
