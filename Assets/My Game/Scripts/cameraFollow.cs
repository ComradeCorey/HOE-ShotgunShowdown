using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour {
	
	private Vector2 velocity;

	public float smoothTimeY;

	public float smoothTimeX;

	public GameObject player;

	// Use this for initialization
	void Start () 
	{
		// Sets the player as the game object
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void FixedUpdate () 
	{
		// Set the X and Y of the camera
		float posX = Mathf.SmoothDamp (transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
		float posY = Mathf.SmoothDamp (transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeX);

		transform.position = new Vector3 (posX, posY, transform.position.z);
	}
}
