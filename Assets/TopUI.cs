using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TopUI : MonoBehaviour {
          
		  public int topSeviyeSınırı;
		  public int topNumarası;
	// Use this for initialization
	private void OnEnable(){
		transform.GetChild(0).GetComponent<Text>().text="LEVEL " + topSeviyeSınırı;
		int CurrentLevel=GameObject.Find("respawner").GetComponent<respawnerScript>().Seviye;
		if(CurrentLevel<topSeviyeSınırı){
			GetComponent<Image>().color=new Color(0.3f,0.3f,0.3f);
		} 
        else{
			GetComponent<Image>().color=new Color(1f,1f,1f);
		}
	}
	public void TopNumarasınıYolla(){
		GameObject.Find("respawner").GetComponent<respawnerScript>().setBallNumber(topNumarası);
	}
}
