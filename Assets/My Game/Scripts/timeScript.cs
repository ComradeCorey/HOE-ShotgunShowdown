using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timeScript : MonoBehaviour {

	public Text counterText;

	public float seconds, minutes;

	// Use this for initialization
	void Start () 
	{
		counterText = GetComponent<Text> () as Text;
	}
	
	// Update is called once per frame
	void Update () 
	{
		minutes = (int)(Time.time / 60f);
		seconds = (int)(Time.time % 60f);
		counterText.text = ("Time: ") + minutes.ToString ("00") + ":" + seconds.ToString ("00");
	}
}
