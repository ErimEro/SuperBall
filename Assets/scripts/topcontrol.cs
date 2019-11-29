using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class topcontrol : MonoBehaviour {

public float guc =0;
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
			//print("Selam");
		if(Input.GetKey(KeyCode.Mouse0)){
			if(guc<10){
				guc+=Time.deltaTime*2; 
			} else if(guc>10){
				guc=10.00000f;
			} 
			//print(guc);
		}
		if(Input.GetKeyUp(KeyCode.Mouse0)){
			GetComponent<Rigidbody2D>().velocity=new Vector2(guc*2,0);
			topFırlatıldı=true;
			guc=0;
                GameObject.Find("respawner").GetComponent<respawnerScript>().addToLaunched(1);

                GameObject.Find("respawner").GetComponent<respawnerScript>().StartRespawnCounter();
            }
            bar.fillAmount = guc/10;
	    }
	}
}
