using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animi : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 2f;
    private bool movingRight = true;
    public int health = 10;
    public float jumpForce = 10f;
    public float timeJump = 1;
    private float timeJumpS;
    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health<=0)
        {
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }
    void Start()
    {
        timeJumpS = timeJump;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        timeJump -= Time.deltaTime;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Left.animi")
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
            movingRight = !movingRight;
        }
        if (other.tag == "Right.animi")
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            movingRight = !movingRight;
        }
        if(other.tag =="animi.jump"&&timeJump<=0)
        {
            rb.velocity = Vector2.up * jumpForce;
            timeJump = timeJumpS;
        }
    }
 }
