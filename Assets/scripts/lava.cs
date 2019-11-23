using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lava : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	void OnTriggerEnter2D(Collider2D other){
		print("bana bisey carpti");
		if(other.gameObject.tag=="ball"){
			Destroy(other.gameObject);
			GetComponent<AudioSource>().Play(0);
		}
		
	}
	// Update is called once per frame
	void Update () {
		
	}
}
