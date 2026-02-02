using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    public float speed = 0.5f;
    public float gravity = -9.81f * 30;
    public float jumpHeight = 1f;
 
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float fallMultiplier = 2.5f;  // faster fall
    public float lowJumpMultiplier = 2f; // optional: short hop if jump released early
 
    Vector3 velocity;
 
    bool isGrounded;
 
    // Update is called once per frame
    void Update()
    {
        //checking if we hit the ground to reset our falling velocity, otherwise we will fall faster the next time
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
 
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -5f;
        }
 
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
 
        Vector3 direction = new Vector3(x, 0f, z).normalized;

        Vector3 camForward = cam.forward;
        Vector3 camRight = cam.right;

        // Flatten the vectors (ignore vertical tilt)
camForward.y = 0f;
camRight.y = 0f;
camForward.Normalize();
camRight.Normalize();

Vector3 move = camRight * direction.x + camForward * direction.z;
 
        controller.Move(move * speed * Time.deltaTime);
 
        //check if the player is on the ground so he can jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            //the equation for jumping
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
 
        // Apply gravity with better jump feel
if (!isGrounded)
{
    if (velocity.y < 0) velocity.y += gravity * fallMultiplier * Time.deltaTime;
    else velocity.y += gravity * Time.deltaTime;

    if (!Input.GetButton("Jump") && velocity.y > 0)
        velocity.y += gravity * (lowJumpMultiplier - 1f) * Time.deltaTime;
}

// Optional: if player releases jump early, cut jump short (more precise)
if (!Input.GetButton("Jump") && velocity.y > 0)
{
    velocity.y += gravity * (lowJumpMultiplier - 1f) * Time.deltaTime;
}
 
        controller.Move(velocity * Time.deltaTime);
    }
}