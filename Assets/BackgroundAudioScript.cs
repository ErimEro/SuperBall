using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundAudioScript : MonoBehaviour
{
    private void Awake()
     {
        
     }
    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("AudioSourceExists") | PlayerPrefs.GetInt("AudioSourceExists") == 0){
            PlayerPrefs.SetInt("AudioSourceExists", 1);
            DontDestroyOnLoad(transform.gameObject);
        } else {
            GameObject.Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("AudioSourceExists", 0);
    }
}
