using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TopUI : MonoBehaviour {
          
		  public int topSeviyeSınırı;
		  public int topNumarası;
	// Use this for initialization
	private void OnEnable(){
        setBallUiText();
        int CurrentLevel=GameObject.Find("respawner").GetComponent<respawnerScript>().Seviye;
		if(CurrentLevel<topSeviyeSınırı){
			GetComponent<Image>().color=new Color(0.3f,0.3f,0.3f);
		} 
        else{
			GetComponent<Image>().color=new Color(1f,1f,1f);
		}
	}

    private void Update()
    {
        if(GameObject.Find("respawner").GetComponent<respawnerScript>().getBallNumber() == topNumarası)
        {
           transform.GetChild(0).GetComponent<Text>().text = "SELECTED";
            for (var i = 0; i < transform.parent.childCount; i++)
            {
                if (transform.parent.GetChild(i).gameObject.GetComponent<TopUI>().topNumarası != topNumarası)
                {
                    transform.parent.GetChild(i).gameObject.GetComponent<TopUI>().setBallUiText();
                }
            }
        }
    }
    public void TopNumarasınıYolla(){
		if(GameObject.Find("respawner").GetComponent<respawnerScript>().Seviye >= topSeviyeSınırı){

			GameObject.Find("respawner").GetComponent<respawnerScript>().setBallNumber(topNumarası);
		}
	} 

    public void setBallUiText()
    {
        transform.GetChild(0).GetComponent<Text>().text = "LEVEL " + topSeviyeSınırı;
    }

    public void SelectedBall()
    {

    }
}
