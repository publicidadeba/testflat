﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePro: MonoBehaviour {
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
  public GameObject rock;
  public GameObject spawnerkiller;
  public GameObject treekiller;
  public Transform firePoint;
  public Renderer rend;
  private float status = 1;
  private float plantmagic = 0;
  private float rockmagic = 0;

  private Rigidbody2D rb;

  // Start is called before the first frame update
  void Start() {
    rb = GetComponent < Rigidbody2D > ();
    rend = GetComponent < Renderer > ();

  }

  // Update is called once per frame
  void FixedUpdate() {
    isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

    //Debug.Log(isHidden);

    if (gameObject.CompareTag("player")) {
      moveInput = Input.GetAxis("Horizontal");
      rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

      if (facingRight == false && moveInput > 0) {
        Flip();
      } else if (facingRight == true && moveInput < 0) {
        Flip();
      }

    }
 
  }

  void Update() {

//Jump
    if (Input.GetButtonDown("Jump") && isGrounded == true && gameObject.CompareTag("player")) {
      rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);

    }

//Morph Grass
    if (Input.GetButtonDown("X") && gameObject.CompareTag("player") && plantmagic == 1) {

      StartCoroutine(ExampleCoroutine());
      isHidden = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGrass);
      rb.velocity = new Vector2(0 * 0, 0);
      gameObject.tag = "basemode";
      rend.enabled = false;
      Instantiate(plant, firePoint.position, firePoint.rotation);

    }

//Morph Rock
    if (Input.GetButtonDown("X") && gameObject.CompareTag("player") && rockmagic == 1) {

      StartCoroutine(ExampleCoroutine());
      isHidden = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGrass);
      rb.velocity = new Vector2(0 * 0, 0);
      gameObject.tag = "basemode";
      rend.enabled = false;
      Instantiate(rock, firePoint.position, firePoint.rotation);
      rb.gravityScale = 20;

    }

//Morph Unmorph
    if (Input.GetButtonDown("X") && gameObject.CompareTag("basemode") && status == 0) {

     rb.gravityScale = 5;
     Instantiate(spawnerkiller, firePoint.position, firePoint.rotation);
      rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
      gameObject.tag = "player";
      rend.enabled = true;
      isHidden = false;
      status = 1;
    }
    
 //Break Tree
    Debug.Log(rb.velocity.y);
    if (rb.velocity.y < -70 && gameObject.CompareTag("basemode"))   {

      Instantiate(treekiller, firePoint.position, firePoint.rotation);

    }
    

  }

  //Player Hit

  void OnTriggerStay2D(Collider2D collision) {

    if (collision.gameObject.CompareTag("destroy") && isHidden == false) {

      Debug.Log("trigger working death");
      Application.LoadLevel(0);

    }

    //Plant Magic
        if (collision.gameObject.CompareTag("plantmagic")) {

      Debug.Log("trigger working plant magic");
      plantmagic = 1;

    }

        //Remove PlantMagic and Add RockMagic
        if (collision.gameObject.CompareTag("rockmagic")) {

      Debug.Log("trigger working rock magic");
      plantmagic = 0;
      rockmagic = 1;

    }

  }



 

  /*
    void OnCollisionEnter2D(Collision2D collision)
 {

   if (collision.gameObject.CompareTag("destroy") && isHidden == false)
   {
     Application.LoadLevel(0);
     
   }

 }
 */

  void Flip() {
    facingRight = !facingRight;
    Vector3 Scaler = transform.localScale;
    Scaler.x *= -1;
    transform.localScale = Scaler;

  }

  IEnumerator ExampleCoroutine() {
    //Print the time of when the function is first called.

    //yield on a new YieldInstruction that waits for 5 seconds.
    yield
    return new WaitForSeconds(0.2f);
    status = 0;

    //After we have waited 5 seconds print the time again.

  }
}