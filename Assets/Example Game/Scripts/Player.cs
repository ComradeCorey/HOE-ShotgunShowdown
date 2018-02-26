using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public string logtext = "Hello world again!";
    public float speed = 2;

    // Use this for initialization
    void Start () {

        Debug.Log(logtext);
	
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(logtext);
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = Vector2.right * speed;
    }
}
