using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class CollisionSound : MonoBehaviour
{
    public AudioSource audio;
    public GameObject ennemy;

    public TextMeshProUGUI textNbCoup;
    public TextMeshProUGUI infoBulle;

    [SerializeField]
    private int nbMs = 100;
    private bool untouchable = false;

    [SerializeField]
    private int nbCollision = 3;
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
        if (untouchable)
            return;
        StartCoroutine(InvicibilityBuffer());
        untouchable = true;
        if (collider.tag != "Levier" && collider.tag != "Porte" && collider.tag != "Collectable" )
        {
            nbCollision-=1;
            textNbCoup.text = nbCollision.ToString();
        }

        if(nbCollision == 0 )
        {
            infoBulle.text = "Vous avez réveillez le monstre. Fuyez !!!";
            ennemy.SetActive(true);
        }
    }

    IEnumerator InvicibilityBuffer()
    {
        yield return new WaitForSeconds(nbMs / 1000);
        untouchable = false;
    }
}
