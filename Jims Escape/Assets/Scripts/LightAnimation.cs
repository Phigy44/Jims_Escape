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

    //number of zero-passes the sine goes through before re-randomizing values
    int currentNumOfZeroPasses = 0;
    int maxNumOfZeroPasses = 0;
    public int minPassesToRerandomizing = 0;
    public int maxPassesToRerandomizing = 0;

    //amountOfSwing is a multiplication of the sine value. use this value to adjust the amount of rising and lowering the angle. should be randomised.
    float amountOfSwing = 0f;
    public int minAmountOfSwing = 0;
    public int maxAmountOfSwing = 0;
    
    //speedOfChange stretches the sine curve on the x-axis. use this value to determine how fast the light should change. should be randomised.
    //this values act like wind on the lamp.
    float speedOfAngleChange = 0f;
    public int minWindspeed = 0;
    public int maxWindspeed = 0;

    //averageAngle is added to the sine curve. it therefor will swing around this value. should be determined by the amount of fuel to feed the lamp.
    //TODO connect average Angle with the amount of fuel left in the lamp. delete averageAngle = spotlight.spotAngle from start-method
    float averageAngle = 100f;

    void Start()
    {
        spotlight = GetComponent<Light>();
        averageAngle = spotlight.spotAngle;
        randomize();
    }

    void Update()
    {
        lastAngleValue = spotlight.spotAngle;
        spotlight.spotAngle = (amountOfSwing * Mathf.Sin(speedOfAngleChange * (ticker)) + averageAngle);

        //tick up timer
        ticker += Time.deltaTime;

        //last value is higher than the value the sine swings around and current value is lower --> sine passed from higher to lower half --> randomize, resest timer
        //last value is lower than the value the sine swings around and current value is higher --> sine passed from lower to higher half --> randomize, reset timer
        if ((lastAngleValue > averageAngle && spotlight.spotAngle < averageAngle) || (lastAngleValue < averageAngle && spotlight.spotAngle > averageAngle))
        {
            currentNumOfZeroPasses++;
            if(currentNumOfZeroPasses >= maxNumOfZeroPasses)
            {
                currentNumOfZeroPasses = 0;
                ticker = 0;
                randomize();
            }
        }
    }

    void randomize()
    {
        amountOfSwing = rnd.Next(minAmountOfSwing, maxAmountOfSwing + 1);
        speedOfAngleChange = rnd.Next(minWindspeed, maxWindspeed + 1);
        maxNumOfZeroPasses = rnd.Next(minPassesToRerandomizing, maxPassesToRerandomizing + 1);
        //subtract "windspeed" from nr of passes. this causes medium to high wind to act on the lamp for a very short time only
        maxNumOfZeroPasses = (int)Math.Round(maxNumOfZeroPasses - speedOfAngleChange);
    }
}
