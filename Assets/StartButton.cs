using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.activeInHierarchy){
            waitForStart();
        }
    }

    private void waitForStart(){
        Time.timeScale=0;
    }
    public void StartGame(){
        Time.timeScale=1;
    }
}
