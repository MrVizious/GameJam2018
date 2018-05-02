using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
//[RequireComponent(typeof(Animator))]
public class playerJumpScript : MonoBehaviour {
    
    //Components
    Rigidbody2D rb;

    //Public variables
    public float jumpForce = 5f;
    public int maxNumberOfJumps = 2;

    //Private variables
    private int numberOfJumpsMade = 0;

    [Header("Ground detection")]
    public bool _IsGrounded;
    LayerMask Ground;
    public float width;
    public float heigth;
    private float RayLength = 0.1f;
    Vector3 rightOrigin;
    Vector3 leftOrigin;


    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        //animator = GetComponent<Animator>();
        Ground = (1 << LayerMask.NameToLayer("Ground"));
    }
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetButtonDown("Jump"))
            Jump();
    }

    void Jump()
    {
        if (numberOfJumpsMade < maxNumberOfJumps)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            numberOfJumpsMade++;
        }
    }

     private void IsGrounded()
    {
        rightOrigin = transform.position + new Vector3(width, -heigth / 2, 0);
        leftOrigin = transform.position + new Vector3(-width, -heigth / 2, 0);

        RaycastHit2D rightRay = Physics2D.Raycast(rightOrigin, -Vector3.up, RayLength, Ground);
        RaycastHit2D leftRay = Physics2D.Raycast(leftOrigin, -Vector3.up, RayLength, Ground);

        Debug.DrawLine(rightOrigin, rightOrigin + -Vector3.up * RayLength, Color.red);
        Debug.DrawLine(leftOrigin, leftOrigin + -Vector3.up * RayLength, Color.red);

        _IsGrounded = rightRay.collider != null || leftRay.collider != null;

        if (_IsGrounded)
            numberOfJumpsMade = 0;
    }
}
