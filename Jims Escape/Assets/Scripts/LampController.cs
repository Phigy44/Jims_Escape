using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LampController : MonoBehaviour {
    public Slider oilSlider;
    public int OilAmout = 100;

    public float timeLeft;
    void Start () 
	{
        timeLeft = OilAmout;
    }
	
	
	void Update () 
	{
        oilSlider.value = OilAmout;
        
        timeLeft -= Time.deltaTime ;
        OilAmout = (int)timeLeft;
        if (timeLeft < 0) {
            Debug.Log("No Time Left");
        }
	}
}
