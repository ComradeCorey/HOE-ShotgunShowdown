using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	// Public variables available in editor
    public string logtext = "Hello world again!";
    public float speed = 2;
    public float jspeed = 50;
    public float health = 10;
	public int allowedAirJumps = 0;
	// Every Variable below this is for my shooting code SHOOTING
	float velX = 0;
	bool facingRight = true;
	public GameObject BulletToRight, BulletToLeft;
	Vector2 bulletPos;
	public float fireRate = 0 / 5f;
	float nextFire = 0.0f;

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

        // Set the speed on the animator
        animatorComponent.SetFloat("speed", animatorSpeed);

        // Get the sprite component from object
        SpriteRenderer spriteComponent = GetComponent<SpriteRenderer>();

        // Set flip based on x Velocity
        if (velocity.x != 0)
            spriteComponent.flipX = (velocity.x < 0);
		velX = velocity.x;

        // Set the y component of the velocity based on input
		if (jump == true && allowedToJump == true) {
			velocity.y = jspeed;

			if (touchingGround != true) {
				numAirJumps = numAirJumps + 1;
			}
		}

		// TRYING TO GET FACING RIGHT TO STORE THE X DIRECTION OF MY CHARACTER SHOOTING
			if (velX > 0) {
				facingRight = true;
			} else if (velX < 0) {
				facingRight = false;
			}
				
        // Set our rigidbody's velocity based on our local copy
        rigidBody.velocity = velocity;	

		// This is where I get my player to shoot SHOOTING
		if (Input.GetButtonDown ("Fire1") && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			fire ();
			AudioSource shoot = GetComponent<AudioSource> ();
			shoot.Play();
		}
	}
		
	// This is where I get my character to shoot in the direction he is facing SHOOTING
	void fire()
	{

		bulletPos = transform.position;
		if (facingRight) {
			bulletPos += new Vector2 (+0.5f, -0f);
			Instantiate (BulletToRight, bulletPos, Quaternion.identity);
		} else {
			bulletPos += new Vector2 (-0.5f, -0f);
			Instantiate (BulletToLeft, bulletPos, Quaternion.identity);
		}
	}

	// This is where I allow the player to be killed by anything with the enemies tag
	void OnCollisionEnter2D (Collision2D coll)
	{
		if (coll.gameObject.tag.Equals ("Enemies")) 
		{
			Destroy (gameObject);
            scoreScript.scoreValue -= scoreScript.scoreValue;

            Application.LoadLevel(Application.loadedLevel);
        }

        if (coll.gameObject.tag.Equals("OutOfBounds"))
        {
            Destroy(gameObject);
            scoreScript.scoreValue -= scoreScript.scoreValue;
            Application.LoadLevel(Application.loadedLevel);
        }
    }
}