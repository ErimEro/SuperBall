﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDeneme : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.tag=="ball"){
			Destroy(other.gameObject);
		}
		
	}
	// Update is called once per frame
	void Update () {
		
	}
}
