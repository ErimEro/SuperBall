using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class respawnerScript : MonoBehaviour {

public int tophakki=5;
public GameObject topPrefab;
public GameObject platformPrefab;
public float waitTime=2;
public int topSayaci=0;
public Text SeviyeGostergesi;
public int Seviye=0;
public Vector3 topPozisyonu = new Vector3(-8.57f,2.16f,0f);
public Quaternion topQuternionu = Quaternion.identity;
public Vector3 platformPozisyonu = new Vector3(-8.57f,1.5f,0f);
public Quaternion platformQuternionu = Quaternion.identity;
	// Use this for initialization
	void Start () {
		GameObject.Find("TopHakkiUI").GetComponent<Text>().text=tophakki.ToString();
		SeviyeGostergesi= GameObject.Find("SeviyeGöstergesi").GetComponent<Text>();
	    SeviyeyiArttır();
	}
	public void StartRespawnCounter(){
		StartCoroutine(RespawnTop());
	}
	   IEnumerator RespawnTop(){
		yield return new WaitForSeconds(waitTime);
		topSayaci++;
		GameObject top1 = Instantiate(topPrefab,topPozisyonu,topQuternionu,gameObject.transform);
		top1.GetComponent<topcontrol>().topNumarası= topSayaci;
		tophakki--;
		GameObject.Find("TopHakkiUI").GetComponent<Text>().text=tophakki.ToString();
		
	}
	// Update is called once per frame
	void Update () {
		
	}

	public void SeviyeyiArttır(){
			foreach(Transform child in gameObject.transform){
			GameObject.Destroy(child.gameObject);
			
		}
		StartCoroutine(RespawnTop());

		RespawnPlatform();
		Seviye++;
		SeviyeGostergesi.text="LEVEL " + Seviye.ToString();
	
	}
	public void RespawnPlatform(){
		platformQuternionu.z = 45;
		Instantiate(platformPrefab,platformPozisyonu,platformQuternionu,gameObject.transform);
	}
}
