using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    private PlayerController2D character;
    public float health = 100.0f;

    public Rigidbody2D rb;
    // Start is called before the first frame update

    public float moveSpeed;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        character = FindObjectOfType<PlayerController2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(Random.Range(-10.0f, 10.0f),Random.Range(-10.0f, 10.0f));
        Debug.Log(transform.position);
        //transform.position = Vector3.MoveTowards(transform.position,)
    }
}
