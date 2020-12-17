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
    private bool isHidden = false;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    public LayerMask whatIsGrass;
     

    public GameObject plant;
    public GameObject spawnerkiller;
    public Transform firePoint;
    public Renderer rend;


    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
                rend = GetComponent<Renderer>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        
        Debug.Log(isHidden);

        if(gameObject.CompareTag("player")){
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if(facingRight == false && moveInput > 0) {
            Flip();
        } else if(facingRight == true && moveInput < 0){
            Flip();
        }

        }

        /*if(|Mathf.Approximately(0, Speed)) 
        {
            transform.rotation = movement > 0 ? Quaternion.Euler(0.180.0) : Quaternion.identity;
        }
        */





    }


    void Update (){

        if(Input.GetButtonDown("Jump") && isGrounded == true && gameObject.CompareTag("player")) 
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            
        }

        if(Input.GetButtonDown("X") && gameObject.CompareTag("player"))
        {
        
        
        isHidden = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGrass);
        Debug.Log("rodou 1");
        rb.velocity = new Vector2(0 * 0, 0);
        gameObject.tag = "basemode";
        rend.enabled = false;
        Instantiate(plant, firePoint.position, firePoint.rotation);
         
        
        
        
        }

        if(Input.GetButtonDown("Z") && gameObject.CompareTag("basemode"))
        {
        
        Instantiate(spawnerkiller, firePoint.position, firePoint.rotation);
        Debug.Log(gameObject.tag);
        Debug.Log("rodou 2");
         
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        gameObject.tag = "player";
        rend.enabled = true;
        isHidden = false;
         
        
        }

    }

    //Player Hit

    void OnCollisionEnter2D(Collision2D collision)
 {

   if (collision.gameObject.CompareTag("destroy") && isHidden == false)
   {
     Application.LoadLevel(0);
     
   }

 }

    void Flip(){
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;

    }

    IEnumerator ExampleCoroutine()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(1);

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }
}
