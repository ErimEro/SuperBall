﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelAtlama : MonoBehaviour {

	// Use this for initialization
	public float levelBekle=2;
	void Start () {
		
	}
	private void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.tag == "ball"){
			GameObject.Find("respawner").GetComponent<respawnerScript>().SeviyeyiArttır();
			
			
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}