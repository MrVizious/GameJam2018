using System.Collections;
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

    //Script info
    float direction = 1; // Right > 0, Left < 0


    // Use this for initialization
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {

        direction = Input.GetAxis("Horizontal");
        Render();

    }

    void Render()
    {
        if (direction > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (direction < 0)
        {
            spriteRenderer.flipX = true;
        }
    }


    private void FixedUpdate()
    {
        rb.velocity = new Vector2(direction * speed, rb.velocity.y);
    }

}
