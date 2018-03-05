using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public string logtext = "Hello world again!";
    public float speed = 2;
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

        Debug.Log(horizontal);

        // Cache a local copy of our rigidbody's velocity
        Vector2 velocity = rigidBody.velocity;

        // Set the x component of the velocity based on input
        velocity.x = horizontal * speed;

        // Set our rigidbody's velocity based on our local copy
        rigidBody.velocity = velocity;
    }

    public void ApplyDamage(float damageToDeal)
    {
        health = health - damageToDeal;
    }
}
// Nein