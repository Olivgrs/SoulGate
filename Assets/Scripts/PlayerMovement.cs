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
    private int lvl;

    public Rigidbody2D rb;
    private Vector3 velocity = Vector3.zero;
    public AudioSource audio;


    // Ajoutez une référence au composant Sprite du joueur
    public SpriteRenderer playerSprite;
    // Ajoutez une référence au sprite que vous souhaitez utiliser
    public Sprite newSprite;

    // Ajoutez une référence au composant Animator du joueur
    public Animator playerAnimator;
    // Ajoutez une référence au nom de l'état d'animation associé au nouveau sprite
    public string newAnimationState;

    public Button play;
    public GameObject pause;

    private void Start()
    {
        lvl = 0;
        text.text = "Il vous faut vite trouver le levier pour ouvrir la porte.";
        if(konamiCode.konamiCodeComplete == true)
        {
            text.text += " Mais ... Mais... qui êtes vous ?";
            playerSprite.sprite = newSprite;
            // Changez l'animation du joueur en utilisant la référence au composant Animator et le nom de l'êtat d'animation
            playerAnimator.Play(newAnimationState);
            Debug.Log("Changement effectué");
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
            text.text = "Vous vous trouvez prés du levier. Tirer le en appuyant sur E";
            isInsideLevier = true;
        }
        if (collider.tag == "Porte")
        {
            text.text = "Vous voici prés de la levier. Ouvrez la avec E.";
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
            text.text = "Levier acctioné. Il vous faut ouvrir la porte sans vous faire attraper par le monstre.";
            levierHasBeenPool = true;
            LevierSprite.changerSprite();
        }

        if (isInsidePorte)
        {
            if(!levierHasBeenPool)
            {
                text.text = "Vous n'avez pas encore actionnée le levier.";
                return;
            } if (lvl == 0) {
                Debug.Log("Maze");
                SceneManager.LoadScene("GameMaze");
                lvl += 1;
            } else {
                SceneManager.LoadScene("Win");
            }
            audio.Play();
            Debug.Log("C'est gagner");
            
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
