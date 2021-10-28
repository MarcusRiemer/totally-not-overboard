using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    private GameObject[] sailObjects = { };

    private void Start()
    {
        var front = transform.Find("sail_front 1").gameObject;
        var middle = transform.Find("sail_middle 1").gameObject;
        var back = transform.Find("sail_back 1").gameObject;

        sailObjects = new [] {front, middle, back};
        
        Debug.Assert(front != null, $"Could not find {nameof(front)} sail object");
        Debug.Assert(middle != null, $"Could not find {nameof(middle)} sail object");
        Debug.Assert(back != null, $"Could not find {nameof(back)} sail object");
        
        activateSails(0);
    }

    public void activateSails(int num)
    {
        for (int i = 0; i < sailObjects.Length; i++)
        {
            sailObjects[i].SetActive(i < num);
        }
    }
}
