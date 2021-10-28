using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SailProgress : MonoBehaviour
{
    private Renderer _renderer;
    private PlayerShip _ship;
    private MaterialPropertyBlock _propBlock;

    private void Start()
    {
        _propBlock = new MaterialPropertyBlock();
        _renderer = GetComponent<Renderer>();
        _ship = GetComponentInParent<PlayerShip>();
    }

    private void Update()
    {
        _renderer.GetPropertyBlock(_propBlock);
        _propBlock.SetFloat("_Segment_Count", _ship.sailChangeSpeed);
        _propBlock.SetFloat("_Removed_Segments", _ship.SailChangePercent * _ship.sailChangeSpeed);
        _renderer.SetPropertyBlock(_propBlock);
    }
}
