﻿/*
 * Author: 	Bryan Dedeurwaerder
 * Date: 	Mar 18. 2019
 * Email: 	bdedeurwaerder@nevada.unr.edu
 * Web: 	https://github.com/BryanDedeur
 * Project:	Assignment 5 - Converted into Unity
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Physics2D : Aspect
{
    // Update is called once per frame
    void Update()
    {
        // ----------------------------- ORIENTATION ADJUST ----------------------------- //
        if (prefab381.speed > 0) {
            
            // Get the direction of rotation
            int direction = 0;
            if (Mathf.Abs(prefab381.desiredHeading - prefab381.heading) > 180)
                direction = -1;
            else
                direction = 1;

            // Calculate the new heading based on current and desired heading
            if(prefab381.desiredHeading > prefab381.heading)
                prefab381.heading += direction * (prefab381.turnRate * Time.deltaTime);
                
            if (prefab381.desiredHeading < prefab381.heading)
                prefab381.heading -= direction * (prefab381.turnRate * Time.deltaTime);
            

            // Correct headings above 360
            prefab381.heading = LimitAngle(prefab381.heading);
            prefab381.desiredHeading = LimitAngle(prefab381.desiredHeading);
        }

        // ----------------------------- SPEED ADJUST --------------------------- //

        if (prefab381.desiredSpeed > prefab381.speed){
            prefab381.speed += prefab381.acceleration * Time.deltaTime;
        }
        if (prefab381.desiredSpeed < prefab381.speed){
            prefab381.speed -= prefab381.acceleration * Time.deltaTime;
        }
        
        // Cap the speed
        if (prefab381.speed > prefab381.maxSpeed)
            prefab381.speed = prefab381.maxSpeed;
        else if (prefab381.speed < prefab381.minSpeed)
            prefab381.speed = prefab381.minSpeed;

        // ----------------------------- POSITION ADJUST --------------------------- //
        
        // Calculate trig only on x and z axis
        prefab381.velocity.y = 0.0f; 
        prefab381.velocity.x = Mathf.Sin(DegToRad(prefab381.heading)) * prefab381.speed; 
        prefab381.velocity.z = Mathf.Cos(DegToRad(prefab381.heading)) * prefab381.speed; 

        // Capture the new position

        //Vector3 oldPos = prefab381.transform.position;
        //oldPos

    }
    
    // helper functions
    public static float DegToRad(float degrees)
    {
        var radians = (Mathf.PI / 180f) * degrees;
        return (radians);
    }
    
    public static float LimitAngle(float degrees)
    {
        return degrees > 360 ? degrees - 360 : (degrees < 0 ? 360 + degrees : degrees);
    }
}