using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour {
public GameObject durdurmaPaneli;

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

	public void LevelFinish() {
		int currentUnlockedLevel = GameObject.Find("respawner").GetComponent<respawnerScript>().Seviye +1;
		if(PlayerPrefs.GetInt("UnlockedLevels") < currentUnlockedLevel){
			PlayerPrefs.SetInt("UnlockedLevels", currentUnlockedLevel);
		}	
			
		int currentScore= GameObject.Find("respawner").GetComponent<respawnerScript>().GetScore();
		string levelScoreString = (currentUnlockedLevel - 1).ToString() + "LevelScore";
		PlayerPrefs.SetInt(levelScoreString, currentScore);

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
	public void QuitGame(){
		Application.Quit();
	}
}
