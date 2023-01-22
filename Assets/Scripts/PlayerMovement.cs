using UnityEngine;
using System;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public changingSprite LevierSprite;
    public float moveSpeed;
    public float horizontalMovement, verticalMovement;
    bool isInsidePorte = false;
    bool isInsideLevier = false;
    bool levierHasBeenPool = false;
    bool porteIsOpen = false;

    public TextMeshProUGUI text;

    public bool isPause = false;

    public Rigidbody2D rb;
    private Vector3 velocity = Vector3.zero;
    public AudioSource audio;


    // Ajoutez une r�f�rence au composant Sprite du joueur
    public SpriteRenderer playerSprite;
    // Ajoutez une r�f�rence au sprite que vous souhaitez utiliser
    public Sprite newSprite;

    // Ajoutez une r�f�rence au composant Animator du joueur
    public Animator playerAnimator;
    // Ajoutez une r�f�rence au nom de l'�tat d'animation associ� au nouveau sprite
    public string newAnimationState;

    public Button play;
    public GameObject pause;

    public GameObject light, compass, map, doorPlace;

    public bool ennemy = false;
    public bool asLight = false;
    public bool asCompass = false;
    public bool asMap = false;

    private void Start()
    {
        text.text = "Il vous faut vite trouver le levier pour ouvrir la porte.";
        if(konamiCode.konamiCodeComplete == true)
        {
            text.text += " Mais ... Mais... qui �tes vous ?";
            playerSprite.sprite = newSprite;
            // Changez l'animation du joueur en utilisant la r�f�rence au composant Animator et le nom de l'�tat d'animation
            playerAnimator.Play(newAnimationState);
            Debug.Log("Changement effectu�");
        }
        //play.onClick.AddListener(UnPause);
        //pause.SetActive(false);
    }

    private void Update()
    {
        
    }

    void FixedUpdate()
    {
        MovePlayer(horizontalMovement, verticalMovement);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log(collider.tag);
        if(collider.tag == "Levier" )
        {
            text.text = "Vous vous trouvez pr�s du levier. Tirer le en appuyant sur E";
            isInsideLevier = true;
        }
        if (collider.tag == "Porte")
        {
            text.text = "Vous voici pr�s de la porte. Ouvrez la avec E.";
            isInsidePorte = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        isInsideLevier = isInsidePorte = false;
    }

    void MovePlayer(float _horizontalMovement, float _verticalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, _verticalMovement);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);
    }

    public void OnDeverouillerPorte()
    {
        if(isInsideLevier && !levierHasBeenPool)
        {
            text.text = "Levier acction�. Il vous faut ouvrir la porte sans vous faire attraper par le monstre.";
            levierHasBeenPool = true;
            LevierSprite.changerSprite();
        }

        if (isInsidePorte)
        {
            if(!levierHasBeenPool)
            {
                text.text = "Vous n'avez pas encore actionn�e le levier.";
                return;
            }
            audio.Play();
            Debug.Log("C'est gagner");
            SceneManager.LoadScene("Win");
        }
    }

    public void OnHorizontalMovement(InputValue val)
    {
        horizontalMovement = val.Get<float>() * moveSpeed * Time.fixedDeltaTime;
    }

    public void OnVerticalMovement(InputValue val)
    {
        verticalMovement = val.Get<float>() * moveSpeed * Time.fixedDeltaTime;
    }

    public void OnObject1(InputValue val)
    {
        if(asLight)
        {
            resetItems();
            activateLight();
        }
    }

    public void OnObject2(InputValue val)
    {
        if (asCompass)
        {
            resetItems();
            activateCompass();
        }
    }

    public void OnObject3(InputValue val)
    {
        if (asMap)
        {
            resetItems();
            activateMap();
        }
    }

    public void activateLight()
    {
        light.SetActive(true);
    }

    public void activateCompass()
    {
        compass.SetActive(true);
    }

    public void activateMap()
    {
        doorPlace.SetActive(true);
        map.SetActive(true);
    }

    public void resetItems()
    {

        map.SetActive(false);
        light.SetActive(false);
        compass.SetActive(false);
        doorPlace.SetActive(false);
    }

    public void OnPause(InputValue val)
    {
        if (isPause)
        {
            UnPause();
        }
        else
        {
            Pause();
        }
    }

    public void Pause()
    {
        Time.timeScale = 0; //stop le temps

        pause.SetActive(true);

        isPause = true;
    }

    public void UnPause()
    {
        Time.timeScale = 1;

        pause.SetActive(false);

        isPause = false;
    }
}
