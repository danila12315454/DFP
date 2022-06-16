   using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Moovment : MonoBehaviour
{
    Rigidbody2D rb;
    public bool facingRite = true;
    public float speed;
    private float moveInput;
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    public int extraJumps;
    private int extraJumpsS;
    public int jumpForce;
    private Vector3 difference;
    public int HP = 100;
    public int HillN = 30;
    void Start()
    {
        extraJumpsS = extraJumps;
       rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);
        moveInput = Input.GetAxis("Horizontal");
        if(facingRite == false && moveInput>0)
        {
            flip();
        }else if(facingRite==true && moveInput<0)
        {
            flip();
        }
        if(moveInput==0 && facingRite == true && difference.x<0)
        {
            flip();
        }else if (moveInput == 0 && facingRite == false && difference.x > 0)
        {
            flip();
        }
    }
    void jump()
    {
        rb.AddForce (transform.up * 10f, ForceMode2D.Impulse);
    }
    void flip()
    {
        facingRite = !facingRite;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
    private void Update()
    {
        if (isGrounded==true)
        {
            extraJumps = extraJumpsS;
        }
        if (Input.GetKeyDown(KeyCode.W) && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }
        else if (Input.GetKeyDown(KeyCode.W) && extraJumps == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
        }    
       }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag== "Lovushka")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if(other.tag == "Hill")
        {
            HP += HillN;
            Destroy(other.gameObject);
        }
    }
    void OnGUI()
    {
        GUI.Box(new Rect(0, 31, 100, 30), "HP:" + HP);
    }
}