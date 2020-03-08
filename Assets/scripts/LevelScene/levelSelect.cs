using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelSelect : MonoBehaviour
{
    public void LevelSelected(int value){
       PlayerPrefs.SetInt("SelectedLevel", value);
    }
}
