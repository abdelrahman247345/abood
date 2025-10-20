using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{public float moveSpeed;   // how fast the character moves
    public float jumpHeight;  // how high the character jumps

    // private bool isFacingRight; // check if player is facing right (currently commented out)

    // --- Input KeyCodes ---
    
    // Jump button (defaulted to Space in the Inspector based on the original image's context)
    public KeyCode Spacebar; // Jump is the name we gave a keyboard button we chose to be the jump button.
                             // In this case, we chose the Space button, and called it Spacebar. To allocate the Space button to the name
                             // Spacebar, go to the Script
                             // component of your player character, and choose Space from the dropdown list
    
    // Left movement key
    public KeyCode L; // L is the name we gave a keyboard button we chose to be the left movement button.
    
    // Right movement key
    public KeyCode R; // R is the name we gave a keyboard button we chose to be the right movement button.
public Transform groundCheck; // an invisible point in space. We use it to see if the player is touching
                                 // the ground
    public float groundCheckRadius; // a value to determine how big the circle around the player's feet is,
                                   // and therefore determine how close he is to the ground
    public LayerMask whatIsGround; // this variable stores what is considered a ground to the character
    private bool grounded; // check if the character is standing on solid ground


    void Start()
    {
        
    }
 void FixedUpdate()
    {
        // Check if the GroundCheck point overlaps with any collider on the 'whatIsGround' layer
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        // this statement calculates when exactly the character is considered by Unity's engine to be
        // standing on the ground.
    }
    // Update is called once per frame
    void Update()
    {  // 1. Jump Input Check
        // if (Input.GetKeyDown(Spacebar)) // When user presses the space button ONCE
        if (Input.GetKeyDown(Spacebar) && grounded) // Use GetKeyDown for single press activation
        {
            Jump(); // see function definition below
        }

        // 2. Left Movement Check
        // if (Input.GetKey(L)) // When user presses the left arrow button
        if (Input.GetKey(L)) // Use GetKey to check if the button is held down
        {
            // Set the horizontal velocity to -moveSpeed, keeping the current vertical velocity (y)
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            // player character moves horizontally to the left along the x-axis without disrupting jump
            // Flipping the sprite to face left
            if (GetComponent<SpriteRenderer>() != null)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
        }

        // 3. Right Movement Check
        // if (Input.GetKey(R)) // When user presses the right arrow button
        if (Input.GetKey(R)) // Use GetKey to check if the button is held down
        {
            // Set the horizontal velocity to +moveSpeed, keeping the current vertical velocity (y)
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            // player character moves horizontally to the right along the x-axis without disrupting jump
            if (GetComponent<SpriteRenderer>() != null)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
        }


        void Jump()
    {
        // Set the vertical velocity to jumpHeight, keeping the current horizontal velocity (x)
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
        // player character jumps vertically along the y-axis without disrupting horizontal walk
    }
        
    }
}
