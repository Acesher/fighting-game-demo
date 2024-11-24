using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject doubleJumpEffect;

    public PlayerManager pManager;
    public Rigidbody2D rigidBody;
    private BoxCollider2D boxCollider;

    public LayerMask groundLayerMask;

    private float maxVelocity = 12f;
    private int jumpsRemaining;

    // Awake is called when it is first initiated
    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        jumpsRemaining = pManager.extraJumps;
    }

    // Update is called once per frame. Used for input checks
    private void Update()
    {
        if (!pManager.isDashing) // only allow movement when the character is not using the dash ability
        {
            if (Input.GetKey(pManager.RightKeyCode)) pManager.movementX = 1;
            else if (Input.GetKey(pManager.LeftKeyCode)) pManager.movementX = -1;
            else pManager.movementX = 0;

            // Jumping: when hit jump, the jumpsRemaining got decremented, but the next frame, the ground check will reset it because you are still counted as grounded. So the first jump doesn't decrease the jumpsRemaining, only the jumps in midair does.
            if (pManager.isGrounded)
            {
                jumpsRemaining = pManager.extraJumps;
            }

            if (Input.GetKeyDown(pManager.JumpKeyCode) && jumpsRemaining > 0)
            {
                rigidBody.velocity = Vector2.up * pManager.jumpForce;
                jumpsRemaining--;

                // only instantiate the double jump effect when it's a midair jump
                if (!pManager.isGrounded) Instantiate(doubleJumpEffect, transform.position, transform.rotation * Quaternion.Euler(0f, 0f, 180f));
            }
        }

        pManager.velocityY = rigidBody.velocity.y;
        groundCheck();
    }

    private void FixedUpdate()
    {
        if (rigidBody.velocity.magnitude > maxVelocity)
        {
            rigidBody.velocity = Vector2.ClampMagnitude(rigidBody.velocity, maxVelocity);
        }

        float xValue = pManager.movementX * pManager.moveForce;

        if (pManager.isDashing)
        {
            int xDir = 1;
            if (!pManager.isFacingRight) xDir = -1;

            xValue = xDir * pManager.dashForce;
        }

        rigidBody.velocity = new Vector2(xValue, rigidBody.velocity.y);
    }

    public void addForce(Vector2 force)
    {
        rigidBody.AddForce(force, ForceMode2D.Impulse);
    }

    private void groundCheck()
    {
        float extraMarginHeight = 0.05f;

        if (Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, extraMarginHeight, groundLayerMask))
        {
            pManager.isGrounded = true;
        }

        else pManager.isGrounded = false;
    }
}