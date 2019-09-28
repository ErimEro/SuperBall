using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawnerScript : MonoBehaviour {

public GameObject top;
public float waitTime=2;
public int topSayaci=0;
	// Use this for initialization
	void Start () {
		
	}
	public void StartRespawnCounter(){
		StartCoroutine(RespawnTop());
	}
	   IEnumerator RespawnTop(){
		yield return new WaitForSeconds(waitTime);
		topSayaci++;
		GameObject top1 = Instantiate(top,transform,true);
		top1.GetComponent<topcontrol>().topNumarası= topSayaci;
	}
	// Update is called once per frame
	void Update () {
		
	}
}
