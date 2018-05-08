using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour {
	public float enemySpeed;

	public float distance;

	private bool movingRight = true;

	public Transform groundDetection;

	// Update is called once per frame
	void Update () 
		{
		// Make the enemy move right
		transform.Translate(Vector2.right * enemySpeed * Time.deltaTime);

		// Set the Ray to detect when the character moves to an object
		RaycastHit2D groundInfo = Physics2D.Raycast (groundDetection.position, Vector2.down, 2f);

		// Changes direction on whether the character is close to falling off
		if (groundInfo.collider == false)
		{
			if (movingRight == true) 
			{
				transform.eulerAngles = new Vector3 (0, -180, 0);
				movingRight = false;
			} else 
			{
				transform.eulerAngles = new Vector3 (0, 0, 0);
				movingRight = true;
			}
		}

		// Ignore collision between collectable and enemy
		Physics2D.IgnoreLayerCollision (9, 11);
	}

	// This is where the enemy dies from colliding with the bullet and the player earns cache
	void OnCollisionEnter2D (Collision2D col)
	{
		if (col.gameObject.tag.Equals ("Bullet")) 
		{
			scoreScript.scoreValue += 10;
			Destroy (col.gameObject);
			Destroy (gameObject);
		}
	}
}