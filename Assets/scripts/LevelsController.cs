using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsController : MonoBehaviour
{
public GameObject LevelPaneli;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartGame(){
        Time.timeScale = 1;
    }

    public void LevelPaneliAçKapa(bool var){
		LevelPaneli.SetActive(var);
		if(var){
			Time.timeScale=0;
			
		} else if(!var){
			Time.timeScale=1;
		}

	}
}
