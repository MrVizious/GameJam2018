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

    [Header("Ground detection")]
    private bool _IsGrounded;
    LayerMask Ground;
    public float width;
    public float heigth;
    private float RayLength = 0.1f;
    private bool DoubleJump = true;
    Vector3 rightOrigin;
    Vector3 leftOrigin;

    [Header("Animation")]
    private Animator myAnim;


    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        //animator = GetComponent<Animator>();
        Ground = (1 << LayerMask.NameToLayer("Ground"));
        myAnim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        
        IsGrounded();
        if (_IsGrounded && Input.GetButtonDown("Jump"))
            Jump();
        else if ((!_IsGrounded && DoubleJump) && Input.GetButtonDown("Jump"))
        {
            DoubleJump = false;
            Jump();
        }
    }

    void LateUpdate()
    {
        myAnim.SetBool("IsGrounded", _IsGrounded);
    }

    private void Jump()
    {
        rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
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
            DoubleJump = true;
    }
}
