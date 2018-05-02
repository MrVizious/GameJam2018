using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LucyMovementScript : MonoBehaviour {
    [Header("Character")]
    private Transform child;
    private Rigidbody2D myRigidbody;
    private int direction;
    public float velocity = 8f;
    private float currentVelocity;
    private bool IsDying = false;

    [Header("Animation")]
    private Animator myAnim;

    // Use this for initialization
    void Start ()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        child = transform.GetChild(0);
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
                child.localScale = new Vector3(-1 * Mathf.Abs(child.localScale.x), child.localScale.y, 1);
            }
            else if (direction > 0)
            {
                    child.localScale = new Vector3(Mathf.Abs(child.localScale.x), child.localScale.y, 1);
            }
        }

    public void Die()
    {
        IsDying = true;
        invoke("Respawn", 1f);
    }

    private void Respawn()
    {
        GameManagerScript.GetGameManager().Respawn();
    }
}
