using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeviyeButonlari : MonoBehaviour
{
    public GameObject LevelButton;
    public GameObject LevelButtonLocked;

    // Start is called before the first frame update
    void Start()
    {
        int UnlockedLevels = PlayerPrefs.GetInt("UnlockedLevels");
        int LevelLimit = PlayerPrefs.GetInt("LevelLimit");
        int totalScore = 0;

        for(int i=0; i<LevelLimit; i++){
                if(i<UnlockedLevels){
                GameObject buton = Instantiate(LevelButton, gameObject.transform);
                buton.GetComponent<levelSelect>().SetLevelValue(i+1);
                buton.transform.GetChild(0).gameObject.GetComponent<Text>().text = (i+1).ToString();
                
                string levelScoreString = (i+1).ToString() + "LevelScore";
                //print(levelScoreString);
                buton.transform.GetChild(1).gameObject.GetComponent<Text>().text = PlayerPrefs.GetInt(levelScoreString).ToString();
                totalScore += PlayerPrefs.GetInt(levelScoreString);
                } else if(i<UnlockedLevels+3){
                    GameObject buton = Instantiate(LevelButtonLocked, gameObject.transform);
                    buton.transform.GetChild(0).gameObject.GetComponent<Text>().text = (i+1).ToString();
                }
        }
        GameObject.Find("SeviyeGrubu").GetComponent<RectTransform>().localPosition += new Vector3(-20000,0,0);
        GameObject.Find("skor").GetComponent<Text>().text = "Total Score " + totalScore.ToString();
    }
}
