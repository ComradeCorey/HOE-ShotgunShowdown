using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public string logtext = "Hello world again!";
    public float speed = 2;
    public float jspeed = 50;
    public float health = 10;

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

        // Cache a local copy of our rigidbody's velocity
        Vector2 velocity = rigidBody.velocity;

        // Set the x component of the velocity based on input
        velocity.x = horizontal * speed;

        // Set the y component of the velocity based on input
        if (jump == true && touchingGround == true)
        {
            velocity.y = jspeed;
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