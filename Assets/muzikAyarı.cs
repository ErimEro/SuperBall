using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class muzikAyarı : MonoBehaviour {
public AudioSource muzikÇalar;
private Slider slider;
	// Use this for initialization
	void Start () {
		slider=GetComponent<Slider>();

	}
	
	// Update is called once per frame
	void Update () {
		muzikÇalar.volume=slider.value;
	}
}
