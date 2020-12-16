using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePro : MonoBehaviour
{
    public float speed = 1;
    public float jumpForce = 1;
    public float moveInput;
    private bool facingRight = true;

    private bool isGrounded = true;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;


    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if(facingRight == false && moveInput > 0) {
            Flip();
        } else if(facingRight == true && moveInput < 0){
            Flip();
        }

        /*if(|Mathf.Approximately(0, Speed)) 
        {
            transform.rotation = movement > 0 ? Quaternion.Euler(0.180.0) : Quaternion.identity;
        }
        */





    }


    void Update (){

        if(Input.GetButtonDown("Jump") && isGrounded == true) 
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            
        }

    }

    void Flip(){
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;

    }
}
