using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SesEfektAyarlari : MonoBehaviour {
	public List<AudioSource> SesEfektleri =new List<AudioSource>();
private Slider slider;

	// Use this for initialization
	void Start () {
		slider=GetComponent<Slider>();

	}
	
	// Update is called once per frame
	void Update () {
		foreach(var x in SesEfektleri){
			x.volume=slider.value;
		}
	}
}
