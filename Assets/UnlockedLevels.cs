using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UnlockedLevels : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int UnlockedLevels = PlayerPrefs.GetInt("UnlockedLevels");
        int LevelLimit = PlayerPrefs.GetInt("LevelLimit");
     //   gameObject.GetComponent<Text>().text = "Açılan Seviyeler: " + UnlockedLevels.ToString() + " / " + LevelLimit.ToString(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
