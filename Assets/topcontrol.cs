using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class topcontrol : MonoBehaviour {

public float guc;
public Image bar;
public int topNumarası=0;
public bool topFırlatıldı = true;
 	void Start () {
		//bar=Resources.Load<Image>("powerbar");
		
		bar = GameObject.Find("bar").GetComponent<Image>();
		bar.fillAmount=0;

	}
	

	void Update () {
		if(!topFırlatıldı){
			print("Selam");
		if(Input.GetKey(KeyCode.Space)){
			if(guc<30){
				guc++;
			}
		}
		if(Input.GetKeyUp(KeyCode.Space)){
			GetComponent<Rigidbody2D>().velocity=new Vector2(guc,0);
			topFırlatıldı=true;
			guc=0;
			GameObject.Find("respawner").GetComponent<respawnerScript>().StartRespawnCounter();
			
		}
		bar.fillAmount = guc/30;
	}
	}
}
