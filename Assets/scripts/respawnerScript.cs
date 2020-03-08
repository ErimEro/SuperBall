using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class respawnerScript : MonoBehaviour {
 private Vector3 position1;
 private Vector3 position2;
 private bool isBallSpawnable =true;
 private Vector3 position3;
 private Vector3 position4;
 private Vector3 position5;
 private Vector3 position6;
  private Vector3 position7;
 private Vector3 position8;

 private float speed=1.0f;
private int tophakki=5;
private int launchTimes = 0;
public Text topHakkıBonus;
public List<GameObject> topPrefab=new List<GameObject>();
private int topNumarası=0;
public GameObject platformPrefab;
public GameObject KutuPrefab;
public GameObject EngelPrefab;
public GameObject BoruPrefab;

public GameObject platform2Prefab;
public float waitTime=2f;
public int topSayaci=0;
public Text SeviyeGostergesi;
public int Seviye=0;
private Vector3 topPozisyonu = new Vector3(-8.57f,2.16f,0f);
private Quaternion topQuternionu = Quaternion.identity;
private Vector3 platformPozisyonu = new Vector3(-8.57f,1.5f,0f);
private Quaternion platformQuaternionu = Quaternion.identity;
private Vector3 kutuPozisyonu=new Vector3(5.98f,-1.49f,0f);
private Quaternion kutuQuaternionu=Quaternion.identity;
private Vector3 EngelPozisyonu = new Vector3(3.97f,2f,0f);
private Quaternion EngelQuaternionu = Quaternion.identity;
private Vector3 BoruPozisyonu = new Vector3 (0.5f,0f,0f);
private Quaternion BoruQuaternionu = Quaternion.identity;
private Vector3 platform2Pozisyonu = new Vector3(-6.27f,0.37f,0f);
private Quaternion platform2Quaternionu = Quaternion.identity;
public List<Sprite> arkaplanResimleri =new List<Sprite>();
public Image arkaplanResmi;
public SpriteRenderer zeminRengi;
private Vector3 KutuPingPongPos1 = new Vector3(1f,-1.52f,0f);
private Vector3 KutuPingPongPos2  = new Vector3(7f,-1.52f,0f);
private Vector3 KutuPingPongPos3  = new Vector3(3f,-1.52f,0f);
private Vector3 KutuPingPongPosDikey1 = new Vector3(6.3f,-1.52f,0f);
private Vector3 KutuPingPongPosDikey2 = new Vector3(6.3f,0.6f,0f);
private Vector3 KutuPingPongPosDikey3 = new Vector3(6.3f,2.2f,0f);
private Vector3 EngelPingPong1 = new Vector3(1f,0f,0f);
private Vector3 EngelPingPong2 = new Vector3(7f,0f,0f);
private Vector3 EngelPingPongDikey1 = new Vector3(4.94f,-1.58f,0f);
private Vector3 EngelPingPongDikey2 = new Vector3(4.94f,2.85f,0f);
private Vector3 EngelPingPongDikey3 = new Vector3(0.9f,-1.58f,0f);
private Vector3 EngelPingPongDikey4 = new Vector3(0.9f,2.85f,0f);
private Vector3 EngelPingPongDikey5 = new Vector3(2.9f,-1.58f,0f);
private Vector3 EngelPingPongDikey6 = new Vector3(2.9f,2.85f,0f);
private Vector3 EngelPingPongDikey7 = new Vector3(5.3f,-1.58f,0f);
private Vector3 EngelPingPongDikey8 = new Vector3(5.3f,2.2f,0f);

//private Vector3 PlatformPingPongPos3 = new Vector3(-7.84f,1.45f,-0.05994832f);
//private Vector3 PlatformPingPongPos4  = new Vector3(0.0f,1.45f,-0.05994832f);
private float ScoreTime=30000;
	private int maxLevel = 57;


	// Use this for initialization
	void Start () {
		//if(PlayerPrefs.HasKey("SonSeviye")) {
		//	Seviye = PlayerPrefs.GetInt("SonSeviye");
	    //}
		Seviye = PlayerPrefs.GetInt("SelectedLevel");
		//GameObject.Find("TopHakkiUI").GetComponent<Text>().text=tophakki.ToString();?????????
		GameObject.Find("TopHakkiUI").GetComponent<Text>().text="BALLS: " + (tophakki - launchTimes);
		
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

        if(isBallSpawnable) {
        topSayaci++;
		GameObject top1 = Instantiate(topPrefab[topNumarası],topPozisyonu,topQuternionu,gameObject.transform);
		top1.GetComponent<topcontrol>().topNumarası= topSayaci;
		
		topHakkıBonus.text="BONUS: " + (tophakki - launchTimes) *1000;
		//GameObject.Find("TopHakkiUI").GetComponent<Text>().text=tophakki.ToString();

		 GameObject.Find("TopHakkiUI").GetComponent<Text>().text="BALLS: " + (tophakki - launchTimes);
		}
	}
	// Update is called once per frame
	void Update () {
		ScoreTime -= Time.deltaTime * 500;	
	}

	public void resetBallCount(){
		tophakki = 5;
        launchTimes = 0;
	}
	public void SeviyeyiArttır(){
		foreach(Transform child in gameObject.transform){
			GameObject.Destroy(child.gameObject);
		}
		//Seviye++;
		print(Seviye);
		if(Seviye<=99){
			RespawnPlatform();
		}
		else if(Seviye>=100){
			RespawnPlatform2();
		}
		resetBallCount();

           if(Seviye>=46 && Seviye <=75){
		   RespawnEngel();
	   }
		if (Seviye>75){
			RespawnBoru();
		}
    
        StartCoroutine(RespawnTop());

            RespawnKutu(); 

		ResetScore();
		
		
		arkaplanResmi.sprite=arkaplanResimleri[Random.Range(0,arkaplanResimleri.Count)];
		//zeminRengi.color=new Color(Random.Range(0f,1f), Random.Range(0f,1f), Random.Range(0f,1f), 1f);
		if(Seviye<=5){
		  zeminRengi.color=new Color(1.0f,1.0f,1.0f,1.0f);
		}
		else if(Seviye<=10){
		  zeminRengi.color=new Color(0f,246f,255f,255f);
		}
		if(Seviye<=9){
		arkaplanResmi.sprite=arkaplanResimleri[(0)];
		} else if(Seviye>9 && Seviye <= 18){
		arkaplanResmi.sprite=arkaplanResimleri[(1)];
		} else if(Seviye>18 && Seviye <= 27){
		arkaplanResmi.sprite=arkaplanResimleri[(2)];
		} else if(Seviye>27 && Seviye <= 36){
		arkaplanResmi.sprite=arkaplanResimleri[(3)];
		} else if(Seviye>36 && Seviye <= 45){
		arkaplanResmi.sprite=arkaplanResimleri[(4)];
		} else if(Seviye>45 && Seviye <= 51){
		arkaplanResmi.sprite=arkaplanResimleri[(5)];
		} else if(Seviye>51 && Seviye <= 57){
		arkaplanResmi.sprite=arkaplanResimleri[(6)];
		} else if(Seviye>57 && Seviye <= 63){
		arkaplanResmi.sprite=arkaplanResimleri[(7)];
		} else if(Seviye>63 && Seviye <= 69){
		arkaplanResmi.sprite=arkaplanResimleri[(8)];
		} else if(Seviye>69 && Seviye <= 75){
		arkaplanResmi.sprite=arkaplanResimleri[(9)];
		}

		SeviyeGostergesi.text="LEVEL " + Seviye.ToString();
	
	}
	public void RespawnPlatform(){
		/*if(Seviye>=5){
			platformQuternionu = Quaternion.Euler(0f,0f,Random.Range(0f,30f));
		}*/
	    if(Seviye==1){
			platformPozisyonu=new Vector3(1.5f,0.58f,0f);
			Quaternion platformQuaternionu = Quaternion.identity;
		}
		else if(Seviye==2){
			platformPozisyonu=new Vector3(-1.5f,0.58f,0);
			Quaternion platformQuaternionu = Quaternion.identity;
		}
		else if(Seviye==3){
			platformPozisyonu=new Vector3(-6.26f,0.58f,0f);
			Quaternion platformQuaternionu = Quaternion.identity;
		}
		else if(Seviye==4){
			platformPozisyonu=new Vector3(1.5f,1.255358f,0);
			Quaternion platformQuaternionu = Quaternion.identity;
		}
		else if(Seviye==5){
			platformPozisyonu=new Vector3(-1.5f,1.255358f,0f);
			Quaternion platformQuaternionu = Quaternion.identity;
		}
		else if(Seviye==6){
			platformPozisyonu=new Vector3(-6.26f,1.255358f,0f);
			Quaternion platformQuaternionu = Quaternion.identity;
		}
		else if(Seviye==7){
				platformPozisyonu=new Vector3(1.5f,1.8f,0f);
			Quaternion platformQuaternionu = Quaternion.identity;
		}
			else if(Seviye==8){
				platformPozisyonu=new Vector3(-1.5f,1.8f,0f);
			Quaternion platformQuaternionu = Quaternion.identity;
		}
			else if(Seviye==9){
				platformPozisyonu=new Vector3(-6.26f,1.8f,0f);
			Quaternion platformQuaternionu = Quaternion.identity;
		}
			else if(Seviye==10){
                platformPozisyonu = new Vector3(1.2f,0.2f,0f);
				platformQuaternionu = Quaternion.Euler(0f,0f,10f);
			}
		
		else if(Seviye==11){
          platformPozisyonu=new Vector3(1.2f,1.0f,0f);
		  platformQuaternionu = Quaternion.Euler(0f,0f,11f);
		}
		else if(Seviye==12){
          platformPozisyonu=new Vector3(1.2f,2.4f,0f);
		  platformQuaternionu = Quaternion.Euler(0f,0f,12f);
		}
		else if(Seviye==13){
			platformPozisyonu=new Vector3(-1.36f,0.2f,0f);
			platformQuaternionu=Quaternion.Euler(0f,0f,13f);
		}
			else if(Seviye==14){
				platformPozisyonu=new Vector3(-1.36f,1.0f,0f);
				platformQuaternionu= Quaternion.Euler(0f,0f,14f);
			}
			else if(Seviye==15){
                platformPozisyonu=new Vector3(-1.36f,2.4f,0f);
				platformQuaternionu= Quaternion.Euler(0f,0f,15f);
			}
			else if(Seviye==16){
                platformPozisyonu=new Vector3(-6.3f,0.2f,0f);
				platformQuaternionu= Quaternion.Euler(0f,0f,16f);
			}
			else if(Seviye==17){
                platformPozisyonu=new Vector3(-6.3f,1.0f,0f);
					platformQuaternionu= Quaternion.Euler(0f,0f,17f);
			}
			
			else if(Seviye==18){
                platformPozisyonu=new Vector3(-6.3f,2.4f,0f);
					platformQuaternionu= Quaternion.Euler(0f,0f,18f);
			}
			else if(Seviye==19){
                platformPozisyonu=new Vector3(0.8f,2.4f,0f);
					platformQuaternionu= Quaternion.Euler(0f,0f,0f);
			}
			else if(Seviye==20){
                platformPozisyonu=new Vector3(0.8f,1.5f,0f);
					platformQuaternionu= Quaternion.Euler(0f,0f,0f);
			}
			else if(Seviye==21){
                platformPozisyonu=new Vector3(-2.22f,2.56f,0f);
					platformQuaternionu= Quaternion.Euler(0f,0f,0f);
			}
			else if(Seviye==22){
                platformPozisyonu=new Vector3(0.8f,0.36f,0f);
					platformQuaternionu= Quaternion.Euler(0f,0f,0f);
			}
			else if(Seviye==23){
                platformPozisyonu=new Vector3(-1.93f,1.45f,0f);
					platformQuaternionu= Quaternion.Euler(0f,0f,0f);
			}
			else if(Seviye==24){
             platformPozisyonu=new Vector3(-5.28f,2.5f,0f);
				platformQuaternionu= Quaternion.Euler(0f,0f,0f);
				}
			else if(Seviye==25){
             platformPozisyonu=new Vector3(-2.46f,0.36f,0f);
				platformQuaternionu= Quaternion.Euler(0f,0f,0f);
				}
			else if(Seviye==26){
             platformPozisyonu=new Vector3(-4.93f,1.42f,0f);
				platformQuaternionu= Quaternion.Euler(0f,0f,0f);
				}
			else if(Seviye==27){
             platformPozisyonu=new Vector3(-5.3f,0.36f,0f);
				platformQuaternionu= Quaternion.Euler(0f,0f,0f);
				}	
			else if(Seviye==28){
             platformPozisyonu=new Vector3(-5.72f,2.32f,0f);
				platformQuaternionu= Quaternion.Euler(0f,0f,10f);
				}
			else if(Seviye==29){
             platformPozisyonu=new Vector3(1.5f,2.32f,0f);
				platformQuaternionu= Quaternion.Euler(0f,0f,11f);
				}	
			else if(Seviye==30){
             platformPozisyonu=new Vector3(-5.72f,0.2f,0f);
				platformQuaternionu= Quaternion.Euler(0f,0f,12f);
				}	
			else if(Seviye==31){
             platformPozisyonu=new Vector3(1.5f,0.2f,0f);
				platformQuaternionu= Quaternion.Euler(0f,0f,13f);
				}
			else if(Seviye==32){
             platformPozisyonu=new Vector3(-2.0f,2.32f,0f);
				platformQuaternionu= Quaternion.Euler(0f,0f,14f);
				}
			else if(Seviye==33){
             platformPozisyonu=new Vector3(-2.0f,0.2f,0f);
				platformQuaternionu= Quaternion.Euler(0f,0f,15f);
				}				
			else if(Seviye==34){
             platformPozisyonu=new Vector3(-5.72f,1.15f,-0f);
				platformQuaternionu= Quaternion.Euler(0f,0f,16f);
				}									
			else if(Seviye==35){
             platformPozisyonu=new Vector3(1.5f,1.15f,0f);
				platformQuaternionu= Quaternion.Euler(0f,0f,17f);
				}								
			else if(Seviye==36){
             platformPozisyonu=new Vector3(-2.0f,1.15f,0f);
				platformQuaternionu= Quaternion.Euler(0f,0f,18f);
				}	
			else if(Seviye==37){
             platformPozisyonu=new Vector3(1.6f,0.6f,0f);
				platformQuaternionu= Quaternion.Euler(0f,0f,0f);
				}		
			else if(Seviye==38){
             platformPozisyonu=new Vector3(-1.6f,0.6f,0f);
				platformQuaternionu= Quaternion.Euler(0f,0f,0f);
				}			
			else if(Seviye==39){
             platformPozisyonu=new Vector3(-6.0f,0.6f,0f);
				platformQuaternionu= Quaternion.Euler(0f,0f,0f);
				}
			else if(Seviye==40){
             platformPozisyonu=new Vector3(-6.0f,1.5f,-0f);
				platformQuaternionu= Quaternion.Euler(0f,0f,0f);
				}
			else if(Seviye==41){
             platformPozisyonu=new Vector3(-6.0f,2.6f,0f);
				platformQuaternionu= Quaternion.Euler(0f,0f,0f);
				}	
			else if(Seviye==42){
             platformPozisyonu=new Vector3(-1.6f,2.6f,0f);
				platformQuaternionu= Quaternion.Euler(0f,0f,0f);
				}		
			else if(Seviye==43){
             platformPozisyonu=new Vector3(1.6f,2.6f,0f);
				platformQuaternionu= Quaternion.Euler(0f,0f,0f);
				}	
			else if(Seviye==44){
             platformPozisyonu=new Vector3(1.6f,1.5f,0f);
				platformQuaternionu= Quaternion.Euler(0f,0f,0f);
				}				
			else if(Seviye==45){
             platformPozisyonu=new Vector3(-1.6f,1.5f,0f);
				platformQuaternionu= Quaternion.Euler(0f,0f,0f);
				}	
			 if(Seviye==46){
              platformPozisyonu=new Vector3(0.2f,0.58f,0f);
			Quaternion platformQuaternionu = Quaternion.identity;
				}		
			else if(Seviye==47){
            platformPozisyonu=new Vector3(0.2f,1.255358f,0f);
			Quaternion platformQuaternionu = Quaternion.identity;
				}	
			else if(Seviye==48){
            platformPozisyonu=new Vector3(-0.83f,1.2f,0f);
			Quaternion platformQuaternionu = Quaternion.identity;
				}	
			else if(Seviye==49){
            platformPozisyonu=new Vector3(-3.13f,1.2f,0f);
			Quaternion platformQuaternionu = Quaternion.identity;
				}		
			else if(Seviye==50){
            platformPozisyonu=new Vector3(-3.13f,2.16f,0f);
			Quaternion platformQuaternionu = Quaternion.identity;
				}	
			else if(Seviye==51){
            platformPozisyonu=new Vector3(-5.49f,2.16f,0f);
			Quaternion platformQuaternionu = Quaternion.identity;
				}		
			else if(Seviye==52){
            platformPozisyonu=new Vector3(1.83f,0.35f,0f);
			Quaternion platformQuaternionu = Quaternion.identity;
				}			
			else if(Seviye==53){
            platformPozisyonu=new Vector3(-0.87f,1.2f,0f);
			Quaternion platformQuaternionu = Quaternion.identity;
				}
			else if(Seviye==54){
            platformPozisyonu=new Vector3(-0.87f,0.35f,0f);
			Quaternion platformQuaternionu = Quaternion.identity;
				}			
				else if(Seviye==55){
            platformPozisyonu=new Vector3(-0.87f,2.25f,0f);
			Quaternion platformQuaternionu = Quaternion.identity;
				}		
				else if(Seviye==56){
            platformPozisyonu=new Vector3(1.83f,2.25f,0f);
			Quaternion platformQuaternionu = Quaternion.identity;
				}
				else if(Seviye==57){
            platformPozisyonu=new Vector3(-3.86f,1.3f,0f);
			Quaternion platformQuaternionu = Quaternion.identity;
				}		
				else if(Seviye==58){
            platformPozisyonu=new Vector3(0.3f,2.22f,0f);
			Quaternion platformQuaternionu = Quaternion.identity;
				}		
				else if(Seviye==59){
            platformPozisyonu=new Vector3(-2f,1.2f,0f);
			Quaternion platformQuaternionu = Quaternion.identity;
				}		
				else if(Seviye==60){
            platformPozisyonu=new Vector3(0.3f,0.3f,0f);
			Quaternion platformQuaternionu = Quaternion.identity;
				}
				else if(Seviye==61){
            platformPozisyonu=new Vector3(0.3f,1.2f,0f);
			Quaternion platformQuaternionu = Quaternion.identity;
				}							
				else if(Seviye==62){
            platformPozisyonu=new Vector3(-2f,0.3f,0f);
			Quaternion platformQuaternionu = Quaternion.identity;
				}
				else if(Seviye==63){
            platformPozisyonu=new Vector3(-2f,2.22f,0f);
			Quaternion platformQuaternionu = Quaternion.identity;
				}						
				else if(Seviye==64){
            platformPozisyonu=new Vector3(-3f,1.3f,0f);
			Quaternion platformQuaternionu = Quaternion.identity;
				}	
				else if(Seviye==65){
            platformPozisyonu=new Vector3(-0.7f,1.3f,0f);
			Quaternion platformQuaternionu = Quaternion.identity;
				}	
				else if(Seviye==66){
            platformPozisyonu=new Vector3(-3f,2.4f,0f);
			Quaternion platformQuaternionu = Quaternion.identity;
				}		
				else if(Seviye==67){
            platformPozisyonu=new Vector3(-5.3f,1.3f,0f);
			Quaternion platformQuaternionu = Quaternion.identity;
				}	
				else if(Seviye==68){
            platformPozisyonu=new Vector3(-5.3f,2.4f,0f);
			Quaternion platformQuaternionu = Quaternion.identity;
				}	
				else if(Seviye==69){
            platformPozisyonu=new Vector3(-5.3f,0.4f,0f);
			Quaternion platformQuaternionu = Quaternion.identity;
				}		
				else if(Seviye==70){
            platformPozisyonu=new Vector3(-4.72f,1.1f,0f);
			Quaternion platformQuaternionu = Quaternion.identity;
				}		
				else if(Seviye==71){
            platformPozisyonu=new Vector3(-2f,1.1f,0f);
			Quaternion platformQuaternionu = Quaternion.identity;
				}		
				else if(Seviye==72){
            platformPozisyonu=new Vector3(-4.72f,2.2f,0f);
			Quaternion platformQuaternionu = Quaternion.identity;
				}	
				else if(Seviye==73){
            platformPozisyonu=new Vector3(1.14f,2.2f,0f);
			Quaternion platformQuaternionu = Quaternion.identity;
				}				
				else if(Seviye==74){
            platformPozisyonu=new Vector3(1.14f,1.1f,0f);
			Quaternion platformQuaternionu = Quaternion.identity;
				}	
				else if(Seviye==75){
            platformPozisyonu=new Vector3(-2f,2.2f,0f);
			Quaternion platformQuaternionu = Quaternion.identity;
				}																																							
																																																																										
	
	
		// platformPozisyonu = new Vector3(Random.Range(-7.8f,-4f),Random.Range(1.0f,2.8f),0f);
		 topPozisyonu= platformPozisyonu + new Vector3(-0.5f,1f,0f);
		Instantiate(platformPrefab,platformPozisyonu,platformQuaternionu,gameObject.transform);
		
		}
		   public void RespawnEngel(){
        
            GameObject Engel=Instantiate(EngelPrefab,EngelPozisyonu,EngelQuaternionu,gameObject.transform);
         if(Seviye==46){
			Engel.GetComponent<EngelScript>().EnablePingPongEngel(EngelPingPong1,EngelPingPong2,0.1f,true);
			}
    		else if(Seviye==47){
			Engel.GetComponent<EngelScript>().EnablePingPongEngel(EngelPingPong1,EngelPingPong2,0.1f,true);
			}
			else if(Seviye==48){
			Engel.GetComponent<EngelScript>().EnablePingPongEngel(EngelPingPong1,EngelPingPong2,0.1f,true);
			}
			else if(Seviye==49){
			Engel.GetComponent<EngelScript>().EnablePingPongEngel(EngelPingPong1,EngelPingPong2,0.1f,true);
			}
			else if(Seviye==50){
			Engel.GetComponent<EngelScript>().EnablePingPongEngel(EngelPingPong1,EngelPingPong2,0.1f,true);
			}
			else if(Seviye==51){
			Engel.GetComponent<EngelScript>().EnablePingPongEngel(EngelPingPong1,EngelPingPong2,0.1f,true);
			}
			else if(Seviye==52){
			Engel.GetComponent<EngelScript>().EnablePingPongEngel(EngelPingPongDikey1,EngelPingPongDikey2,0.1f,true);
			}
			else if(Seviye==53){
			Engel.GetComponent<EngelScript>().EnablePingPongEngel(EngelPingPongDikey1,EngelPingPongDikey2,0.1f,true);
			}
			else if(Seviye==54){
			Engel.GetComponent<EngelScript>().EnablePingPongEngel(EngelPingPongDikey1,EngelPingPongDikey2,0.1f,true);
			}
				else if(Seviye==55){
			Engel.GetComponent<EngelScript>().EnablePingPongEngel(EngelPingPongDikey1,EngelPingPongDikey2,0.1f,true);
			}
				else if(Seviye==56){
			Engel.GetComponent<EngelScript>().EnablePingPongEngel(EngelPingPongDikey1,EngelPingPongDikey2,0.1f,true);
			}
			else if(Seviye==57){
			Engel.GetComponent<EngelScript>().EnablePingPongEngel(EngelPingPongDikey1,EngelPingPongDikey2,0.1f,true);
			}
			 if(Seviye==58){
			Engel.GetComponent<EngelScript>().EnablePingPongEngel(EngelPingPong1,EngelPingPong2,0.1f,true);
			}
			 if(Seviye==59){
			Engel.GetComponent<EngelScript>().EnablePingPongEngel(EngelPingPong1,EngelPingPong2,0.1f,true);
			}
			if(Seviye==60){
			Engel.GetComponent<EngelScript>().EnablePingPongEngel(EngelPingPong1,EngelPingPong2,0.1f,true);
			}
			if(Seviye==61){
			Engel.GetComponent<EngelScript>().EnablePingPongEngel(EngelPingPong1,EngelPingPong2,0.1f,true);
			}
			if(Seviye==62){
			Engel.GetComponent<EngelScript>().EnablePingPongEngel(EngelPingPong1,EngelPingPong2,0.1f,true);
			}
			if(Seviye==63){
			Engel.GetComponent<EngelScript>().EnablePingPongEngel(EngelPingPong1,EngelPingPong2,0.1f,true);
			}
			if(Seviye==64){
			Engel.GetComponent<EngelScript>().EnablePingPongEngel(EngelPingPongDikey3,EngelPingPongDikey4,0.1f,true);
			}
			if(Seviye==65){
			Engel.GetComponent<EngelScript>().EnablePingPongEngel(EngelPingPongDikey5,EngelPingPongDikey6,0.1f,true);
			}
			if(Seviye==66){
			Engel.GetComponent<EngelScript>().EnablePingPongEngel(EngelPingPongDikey3,EngelPingPongDikey4,0.1f,true);
			}
			if(Seviye==67){
			Engel.GetComponent<EngelScript>().EnablePingPongEngel(EngelPingPongDikey3,EngelPingPongDikey4,0.1f,true);
			}
			if(Seviye==68){
			Engel.GetComponent<EngelScript>().EnablePingPongEngel(EngelPingPongDikey3,EngelPingPongDikey4,0.1f,true);
			}
			if(Seviye==69){
			Engel.GetComponent<EngelScript>().EnablePingPongEngel(EngelPingPongDikey3,EngelPingPongDikey4,0.1f,true);
			}
			if(Seviye==70){
			Engel.GetComponent<EngelScript>().EnablePingPongEngel(EngelPingPongDikey7,EngelPingPongDikey8,0.1f,true);
			}
			if(Seviye==71){
			Engel.GetComponent<EngelScript>().EnablePingPongEngel(EngelPingPongDikey7,EngelPingPongDikey8,0.1f,true);
			}
			if(Seviye==72){
			Engel.GetComponent<EngelScript>().EnablePingPongEngel(EngelPingPongDikey7,EngelPingPongDikey8,0.1f,true);
			}
			if(Seviye==73){
			Engel.GetComponent<EngelScript>().EnablePingPongEngel(EngelPingPongDikey7,EngelPingPongDikey8,0.1f,true);
			}
			if(Seviye==74){
			Engel.GetComponent<EngelScript>().EnablePingPongEngel(EngelPingPongDikey7,EngelPingPongDikey8,0.1f,true);
			}
			if(Seviye==75){
			Engel.GetComponent<EngelScript>().EnablePingPongEngel(EngelPingPongDikey7,EngelPingPongDikey8,0.1f,true);
			}
		   }

			public void RespawnBoru(){
				if(Seviye==76){
					BoruPozisyonu = platformPozisyonu + new Vector3(0.5f,0f,0f);
				} 
				Instantiate(BoruPrefab,BoruPozisyonu,BoruQuaternionu,gameObject.transform);
			}
			
		
      	public void RespawnKutu(){
		//kutuPozisyonu=new Vector3(Random.Range(4.8f,6.1f),-1.49f,0f);
		if(Seviye<=18){
			kutuPozisyonu=new Vector3(5.8f,-1.49f,0f);
		}
		//if(Seviye==15){
			//kutuPozisyonu=new Vector3(8.59f,-1.49f,0f);
	//				}  
		//print(kutuPozisyonu);
		GameObject Kutu=Instantiate(KutuPrefab,kutuPozisyonu,kutuQuaternionu,gameObject.transform);

       /* if(Seviye==17){
        Kutu.GetComponent<KutuScript>().EnablePingPongKutu(KutuPingPongPos1,KutuPingPongPos2,0.1f,true);
		 
	}
	 if(Seviye==18){
        Kutu.GetComponent<KutuScript>().EnablePingPongKutu(KutuPingPongPos1,KutuPingPongPos2,0.15f,true);
		 
	}*/
	 if(Seviye==19){
        Kutu.GetComponent<KutuScript>().EnablePingPongKutu(KutuPingPongPos1,KutuPingPongPos2,0.1f,true);
		 
	}
	 if(Seviye==20){
        Kutu.GetComponent<KutuScript>().EnablePingPongKutu(KutuPingPongPos1,KutuPingPongPos2,0.12f,true); 
	}
    if(Seviye==21){
        Kutu.GetComponent<KutuScript>().EnablePingPongKutu(KutuPingPongPos1,KutuPingPongPos2,0.15f,true);	 
	}
	  if(Seviye==22){
        Kutu.GetComponent<KutuScript>().EnablePingPongKutu(KutuPingPongPos1,KutuPingPongPos2,0.17f,true);	 
	}
	if(Seviye==23){
        Kutu.GetComponent<KutuScript>().EnablePingPongKutu(KutuPingPongPos1,KutuPingPongPos2,0.20f,true);	 
	}
	if(Seviye==24){
        Kutu.GetComponent<KutuScript>().EnablePingPongKutu(KutuPingPongPos1,KutuPingPongPos2,0.23f,true);	 
	}
	if(Seviye==25){
        Kutu.GetComponent<KutuScript>().EnablePingPongKutu(KutuPingPongPos1,KutuPingPongPos2,0.25f,true);	 
	}
	if(Seviye==26){
        Kutu.GetComponent<KutuScript>().EnablePingPongKutu(KutuPingPongPos1,KutuPingPongPos2,0.27f,true);	 
	}
	if(Seviye==27){
        Kutu.GetComponent<KutuScript>().EnablePingPongKutu(KutuPingPongPos1,KutuPingPongPos2,0.30f,true);	 
	}
	if(Seviye==28){
        Kutu.GetComponent<KutuScript>().EnablePingPongKutu(KutuPingPongPos1,KutuPingPongPos2,0.33f,true);	 
	}
	if(Seviye==29){
        Kutu.GetComponent<KutuScript>().EnablePingPongKutu(KutuPingPongPos1,KutuPingPongPos2,0.35f,true);	 
	}
	if(Seviye==30){
        Kutu.GetComponent<KutuScript>().EnablePingPongKutu(KutuPingPongPos1,KutuPingPongPos2,0.37f,true);	 
	}
	if(Seviye==31){
        Kutu.GetComponent<KutuScript>().EnablePingPongKutu(KutuPingPongPos1,KutuPingPongPos2,0.40f,true);	 
	}
	if(Seviye==32){
        Kutu.GetComponent<KutuScript>().EnablePingPongKutu(KutuPingPongPos1,KutuPingPongPos2,0.43f,true);	 
	}
	if(Seviye==33){
        Kutu.GetComponent<KutuScript>().EnablePingPongKutu(KutuPingPongPos1,KutuPingPongPos2,0.45f,true);	 
	}
	if(Seviye==34){
        Kutu.GetComponent<KutuScript>().EnablePingPongKutu(KutuPingPongPos1,KutuPingPongPos2,0.47f,true);	 
	}
	if(Seviye==35){
        Kutu.GetComponent<KutuScript>().EnablePingPongKutu(KutuPingPongPos1,KutuPingPongPos2,0.50f,true);	 
	}
	if(Seviye==36){
        Kutu.GetComponent<KutuScript>().EnablePingPongKutu(KutuPingPongPos1,KutuPingPongPos2,0.53f,true);	 
	}
	if(Seviye==37){
		Kutu.GetComponent<KutuScript>().EnablePingPongKutu(KutuPingPongPosDikey2,KutuPingPongPosDikey1,0.1f,true);
	}
	if(Seviye==38){
		Kutu.GetComponent<KutuScript>().EnablePingPongKutu(KutuPingPongPosDikey2,KutuPingPongPosDikey1,0.12f,true);
	}
	if(Seviye==39){
		Kutu.GetComponent<KutuScript>().EnablePingPongKutu(KutuPingPongPosDikey2,KutuPingPongPosDikey1,0.15f,true);
	}
	if(Seviye==40){
		Kutu.GetComponent<KutuScript>().EnablePingPongKutu(KutuPingPongPosDikey2,KutuPingPongPosDikey1,0.17f,true);
	}
	if(Seviye==41){
		Kutu.GetComponent<KutuScript>().EnablePingPongKutu(KutuPingPongPosDikey2,KutuPingPongPosDikey1,0.2f,true);
	}
	if(Seviye==42){
		Kutu.GetComponent<KutuScript>().EnablePingPongKutu(KutuPingPongPosDikey2,KutuPingPongPosDikey1,0.23f,true);
	}
	if(Seviye==43){
		Kutu.GetComponent<KutuScript>().EnablePingPongKutu(KutuPingPongPosDikey2,KutuPingPongPosDikey1,0.25f,true);
	}
	if(Seviye==44){
		Kutu.GetComponent<KutuScript>().EnablePingPongKutu(KutuPingPongPosDikey2,KutuPingPongPosDikey1,0.27f,true);
	}
	if(Seviye==45){
		Kutu.GetComponent<KutuScript>().EnablePingPongKutu(KutuPingPongPosDikey2,KutuPingPongPosDikey1,0.3f,true);
	}
	if(Seviye==46){
	kutuPozisyonu=new Vector3(5.8f,-1.49f,0f);
	}	
	if(Seviye==47){
    kutuPozisyonu=new Vector3(5.8f,-1.49f,0f);
	}
	if(Seviye==48){
    kutuPozisyonu=new Vector3(5.8f,-1.49f,0f);
	}
	if(Seviye==49){
    kutuPozisyonu=new Vector3(5.8f,-1.49f,0f);
	}
	if(Seviye==50){
    kutuPozisyonu=new Vector3(5.8f,-1.49f,0f);
	}
	if(Seviye==51){
    kutuPozisyonu=new Vector3(5.8f,-1.49f,0f);
	}
	if(Seviye==52){
    kutuPozisyonu=new Vector3(5.8f,-1.49f,0f);
	}
	if(Seviye==53){
    kutuPozisyonu=new Vector3(5.8f,-1.49f,0f);
	}
	if(Seviye==54){
    kutuPozisyonu=new Vector3(5.8f,-1.49f,0f);
	}
    if(Seviye==55){
    kutuPozisyonu=new Vector3(5.8f,-1.49f,0f);
	}
	if(Seviye==56){
    kutuPozisyonu=new Vector3(5.8f,-1.49f,0f);
	}
	if(Seviye==57){
    kutuPozisyonu=new Vector3(5.8f,-1.49f,0f);
	}
	 if(Seviye==58){
        Kutu.GetComponent<KutuScript>().EnablePingPongKutu(KutuPingPongPos2,KutuPingPongPos1,0.1f,true);
	 }
	  if(Seviye==59){
        Kutu.GetComponent<KutuScript>().EnablePingPongKutu(KutuPingPongPos2,KutuPingPongPos1,0.1f,true);
	 }
	 if(Seviye==60){
        Kutu.GetComponent<KutuScript>().EnablePingPongKutu(KutuPingPongPos2,KutuPingPongPos1,0.1f,true);
	 }
	 if(Seviye==61){
        Kutu.GetComponent<KutuScript>().EnablePingPongKutu(KutuPingPongPos2,KutuPingPongPos1,0.1f,true);
	 }
	  if(Seviye==62){
        Kutu.GetComponent<KutuScript>().EnablePingPongKutu(KutuPingPongPos2,KutuPingPongPos1,0.1f,true);
	 }
	  if(Seviye==63){
        Kutu.GetComponent<KutuScript>().EnablePingPongKutu(KutuPingPongPos2,KutuPingPongPos1,0.1f,true);
	 }
	 if(Seviye==64){
        Kutu.GetComponent<KutuScript>().EnablePingPongKutu(KutuPingPongPos2,KutuPingPongPos1,0.1f,true);
	 }
	 if(Seviye==65){
        Kutu.GetComponent<KutuScript>().EnablePingPongKutu(KutuPingPongPos2,KutuPingPongPos3,0.1f,true);
	 }
	 if(Seviye==66){
        Kutu.GetComponent<KutuScript>().EnablePingPongKutu(KutuPingPongPos2,KutuPingPongPos1,0.1f,true);
	 }
	 if(Seviye==67){
        Kutu.GetComponent<KutuScript>().EnablePingPongKutu(KutuPingPongPos2,KutuPingPongPos1,0.1f,true);
	 }
	 if(Seviye==68){
        Kutu.GetComponent<KutuScript>().EnablePingPongKutu(KutuPingPongPos2,KutuPingPongPos1,0.1f,true);
	 }
	 if(Seviye==69){
        Kutu.GetComponent<KutuScript>().EnablePingPongKutu(KutuPingPongPos2,KutuPingPongPos1,0.1f,true);
	 }
	 if(Seviye==70){
        Kutu.GetComponent<KutuScript>().EnablePingPongKutu(KutuPingPongPosDikey3,KutuPingPongPosDikey1,0.1f,true);
	 }
	 if(Seviye==71){
        Kutu.GetComponent<KutuScript>().EnablePingPongKutu(KutuPingPongPosDikey3,KutuPingPongPosDikey1,0.1f,true);
	 }
	 if(Seviye==72){
        Kutu.GetComponent<KutuScript>().EnablePingPongKutu(KutuPingPongPosDikey3,KutuPingPongPosDikey1,0.1f,true);
	 }
	 if(Seviye==73){
        Kutu.GetComponent<KutuScript>().EnablePingPongKutu(KutuPingPongPosDikey3,KutuPingPongPosDikey1,0.1f,true);
	 }
	 if(Seviye==74){
        Kutu.GetComponent<KutuScript>().EnablePingPongKutu(KutuPingPongPosDikey3,KutuPingPongPosDikey1,0.1f,true);
	 }
	 if(Seviye==75){
        Kutu.GetComponent<KutuScript>().EnablePingPongKutu(KutuPingPongPosDikey3,KutuPingPongPosDikey1,0.1f,true);
	 }
		 
}
   
	public void RespawnPlatform2(){
			/*if(Seviye>=11){
			platform2Quternionu = Quaternion.Euler(0f,0f,Random.Range(0f,50f));
			}*/
			if(Seviye==100){//11
				platform2Pozisyonu=new Vector3(0.25f,0.7f,0f);
			}
			if(Seviye==101){//12
				platform2Pozisyonu=new Vector3(0.25f,2.7f,0f);
			}
			if(Seviye==102){//13
				platform2Pozisyonu=new Vector3(-7.41f,2.7f,0f);
			}
				if(Seviye==103){//14
                platform2Pozisyonu=new Vector3(-6.7f,1.42f,0f);
			}
			if(Seviye==104){//15
				platform2Pozisyonu=new Vector3(-1.69f,0.14f,0f);
				platform2Quaternionu= Quaternion.Euler(0f,0f,15f);
			}
			if(Seviye==105){//16
                platform2Pozisyonu=new Vector3(-8.19f,1.0f,0f);
				platform2Quaternionu= Quaternion.Euler(0f,0f,15f);
			}
			if(Seviye==106){//17
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

	public void resetBonusUi(){
		resetBallCount();
		GameObject.Find("TopHakkiUI").GetComponent<Text>().text="BALLS: " + (tophakki - launchTimes);
		topHakkıBonus.text="BONUS: " + (tophakki - launchTimes) *1000;

	}

	public void setBallNumber(int num){
		topNumarası=num;
	}

    public int getBallNumber()
    {
        return topNumarası;
    }

	public void setIsBallSpawnable(bool var) {
		isBallSpawnable = var;
	}

	void OnApplicationQuit()
    {
		PlayerPrefs.SetInt("SonSeviye", Seviye-1);
    }

	public int getMaxLevel()
	{
		return maxLevel;
	}

	public void changeLevel(int level)
	{
		Seviye = level-1;
		
	}
}
