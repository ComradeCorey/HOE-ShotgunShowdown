using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour {

	public float velX = 5f;
	float velY = 0f;
	Rigidbody2D rb;
    public float decay;

	// Use this for initialization
	void Start () 
	{
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		rb.velocity = new Vector2 (velX, velY);
		Destroy (gameObject, decay);

		// Ignore collision between Collectables and Projectiles
		Physics2D.IgnoreLayerCollision (10, 9);
	}
}
