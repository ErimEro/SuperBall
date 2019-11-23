using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour {

	private Vector3 position3;
	 private Vector3 position4;
	 private bool isEnabled=false;
	 private float speed=1.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(isEnabled){
			transform.position=Vector3.Lerp(position3,position4,Mathf.PingPong(Time.time*speed,1.0f));
		}
	}
	public void EnablePingPongPlatform(Vector3 pos3,Vector3 pos4,float spd,bool enable){
		position3=pos3;
		position4=pos4;
		speed=spd;
		isEnabled=enable;
	}
}
