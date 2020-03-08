using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeviyeButonScripti : MonoBehaviour
{
    public GameObject LevelButton;
    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("UnlockedLevels")){
            PlayerPrefs.SetInt("UnlockedLevels", 10);
        }

        int UnlockedLevels = PlayerPrefs.GetInt("UnlockedLevels");
        int LevelLimit = PlayerPrefs.GetInt("LevelLimit");

        for(int i=0; i<UnlockedLevels; i++){
            GameObject buton = Instantiate(LevelButton, gameObject.transform);
            //buton.GetComponent button.kasdkaskd = i+1;
            //buton.transform.GetChild(0).GetComponent= i+1
        }
    }
}
