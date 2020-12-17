using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public float runSpeed = 20f;
    float horizontalMove = 0f;
    bool jump = false;
    public GameObject plant;
    public Transform firePoint;

 

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if(Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        //Shooting
        if(Input.GetButtonDown("X"))
        {
        Instantiate(plant, firePoint.position, firePoint.rotation);
        }
        
    }

        void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
        
    }
}
