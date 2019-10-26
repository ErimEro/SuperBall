using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class respawnerScript : MonoBehaviour {

public int tophakki=5;
public GameObject topPrefab;
public GameObject platformPrefab;
public GameObject KutuPrefab;
public GameObject platform2Prefab;
public float waitTime=2;
public int topSayaci=0;
public Text SeviyeGostergesi;
public int Seviye=0;
private Vector3 topPozisyonu = new Vector3(-8.57f,2.16f,0f);
private Quaternion topQuternionu = Quaternion.identity;
private Vector3 platformPozisyonu = new Vector3(-8.57f,1.5f,0f);
private Quaternion platformQuternionu = Quaternion.identity;
private Vector3 kutuPozisyonu=new Vector3(3.97f,-1.49f,0f);
private Quaternion kutuQuaternionu=Quaternion.identity;
private Vector3 platform2Pozisyonu = new Vector3(-6.27f,0.37f,0f);
private Quaternion platform2Quternionu = Quaternion.identity;
public List<Sprite> arkaplanResimleri =new List<Sprite>();
public Image arkaplanResmi;
public SpriteRenderer zeminRengi;
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
		Seviye++;
		if(Seviye<=7){
			RespawnPlatform();
		}
		else if(Seviye>7){
			RespawnPlatform2();
		}
		StartCoroutine(RespawnTop());

		RespawnKutu();
		
		arkaplanResmi.sprite=arkaplanResimleri[Random.Range(0,arkaplanResimleri.Count)];
		zeminRengi.color=new Color(Random.Range(0f,1f), Random.Range(0f,1f), Random.Range(0f,1f), 1f);

		SeviyeGostergesi.text="LEVEL " + Seviye.ToString();
	
	}
	public void RespawnPlatform(){
		if(Seviye>=5){
			platformQuternionu = Quaternion.Euler(0f,0f,Random.Range(0f,50f));
		}
	
				 platformPozisyonu = new Vector3(Random.Range(-10f,-4f),Random.Range(0.55f,2.8f),0f);
		 topPozisyonu= platformPozisyonu + new Vector3(-0.5f,1f,0f);
		Instantiate(platformPrefab,platformPozisyonu,platformQuternionu,gameObject.transform);
		
		}
	
	public void RespawnKutu(){
		kutuPozisyonu=new Vector3(Random.Range(5f,8f),-1.49f,0f);
		print(kutuPozisyonu);
		Instantiate(KutuPrefab,kutuPozisyonu,kutuQuaternionu,gameObject.transform);
			
	}
	public void RespawnPlatform2(){
         platform2Pozisyonu=new Vector3(Random.Range(-6.27f,-1.7f),-0.01f,0f);			
		topPozisyonu= platform2Pozisyonu + new Vector3(-0.5f,0.3f,0f);
		Instantiate(platform2Prefab,platform2Pozisyonu,platform2Quternionu,gameObject.transform);
		
	}
	
}
