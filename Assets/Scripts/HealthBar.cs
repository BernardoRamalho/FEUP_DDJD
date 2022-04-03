using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{

    public GameObject target;
    public bool hideWhenFull;

    private Health healthScript;

    private float width;

    private SpriteRenderer spriteRenderer;

    public SpriteRenderer backgroundSpriteRenderer;
    public SpriteRenderer frameSpriteRenderer;

    void Awake()
    {
      healthScript = target.GetComponent<Health>();
      width = transform.localScale.x;
      spriteRenderer = GetComponent<SpriteRenderer>();

      if (hideWhenFull) {
        backgroundSpriteRenderer.enabled = false;
        frameSpriteRenderer.enabled = false;
        spriteRenderer.enabled = false;
      }
    }

    // Update is called once per frame
    void Update()
    {
      float health = healthScript.health / healthScript.maxHealth;
      transform.localScale = new Vector3(width * health, transform.localScale.y, transform.localScale.z);
      if (hideWhenFull && health < 1.00) {
        backgroundSpriteRenderer.enabled = true;
        frameSpriteRenderer.enabled = true;
        spriteRenderer.enabled = true;
      }

      if (health > 0.66) {
        spriteRenderer.color = Color.green;
      } else if (health > 0.33) {
        spriteRenderer.color = Color.yellow;
      } else {
        spriteRenderer.color = Color.red;
      }
    }
}
