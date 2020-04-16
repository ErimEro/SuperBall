using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonrakiSeviyeButon : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(GameObject.Find("respawner").GetComponent<respawnerScript>().Seviye == 103){
            print("hello");
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
