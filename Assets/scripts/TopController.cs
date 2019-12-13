using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopController : MonoBehaviour
{
    public GameObject TopPaneli;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartGame(){
        Time.timeScale = 1;
    }

    public void TopPaneliAçKapa(bool var){
		TopPaneli.SetActive(var);
		if(var){
			Time.timeScale=0;
			
		} else if(!var){
			Time.timeScale=1;
		}

	}
}
