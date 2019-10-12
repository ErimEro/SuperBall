using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class respawnerScript : MonoBehaviour {

public int tophakki=5;
public GameObject top;
public float waitTime=2;
public int topSayaci=0;
	// Use this for initialization
	void Start () {
		GameObject.Find("TopHakkiUI").GetComponent<Text>().text=tophakki.ToString();
	}
	public void StartRespawnCounter(){
		StartCoroutine(RespawnTop());
	}
	   IEnumerator RespawnTop(){
		yield return new WaitForSeconds(waitTime);
		topSayaci++;
		GameObject top1 = Instantiate(top,transform,true);
		top1.GetComponent<topcontrol>().topNumarası= topSayaci;
		tophakki--;
		GameObject.Find("TopHakkiUI").GetComponent<Text>().text=tophakki.ToString();
		
	}
	// Update is called once per frame
	void Update () {
		
	}
}
