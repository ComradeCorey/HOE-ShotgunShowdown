using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cacheScript : MonoBehaviour {

	void update ()
	{
		// Ignore collision between Collectables and Projectiles
		Physics2D.IgnoreLayerCollision (10, 9);
	}
	
	// This is where the player collects the cache and earns money from it
	void OnCollisionEnter2D (Collision2D col)
	{
		if (col.gameObject.tag.Equals ("Player")) 
		{
			scoreScript.scoreValue += 5;
			Destroy (gameObject);
		}
	}
}