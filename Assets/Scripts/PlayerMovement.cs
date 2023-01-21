using UnityEngine;
using System;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
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
        if(konamiCode.konamiCodeComplete == true)
        {
            playerSprite.sprite = newSprite;
            // Changez l'animation du joueur en utilisant la référence au composant Animator et le nom de l'état d'animation
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
        if(collider.tag == "Levier" )
            isInsideLevier = true;
        if (collider.tag == "Porte")
            isInsidePorte = true;
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

    public void DeverouillerPorte()
    {
        if(isInsideLevier && !levierHasBeenPool)
            levierHasBeenPool=true;

        if (isInsidePorte && levierHasBeenPool)
        {
            text.text = "victoire";
            text.enabled = true;
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
