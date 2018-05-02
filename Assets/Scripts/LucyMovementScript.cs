using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class LucyMovementScript : MonoBehaviour {
    //[Header("Character")]
    //private Transform child;
    private Rigidbody2D myRigidbody;
    private int direction;
    public float velocity = 8f;
    private float currentVelocity;
<<<<<<< HEAD
    private SpriteRenderer spriteRenderer;
=======
    private bool IsDying = false;
>>>>>>> f2441836342a35ae6d1a823888469aa2e2beeff1

    [Header("Animation")]
    private Animator myAnim;

    // Use this for initialization
    void Start ()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        //child = transform.GetChild(0);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (IsDying) { return; }

        direction = 0;
        currentVelocity = Input.GetAxisRaw("Horizontal");

        if (currentVelocity < 0)
        {
            direction = -1;
            Flip();
            Move();
        }
        else if (currentVelocity > 0)
        {
            direction = 1;
            Flip();
            Move();
        }
    }

    private void Move()
    {
            myRigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * velocity, myRigidbody.velocity.y);
    }

    private void Flip()
    {
            if (direction < 0)
            {
                spriteRenderer.flipX = true;

                //child.localScale = new Vector3(-1 * Mathf.Abs(child.localScale.x), child.localScale.y, 1);
            }
            else if (direction > 0)
            {
                spriteRenderer.flipX = false;
                //child.localScale = new Vector3(Mathf.Abs(child.localScale.x), child.localScale.y, 1);
            }
<<<<<<< HEAD
=======
        }

    public void Die()
    {
        IsDying = true;
        invoke("Respawn", 1f);
    }

    private void Respawn()
    {
        GameManagerScript.GetGameManager().Respawn();
>>>>>>> f2441836342a35ae6d1a823888469aa2e2beeff1
    }
}
