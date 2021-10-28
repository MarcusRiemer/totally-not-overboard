using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Cannon : WorldEntity
{
    public Transform cannonBallOrigin;

    public GameObject cannonBall;

    public float shotDelay = 2;

    private float lastShot = 0;

    public void Shoot()
    {
        if (Time.time >= lastShot + shotDelay) 
        {
            var spawned = Instantiate(cannonBall, cannonBallOrigin.position, cannonBallOrigin.rotation);
            spawned.transform.parent = CannonBallsRoot.transform;
            spawned.transform.forward = cannonBallOrigin.forward;

            var shotEffect = GetComponent<VisualEffect>();
            var shotAttributes = shotEffect.CreateVFXEventAttribute();
            shotAttributes.SetVector3("WindDirection", worldRoot.windVector3);
            
            // TODO: Event triggers the effect in editor, somehow not ingame
            shotEffect.SendEvent("OnShoot");
            
            Debug.Log("OnShoot");
            
            lastShot = Time.time;
        }
    }

    private GameObject CannonBallsRoot => GameObject.Find("CannonBalls");
}
