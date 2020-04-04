using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigerEngelScript : MonoBehaviour
{
    private Vector3 position9;
    private Vector3 position10;
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
			transform.position=Vector2.Lerp(position9,position10,Mathf.PingPong(Time.time*speed,1.0f));
		}
    }
    public void EnablePingPongDigerEngel(Vector3 pos9,Vector3 pos10,float spd,bool enable){
		position9=pos9;
		position10=pos10;
		speed=spd;
		isEnabled=enable;
	}
}
