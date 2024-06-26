﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class respawnerScript : MonoBehaviour {
 private Vector3 position1;
 private Vector3 position2;
 
 private Vector3 position3;
 private Vector3 position4;
 private float speed=1.0f;
    private int tophakki=5;
    private int launchTimes = 0;
public Text topHakkıBonus;
public List<GameObject> topPrefab=new List<GameObject>();
private int topNumarası=0;
public GameObject platformPrefab;
public GameObject KutuPrefab;
public GameObject platform2Prefab;
public float waitTime=2f;
public int topSayaci=0;
public Text SeviyeGostergesi;
public int Seviye=0;
private Vector3 topPozisyonu = new Vector3(-8.57f,2.16f,0f);
private Quaternion topQuternionu = Quaternion.identity;
private Vector3 platformPozisyonu = new Vector3(-8.57f,1.5f,0f);
private Quaternion platformQuaternionu = Quaternion.identity;
private Vector3 kutuPozisyonu=new Vector3(3.97f,-1.49f,0f);
private Quaternion kutuQuaternionu=Quaternion.identity;
private Vector3 platform2Pozisyonu = new Vector3(-6.27f,0.37f,0f);
private Quaternion platform2Quaternionu = Quaternion.identity;
public List<Sprite> arkaplanResimleri =new List<Sprite>();
public Image arkaplanResmi;
public SpriteRenderer zeminRengi;
private Vector3 KutuPingPongPos1 = new Vector3(1f,-1.49f,0f);
private Vector3 KutuPingPongPos2  = new Vector3(7f,-1.49f,0f);
private Vector3 PlatformPingPongPos3 = new Vector3(-7.84f,1.45f,-0.05994832f);
private Vector3 PlatformPingPongPos4  = new Vector3(0.0f,1.45f,-0.05994832f);
private float ScoreTime=30000;


	// Use this for initialization
	void Start () {
		//GameObject.Find("TopHakkiUI").GetComponent<Text>().text=tophakki.ToString();?????????
		GameObject.Find("TopHakkiUI").GetComponent<Text>().text="TOP HAKKI: " + (tophakki - launchTimes);
		
		SeviyeGostergesi= GameObject.Find("SeviyeGöstergesi").GetComponent<Text>();
		topHakkıBonus=GameObject.Find("TopBonusPuan").GetComponent<Text>();
	    SeviyeyiArttır();
		
	}
    public void addToLaunched(int var)
    {
        launchTimes += var;
        if(launchTimes >= tophakki)
        {
            launchTimes = tophakki;
        }
    }
	public void StartRespawnCounter(){
		StartCoroutine(RespawnTop());
	}
	   IEnumerator RespawnTop(){

        yield return new WaitForSeconds(waitTime);
        print("top" + topNumarası);

        topSayaci++;
		GameObject top1 = Instantiate(topPrefab[topNumarası],topPozisyonu,topQuternionu,gameObject.transform);
		top1.GetComponent<topcontrol>().topNumarası= topSayaci;
		
		topHakkıBonus.text="BONUS PUAN: " + (tophakki - launchTimes) *1000;
		//GameObject.Find("TopHakkiUI").GetComponent<Text>().text=tophakki.ToString();

		 GameObject.Find("TopHakkiUI").GetComponent<Text>().text="TOP HAKKI: " + (tophakki - launchTimes);
	}
	// Update is called once per frame
	void Update () {
	    
		ScoreTime -= Time.deltaTime * 500;	
		print(ScoreTime);

	}

	public void SeviyeyiArttır(){
		foreach(Transform child in gameObject.transform){
			GameObject.Destroy(child.gameObject);
		}
		Seviye++;
		if(Seviye<=50){//!!!!!!!!!!!!!!!!!!!
			RespawnPlatform();//!!!!!!!!!!!!!!!!!!!!!!!!!!!!
		}
		else if(Seviye>=51){
			RespawnPlatform2();
		}
        tophakki = 5;
        launchTimes = 0;

        StartCoroutine(RespawnTop());
          
		RespawnKutu();
		ResetScore();
		
		
		arkaplanResmi.sprite=arkaplanResimleri[Random.Range(0,arkaplanResimleri.Count)];
		//zeminRengi.color=new Color(Random.Range(0f,1f), Random.Range(0f,1f), Random.Range(0f,1f), 1f);
		if(Seviye<=5){
		  zeminRengi.color=new Color(1.0f,1.0f,1.0f,1.0f);
		}
		if(Seviye<=5){
		arkaplanResmi.sprite=arkaplanResimleri[(0)];
		} else if(Seviye>5 && Seviye <= 10){
		arkaplanResmi.sprite=arkaplanResimleri[(1)];
		} else if(Seviye>10 && Seviye <= 15){
		arkaplanResmi.sprite=arkaplanResimleri[(2)];
		} else if(Seviye>15 && Seviye <= 20){
		arkaplanResmi.sprite=arkaplanResimleri[(3)];
		} else if(Seviye>20 && Seviye <= 25){
		arkaplanResmi.sprite=arkaplanResimleri[(4)];
		} else if(Seviye>25 && Seviye <= 30){
		arkaplanResmi.sprite=arkaplanResimleri[(5)];
		} else if(Seviye>30 && Seviye <= 35){
		arkaplanResmi.sprite=arkaplanResimleri[(6)];
		} else if(Seviye>35 && Seviye <= 40){
		arkaplanResmi.sprite=arkaplanResimleri[(7)];
		} else if(Seviye>40 && Seviye <= 45){
		arkaplanResmi.sprite=arkaplanResimleri[(8)];
		} else if(Seviye>45 && Seviye <= 50){
		arkaplanResmi.sprite=arkaplanResimleri[(9)];
		}

		SeviyeGostergesi.text="LEVEL " + Seviye.ToString();
	
	}
	public void RespawnPlatform(){
		/*if(Seviye>=5){
			platformQuternionu = Quaternion.Euler(0f,0f,Random.Range(0f,30f));
		}*/
	    if(Seviye==1){
			platformPozisyonu=new Vector3(1.5f,0.58f,-0.05994832f);
		}
		 if(Seviye==2){
			platformPozisyonu=new Vector3(-0.5f,0.58f,-0.05994832f);
		}
		if(Seviye==3){
			platformPozisyonu=new Vector3(-6.23f,0.58f,-0.05994832f);
		}
		if(Seviye==4){
			platformPozisyonu=new Vector3(-0.04f,1.255358f,-0.05994832f);
		}
		if(Seviye==5){
			platformPozisyonu=new Vector3(-3.45f,1.8f,-0.05994832f);
		}
		if(Seviye==6){
			platformPozisyonu=new Vector3(-7.34f,2.42f,-0.05994832f);
		}
		if(Seviye==7){
          platformPozisyonu=new Vector3(-4.42f,-1.21f,-0.05994832f);
		  platformQuaternionu = Quaternion.Euler(0f,0f,20f);
		}
		if(Seviye==8){
          platformPozisyonu=new Vector3(-0.89f,1.46f,-0.05994f);
		  platformQuaternionu = Quaternion.Euler(0f,0f,20f);
		}
		if(Seviye==9){
			platformPozisyonu=new Vector3(-8.97f,1.46f,-0.05994832f);
			platformQuaternionu=Quaternion.Euler(0f,0f,20f);
		}
		if(Seviye==10){
				platformPozisyonu=new Vector3(0.25f,0.7f,0f);
			}
			if(Seviye==11){
				platformPozisyonu=new Vector3(0.25f,2.7f,0f);
			}
			if(Seviye==12){
				platformPozisyonu=new Vector3(-7.41f,2.7f,0f);
			}
				if(Seviye==13){
                platformPozisyonu=new Vector3(-6.7f,1.42f,0f);
			}
			if(Seviye==14){
				platformPozisyonu=new Vector3(-1.69f,0.14f,0f);
				platformQuaternionu= Quaternion.Euler(0f,0f,15f);
			}
			if(Seviye==15){
                platformPozisyonu=new Vector3(-8.19f,1.0f,0f);
				platformQuaternionu= Quaternion.Euler(0f,0f,15f);
			}
			if(Seviye==16){
                platformPozisyonu=new Vector3(-5.8f,1.67f,0f);
				platformQuaternionu= Quaternion.Euler(0f,0f,15f);
			}
			if(Seviye==17){
                platformPozisyonu=new Vector3(-2.5f,1.46f,-0.05994832f);
			}
			if(Seviye==18){
                platformPozisyonu=new Vector3(-3.0f,1.46f,-0.05994832f);
			}
			if(Seviye==19){
                platformPozisyonu=new Vector3(-4.76f,1.99f,-0.05994832f);
			}
				if(Seviye==20){
                platformPozisyonu=new Vector3(-6.84f,1.48f,-0.05994832f);
			}
		
	
	
		// platformPozisyonu = new Vector3(Random.Range(-7.8f,-4f),Random.Range(1.0f,2.8f),0f);
		 topPozisyonu= platformPozisyonu + new Vector3(-0.5f,1f,0f);
		Instantiate(platformPrefab,platformPozisyonu,platformQuaternionu,gameObject.transform);
		
		}

	public void RespawnKutu(){
		//kutuPozisyonu=new Vector3(Random.Range(4.8f,6.1f),-1.49f,0f);
		if(Seviye<=14){
			kutuPozisyonu=new Vector3(5.8f,-1.49f,0f);
		}
		if(Seviye==15){
			kutuPozisyonu=new Vector3(8.59f,-1.49f,0f);
		}  
		//print(kutuPozisyonu);
		GameObject Kutu=Instantiate(KutuPrefab,kutuPozisyonu,kutuQuaternionu,gameObject.transform);

        if(Seviye==17){
        Kutu.GetComponent<KutuScript>().EnablePingPongKutu(KutuPingPongPos1,KutuPingPongPos2,0.1f,true);
		 
	}
	 if(Seviye==18){
        Kutu.GetComponent<KutuScript>().EnablePingPongKutu(KutuPingPongPos1,KutuPingPongPos2,0.2f,true);
		 
	}
	 if(Seviye==19){
        Kutu.GetComponent<KutuScript>().EnablePingPongKutu(KutuPingPongPos1,KutuPingPongPos2,0.3f,true);
		 
	}
	 if(Seviye==20){
        Kutu.GetComponent<KutuScript>().EnablePingPongKutu(KutuPingPongPos1,KutuPingPongPos2,0.5f,true);
		 
	}
		 
}
	/*public void EnablePingPongKutu(Vector3 pos1,Vector3 pos2,float spd,bool enable){
		position1=pos1;
		position2=pos2;
		speed=spd;
		isKutuPingPongEnabled=enable;
	}*/
	public void RespawnPlatform2(){
			/*if(Seviye>=11){
			platform2Quternionu = Quaternion.Euler(0f,0f,Random.Range(0f,50f));
			}*/
			if(Seviye==51){//11
				platform2Pozisyonu=new Vector3(0.25f,0.7f,0f);
			}
			if(Seviye==52){//12
				platform2Pozisyonu=new Vector3(0.25f,2.7f,0f);
			}
			if(Seviye==53){//13
				platform2Pozisyonu=new Vector3(-7.41f,2.7f,0f);
			}
				if(Seviye==54){//14
                platform2Pozisyonu=new Vector3(-6.7f,1.42f,0f);
			}
			if(Seviye==55){//15
				platform2Pozisyonu=new Vector3(-1.69f,0.14f,0f);
				platform2Quaternionu= Quaternion.Euler(0f,0f,15f);
			}
			if(Seviye==56){//16
                platform2Pozisyonu=new Vector3(-8.19f,1.0f,0f);
				platform2Quaternionu= Quaternion.Euler(0f,0f,15f);
			}
			if(Seviye==57){//17
                platform2Pozisyonu=new Vector3(-5.8f,1.67f,0f);
				platform2Quaternionu= Quaternion.Euler(0f,0f,15f);
			}
		
			
        // platform2Pozisyonu=new Vector3(Random.Range(-7.8f,-4f),Random.Range(1.0f,2.8f),0f);			
		topPozisyonu= platform2Pozisyonu + new Vector3(-0.5f,0.3f,0f);
		Instantiate(platform2Prefab,platform2Pozisyonu,platform2Quaternionu,gameObject.transform);
		
	}
	public void ResetScore(){
		ScoreTime=30000;
	}
	public void SetScore(){
	    int Score=Mathf.RoundToInt(ScoreTime);
		if(Score<=0){
			Score=0;
		}
		//Score += tophakki * 1000;???????????
	    GameObject.Find("ScoreText").GetComponent<Text>().text="SCORE: " + Score;

		Image Star1 = GameObject.Find("Star1").GetComponent<Image>();
		Image Star2 = GameObject.Find("Star2").GetComponent<Image>();
		Image Star3 = GameObject.Find("Star3").GetComponent<Image>();
		Color bright = new Color(1,1,1,1);
		Color dark = new Color(0.3f,0.3f,0.3f,1);
		Text LevelUpText=GameObject.Find("LevelUpText").GetComponent<Text>();
        if(Score>=22500){
			Star1.color=bright;
			Star2.color=bright;
			Star3.color=bright;
		}else if(Score>=15000){		
			Star1.color=bright;
			Star2.color=bright;
			Star3.color=dark;
		}else if(Score>=5000){			
			Star1.color=bright;
			Star2.color=dark;
			Star3.color=dark;
		}else{			
			Star1.color=dark;
			Star2.color=dark;
			Star3.color=dark;
		}
		if(Score>=22500){
			LevelUpText.text="LEGENDARY!";
		}else if(Score>=15000){
			LevelUpText.text="AMAZING!";
		}else if(Score>=5000){
			LevelUpText.text="GOOD!";
		}else if(Score>=0){
			LevelUpText.text="BAD!";
		}
	}

	public void setBallNumber(int num){
		topNumarası=num;
	}

    public int getBallNumber()
    {
        return topNumarası;
    }
}
