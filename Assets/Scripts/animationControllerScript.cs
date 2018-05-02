using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(playerJumpScript))]
[RequireComponent(typeof(playerMovementScript))]
[RequireComponent(typeof(PlayerDeath))]
[RequireComponent(typeof(Animator))]
public class animationControllerScript : MonoBehaviour {

    //Private variables
    playerJumpScript jumpScript;
    playerMovementScript movementScript;
    SpriteRenderer spriteRenderer;
    Animator animator;
    PlayerDeath playerDeath;




	// Use this for initialization
	void Start () {
        jumpScript = GetComponent<playerJumpScript>();
        movementScript = GetComponent<playerMovementScript>();
        spriteRenderer = transform.Find("Lucy").GetComponent<SpriteRenderer>();
        playerDeath = GetComponent<PlayerDeath>();
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        checkDirection();
        checkAnimation();
	}

    void checkDirection()
    {
        if(movementScript.direction > 0)
        {
            spriteRenderer.flipX = false;

        } else if( movementScript.direction < 0)
        {
            spriteRenderer.flipX = true;
        }
    }

    void checkAnimation()
    {
        //animator.SetBool("IsDead", playerDeath.IsDead);
        animator.SetBool("IsFalling", jumpScript.isFalling);
        animator.SetBool("IsRising", jumpScript.isRising);
        animator.SetBool("IsMoving", movementScript.isMoving);
        animator.SetBool("IsGrounded", jumpScript._IsGrounded);


    }
}
