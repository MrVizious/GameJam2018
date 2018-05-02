using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class playerMovementScript : MonoBehaviour
{

    //Components
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;

    //Public variables
    public float speed = 5f;
    public bool isMoving;

    //Script info
    float direction = 1; // Right > 0, Left < 0


    // Use this for initialization
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

        direction = Input.GetAxis("Horizontal");

    }

    void LateUpdate()
    {
        if (speed != 0) isMoving = true;
        else isMoving = false;
    }


    private void FixedUpdate()
    {
        rb.velocity = new Vector2(direction * speed, rb.velocity.y);
    }

}
