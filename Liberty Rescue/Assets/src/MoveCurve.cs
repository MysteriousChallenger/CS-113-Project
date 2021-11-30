using System;
using UnityEngine;
using System.Collections;
public abstract class MoveCurve {
    public abstract float Acceleration(float velocity, float input);
}


public class TopSpeedCurve: MoveCurve {

    public float topSpeed;
    public float accelerationTime;
    public float decelerationTime;
    public TopSpeedCurve(float topSpeed, float accelerationTime, float decelerationTime) {
        this.topSpeed = topSpeed;
        this.accelerationTime = accelerationTime;
        this.decelerationTime = decelerationTime;
    }
    public override float Acceleration(float velocity, float input) {
        int inputSign = Math.Sign(input);
        int velocitySign = Math.Sign(velocity);
        float speed = Math.Abs(velocity);

        if (input == 0 || input * velocity < 0){
            // decelerating
            float decelerationRate = topSpeed / decelerationTime;
            return Math.Min(decelerationRate, speed) * -velocitySign;
            
        } else {
            // accelerating
            float accelerationRate = topSpeed / accelerationTime;
            float inputMagnitude = Math.Abs(input);
            float topSpeedAtInputLevel = topSpeed * inputMagnitude;
            float speedUntilMaxSpeed = Math.Max(topSpeedAtInputLevel - speed, 0);
            return Math.Min(accelerationRate, speedUntilMaxSpeed) * inputSign;
        }
    }
}