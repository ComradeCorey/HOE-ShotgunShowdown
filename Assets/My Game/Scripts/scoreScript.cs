using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreScript : MonoBehaviour {

	public static int scoreValue = 0;
	Text score;

	// Use this for initialization

	// This is where the value of the score and the text is changed from
	void Start () 
	{
		score = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		score.text = " Cache: " + scoreValue;
	}
}
