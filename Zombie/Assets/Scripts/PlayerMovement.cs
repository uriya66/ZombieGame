using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    Vector3 velocity;
    
    public float speed = 10f;
    // Default gravity on Earth -9.81 meters per second square
    public float gravity = -9.81f;
    public bool isGrounded;
    // this layer mask allow us to know which layer we are it
    public LayerMask groundMask;
    public float groundDistance = 0.4f;
    public Transform groundCheck;

    public float jumpHeight = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Return true if there are any colliders overlapping the sphere defined by position 
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            // Give a small landing transition of some sort
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        // Move the player
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        // Make gravity pulling down after walked on something
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        // Taking care Jump of player
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            // Jump up with two times negative the gravity
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        
    }
}
