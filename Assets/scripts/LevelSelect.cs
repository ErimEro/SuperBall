using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    private Dropdown dropdown;
    private int maxLevel;
    // Start is called before the first frame update
    void Start()
    {
        dropdown = GetComponent<Dropdown>();
        maxLevel = GameObject.Find("respawner").GetComponent<respawnerScript>().getMaxLevel();
        for(var i = 1; i<= maxLevel; i++)
        {
            dropdown.options.Add(new Dropdown.OptionData() { text = i.ToString() });
        }

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ClickedChangeLevel()
    {
        GameObject.Find("respawner").GetComponent<respawnerScript>().changeLevel(int.Parse(dropdown.options[dropdown.value].text));
    }
}
