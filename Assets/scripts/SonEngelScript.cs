using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonEngelScript : MonoBehaviour
{
    private Vector3 position11;
    private Vector3 position12;
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
			transform.position=Vector2.Lerp(position11,position12,Mathf.PingPong(Time.time*speed,1.0f));
		}
    }
    public void EnablePingPongSonEngel(Vector3 pos11,Vector3 pos12,float spd,bool enable){
		position11=pos11;
		position12=pos12;
		speed=spd;
		isEnabled=enable;
	}
}
