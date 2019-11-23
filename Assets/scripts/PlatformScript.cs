using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour {

	private Vector3 position1;
	 private Vector3 position2;
	 private bool isEnabled=false;
	 private float speed=1.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(isEnabled){
			transform.position=Vector3.Lerp(position1,position2,Mathf.PingPong(Time.time*speed,1.0f));
		}
	}
	public void EnablePingPongPlatform(Vector3 pos1,Vector3 pos2,float spd,bool enable){
		position1=pos1;
		position2=pos2;
		speed=spd;
		isEnabled=enable;
	}
}
