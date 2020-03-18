using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelSelect : MonoBehaviour
{
    private int LevelValue = 0;
    public void LevelSelected(){
       PlayerPrefs.SetInt("SelectedLevel", LevelValue);
    }

    public void SetLevelValue(int val) {
        LevelValue = val;
        return;
    }
    public int GetLevelValue() {
        return LevelValue;
    }
}
