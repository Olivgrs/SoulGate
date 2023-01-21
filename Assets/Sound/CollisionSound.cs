using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSound : MonoBehaviour
{
    public AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        audio.Play();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        audio.Play();
    }
}
