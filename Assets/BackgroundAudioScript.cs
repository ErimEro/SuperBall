using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundAudioScript : MonoBehaviour
{
    private static BackgroundAudioScript instance = null;
    public static BackgroundAudioScript Instance
    {
         get { return instance; }
    }

    void Awake()
    {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
            return;
        } else {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
