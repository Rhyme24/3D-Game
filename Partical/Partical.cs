using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Partical : MonoBehaviour {

    public float size ;
    public Slider mainSlider;
    private ParticleSystem partical;
    // Use this for initialization
    void Start () {
        partical = GetComponent<ParticleSystem>();
        var main = partical.main;
    }
	
	// Update is called once per frame
	void Update () {
        var main = partical.main;
        main.startSize = size + mainSlider.value;
        
    }
}
