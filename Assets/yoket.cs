using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yoket : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
    private void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.tag == gameObject.transform.parent.tag){
			if(gameObject.transform.parent.GetComponent<topcontrol>().topNumarası > other.gameObject.GetComponent<topcontrol>().topNumarası){
				Destroy(other.gameObject);
			}
		}
	}
	// Update is called once per frame
	void Update () {
		
	}
}
