﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelAtlama : MonoBehaviour {

	// Use this for initialization
	public float levelBekle=2;
	public GameObject FinalKonfeti;
	void Start () {
		
	}
	private void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.tag == "ball" && GameObject.Find("respawner").GetComponent<respawnerScript>().Seviye < PlayerPrefs.GetInt("LevelLimit")){
		//	GameObject.Find("respawner").GetComponent<respawnerScript>().SeviyeyiArttır();
			GameObject.Find("UI").transform.GetChild(5).gameObject.SetActive(true);
			transform.parent.GetChild(5).gameObject.SetActive(true);
			GameObject.Find("UI").transform.GetChild(4).gameObject.SetActive(false);
			GameObject.Find("respawner").GetComponent<AudioSource>().Play(0);
			GameObject.Find("respawner").GetComponent<respawnerScript>().SetScore();
			GameObject.Find("respawner").GetComponent<respawnerScript>().setIsBallSpawnable(false);
			LevelFinish();
		} else if(other.gameObject.tag == "ball" && GameObject.Find("respawner").GetComponent<respawnerScript>().Seviye <= PlayerPrefs.GetInt("LevelLimit")) {
			LevelFinish();
			GameObject.Find("UI").transform.GetChild(5).gameObject.SetActive(true);
			GameObject.Find("UI").transform.GetChild(5).GetChild(0).gameObject.SetActive(false);
			Instantiate(FinalKonfeti, new Vector3(0, 0, 0), Quaternion.identity);
			GameObject.Find("respawner").GetComponent<AudioSource>().Play(0);
			GameObject.Find("respawner").GetComponent<respawnerScript>().SetScore();
			GameObject.Find("respawner").GetComponent<respawnerScript>().setIsBallSpawnable(false);
			GameObject.Find("UI").transform.GetChild(11).gameObject.SetActive(true);
		}
	}
	private void LevelFinish() {
		int currentUnlockedLevel = GameObject.Find("respawner").GetComponent<respawnerScript>().Seviye +1;
		if(PlayerPrefs.GetInt("UnlockedLevels") < currentUnlockedLevel){
			PlayerPrefs.SetInt("UnlockedLevels", currentUnlockedLevel);
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
