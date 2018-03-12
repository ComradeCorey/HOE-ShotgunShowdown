﻿using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	// Public variables available in editor
    public string logtext = "Hello world again!";
    public float speed = 2;
    public float jspeed = 50;
    public float health = 10;
	public int allowedAirJumps = 0;

	// Private variables bot available in editor
	private int numAirJumps = 0;

    // Use this for initialization
    void Start() {

        Debug.Log(logtext);
    }

    // Update is called once per frame
    void Update() {

        // Getting the rigidbody from the game object we are attached to
        Rigidbody2D rigidBody = GetComponent<Rigidbody2D>();

        // Number between -1 and 1 based on player pressing left or right
        float horizontal = Input.GetAxis("Horizontal");

        // Boolean (true or false) based on player pressing jump button
        bool jump = Input.GetButtonDown("Jump");

        // Find out if player is touching ground

        // Get collider attached to this object
        Collider2D collider = GetComponent<Collider2D>();

        // Find out if we are colliding with the ground
        LayerMask groundLayer = LayerMask.GetMask("Ground");

        bool touchingGround = collider.IsTouchingLayers(groundLayer);

		// If touching ground, jumps are reset to 0
		if (touchingGround)
		{
			numAirJumps = 0;
		}
		
		// Jumps only allowed when touching ground
		bool allowedToJump = touchingGround;

		// If allowed air jumps is higher than the amount of air jumps used, then jump is allowed while in air
		if (allowedAirJumps > numAirJumps) {
			allowedToJump = true;
		}

        // Cache a local copy of our rigidbody's velocity
        Vector2 velocity = rigidBody.velocity;

        // Set the x component of the velocity based on input
        velocity.x = horizontal * speed;

        // Determine speed for animator
        float animatorSpeed = Mathf.Abs(velocity.x);

        // Get the animator component
        Animator animatorComponent = GetComponent<Animator>();

        //Set the speed on the animator
        animatorComponent.SetFloat("speed", animatorSpeed);

        // Set the y component of the velocity based on input
        if (jump == true && allowedToJump == true)
        {
            velocity.y = jspeed;

			if (touchingGround != true) {
				numAirJumps = numAirJumps + 1;
			}
        }

        // Set our rigidbody's velocity based on our local copy
        rigidBody.velocity = velocity;

        // Print a log if mouse is pressed
        if(Input.GetMouseButton(0))
        {
            Debug.Log("click click click");
        }

        // Print a log of the mouse position
        Vector2 mousePosition = Input.mousePosition;
        Debug.Log("Mouse position is " + mousePosition);
    }

    public void ApplyDamage(float damageToDeal)
    {
        health = health - damageToDeal;
    }
}
// Nein