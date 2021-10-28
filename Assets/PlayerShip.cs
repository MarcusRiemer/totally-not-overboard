using System;
using UnityEngine;

public class PlayerShip : WorldEntity
{
    public Transform shipTransform;

    public float turnSpeed = 90;

    public Cannon activeCannon;

    private PlayerModel _model;

    /// <summary>
    /// Seconds it takes to make a sail change
    /// </summary>
    [Range(0.5f, 10)]
    public float sailChangeSpeed = 2;
    
    /// <summary>
    /// Timestamp where the last change to the sails was made
    /// </summary>
    private float _lastSailChange = -1;

    /// <summary>
    /// The maximum number of sails that may be hoisted
    /// </summary>
    public int maxHoistedSails = 3;

    /// <summary>
    /// The number of sails that currently contribute to the overall speed
    /// </summary>
    public int numHoistedSails = 0;

    protected override void WorldStart()
    {
        _model = GetComponentInChildren<PlayerModel>();
        _model.activateSails(numHoistedSails);
    }

    private void Update()
    {
        // Turn input
        shipTransform.rotation *= Quaternion.Euler(0,Input.GetAxis("Horizontal") * Time.deltaTime * turnSpeed,0) ;
        
        // Forward input
        float userSailChange = Input.GetAxis("Vertical"); 
        if (userSailChange != 0 && SailChangePossible)
        {
            if (userSailChange > 0)
            {
                numHoistedSails = Math.Min(numHoistedSails + 1, maxHoistedSails);
            }
            else
            {
                numHoistedSails = Math.Max(numHoistedSails - 1, 0);
            }
            _model.activateSails(numHoistedSails);
            _lastSailChange = Time.time;
        }
        
        // Possibly shooting
        if (Input.GetButton("Fire1"))
        {
            activeCannon.Shoot();
        }
        
        shipTransform.position += shipTransform.forward * Time.deltaTime * FullSailPercent;
    }

    /// <summary>
    /// True, if the sail could be changed at the current time
    /// </summary>
    private bool SailChangePossible => Time.time >= _lastSailChange + sailChangeSpeed;

    public float SailChangePercent => SailChangePossible ? 1 : (Time.time - _lastSailChange) / sailChangeSpeed;

    /// <summary>
    /// Forward momentum that is available by sails
    /// </summary>
    private float FullSailPercent => Mathf.Clamp01((float)numHoistedSails / maxHoistedSails);
}