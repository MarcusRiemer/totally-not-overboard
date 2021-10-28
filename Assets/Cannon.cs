using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Cannon : MonoBehaviour
{
    public Transform cannonBallOrigin;

    public GameObject cannonBall;

    public float shotDelay = 2;

    private float lastShot = 0;

    private void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= lastShot + shotDelay)
        {
            var ball = Instantiate(cannonBall, cannonBallOrigin.position, cannonBallOrigin.rotation);
            ball.transform.parent = CannonBallsRoot.transform;
            ball.transform.forward = cannonBallOrigin.forward;
            lastShot = Time.time;
            
            Debug.Log($"Shot: Time.time = {Time.time}, lastShot = {lastShot}, shotDelay = {shotDelay}");
        }
    }
    
    private GameObject CannonBallsRoot => GameObject.Find("CannonBalls");
}
