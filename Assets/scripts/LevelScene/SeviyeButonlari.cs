using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeviyeButonlari : MonoBehaviour
{
    public GameObject LevelButton;
    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("UnlockedLevels")){
            PlayerPrefs.SetInt("UnlockedLevels", 1);
        }

        int UnlockedLevels = PlayerPrefs.GetInt("UnlockedLevels");
        int LevelLimit = PlayerPrefs.GetInt("LevelLimit");

        for(int i=0; i<UnlockedLevels; i++){
            GameObject buton = Instantiate(LevelButton, gameObject.transform);
            buton.GetComponent<levelSelect>().SetLevelValue(i+1);
            buton.transform.GetChild(0).gameObject.GetComponent<Text>().text = (i+1).ToString();
            
            string levelScoreString = (i+1).ToString() + "LevelScore";
            print(levelScoreString);
            buton.transform.GetChild(1).gameObject.GetComponent<Text>().text = PlayerPrefs.GetInt(levelScoreString).ToString();
        }
    }
}
