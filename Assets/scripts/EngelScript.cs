using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngelScript : MonoBehaviour
{
    private Vector3 position7;
    private Vector3 position8;
    private bool isEnabled=false;
	 private float speed=1.0f;

    // Start is called before the first frame update
    void Start()
    {
        	
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isEnabled){
			transform.position=Vector2.Lerp(position7,position8,Mathf.PingPong(Time.time*speed,1.0f));
		}
    }
    public void EnablePingPongEngel(Vector3 pos7,Vector3 pos8,float spd,bool enable){
		position7=pos7;
		position8=pos8;
		speed=spd;
		isEnabled=enable;
	}
}
