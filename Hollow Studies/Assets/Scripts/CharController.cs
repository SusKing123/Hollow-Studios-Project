using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;
    private bool isGrounded;

    private Rigidbody2D rb2d;

    void Start()
    {
        // get the rigidbody
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Horizontal Movement //
        float moveX = Input.GetAxis("Horizontal");
        rb2d.velocity = new Vector2(moveX * speed, rb2d.velocity.y);

        // Jumping if on the ground //
        // check if player is grounded and if the jump button is down
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
            isGrounded = false; // set jump to false so no air jump
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        // Checks if the collider player is touching is floor
        if (other.gameObject.CompareTag("Floor"))
        {
            isGrounded = true;
        }
    }
}
