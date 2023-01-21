using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class PickupLight : Pickup
{

    public GameObject light;
    // Start is called before the first frame update
    void Start()
    {
        base.initialize();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    protected override void pickUp(Collider2D other)
    {
        Debug.Log("Je suis surchargé");
        light.SetActive(true);
        base.pickUp(other);
    }
}
