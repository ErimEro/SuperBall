using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour {
public GameObject durdurmaPaneli;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void durdurmaPaneliAçKapa(bool var){
		durdurmaPaneli.SetActive(var);
		if(var){
			Time.timeScale=0;
			
		} else if(!var){
			Time.timeScale=1;
		}

	}
	public void QuitGame(){
		Application.Quit();
		print("çıktım");
	}
}
