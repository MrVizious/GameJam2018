using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
//[RequireComponent(typeof(Animator))]
public class playerJumpScript : MonoBehaviour {
    
    //Components
    Rigidbody2D rb;
    //Animator animator;

    //Public variables
    public float jumpForce = 5f;
    public int maxNumberOfJumps = 2;

    //Private variables
    private int numberOfJumpsMade = 0;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        //animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            Jump();
        }
        /*
        if (isGrounded)
        {
            numberOfJumpsMade = 0;
        }
        */
	}

    void Jump()
    {
        if (numberOfJumpsMade < maxNumberOfJumps)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            numberOfJumpsMade++;
        }
    }
}
