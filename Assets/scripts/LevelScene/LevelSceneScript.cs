using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSceneScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start(){
        PlayerPrefs.SetInt("SelectedLevel", -1);
    }
    public void PlayLevel(){
        if(PlayerPrefs.GetInt("SelectedLevel") != -1){
            SceneManager.LoadScene("PlayScene", LoadSceneMode.Single);
        }
    }
}
