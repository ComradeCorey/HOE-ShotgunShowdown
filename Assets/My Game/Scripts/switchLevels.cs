﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchLevels : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            Application.LoadLevel("TitleScreen");
        }
    }
}
