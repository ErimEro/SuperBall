using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour {
public GameObject durdurmaPaneli;
public GameObject InformationPaneli;


	// Use this for initialization
	void Start () {
		Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartGame()
    {
        Time.timeScale = 1;
    }

	public void ReturnLevelSelect(){
		SceneManager.LoadScene("LevelScene", LoadSceneMode.Single);
	}

	

    public void durdurmaPaneliAçKapa(bool var){
		durdurmaPaneli.SetActive(var);
		if(var){
			Time.timeScale=0;
		} else if(!var){
			Time.timeScale=1;
		}

	}
	 public void InformationPaneliAçKapa(bool var){
		InformationPaneli.SetActive(var);
		if(var){
			Time.timeScale=0;
		} else if(!var){
			Time.timeScale=1;
		}

	}
	public void QuitGame(){
		Application.Quit();
	}
}
