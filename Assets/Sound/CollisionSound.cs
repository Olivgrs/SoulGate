using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionSound : MonoBehaviour
{
    public AudioSource audio;
    public GameObject ennemy;

    [SerializeField]
    private int nbCollision = 0;
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
        handleVoid(collision);
        audio.Play();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        handleVoid(collision.collider);
        audio.Play();
    }

    private void handleVoid(Collider2D collider)
    {
        if (collider.tag != "Levier" && collider.tag != "Porte")
            nbCollision++;
        if(nbCollision > 3 )
            ennemy.SetActive(true);
    }
}
