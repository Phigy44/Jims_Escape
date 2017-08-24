using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class LightAnimation : MonoBehaviour
{

    Light spotlight;
    float ticker = 0f;
    float lastAngleValue = 0f;
    System.Random rnd = new System.Random();

    //amountOfSwing is a multiplication of the sine value. use this value to adjust the amount of rising and lowering the angle. should be randomised.
    float amountOfSwing = 0f;
    public int maxAmountOfSwing = 0;
    public int minAmountOfSwing = 0;

    //speedOfChange stretches the sine curve on the x-axis. use this value to determine how fast the light should change. should be randomised.
    float speedOfChange = 0f;
    public int maxSpeedOfChange = 0;
    public int minSpeedOfChange = 0;

    //averageAngle is added to the sine curve. it therefor will swing around this value. should be determined by the amount of fuel to feed the lamp.
    public float averageAngle = 100f;

    void Start()
    {
        spotlight = GetComponent<Light>();
        randomizeSine();
    }

    void Update()
    {
        //TODO Change the SpotAngle

        lastAngleValue = spotlight.spotAngle;
        //spotlight.spotAngle = (amountOfSwing * Mathf.Sin(speedOfChange * (ticker)) + averageAngle);
        spotlight.spotAngle = (amountOfSwing * Mathf.Sin(ticker) + averageAngle);
        Debug.Log("angle = " + spotlight.spotAngle + " | swing = " + amountOfSwing + " | speed " + speedOfChange);

        //tick up timer
        ticker += Time.deltaTime;

        if (Math.Round(spotlight.spotAngle) == averageAngle)
        {
            randomizeSine();
         //   ticker = 0;
        }

       //TODO fix for different speeds. maybe use multiple random sine-curves added together and change their params after a random time
    }

    void randomizeSine()
    {
        amountOfSwing = rnd.Next(minAmountOfSwing, maxAmountOfSwing + 1);
        speedOfChange = rnd.Next(minSpeedOfChange, maxSpeedOfChange + 1);
    }
}
