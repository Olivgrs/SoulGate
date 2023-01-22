using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;
using UnityEngine.SceneManagement;

public class konamiCode : MonoBehaviour
{
    /*public PlayerMovement player;
    public Sprite newSprite;*/
    public static bool konamiCodeComplete = false;

    private InputAction konamiInput;
    private int[] KonamiCode = { 38, 38, 40, 40, 37, 39, 37, 39, 66, 65 }; // Code Konami : ↑ ↑ ↓ ↓ ← → ← → B A
    private int currentIndex = 0;

    private void Start()
    {

        konamiInput = new InputAction(name: "KonamiCode", binding: "<Keyboard>/upArrow, <Keyboard>/downArrow, <Keyboard>/leftArrow, <Keyboard>/rightArrow, <Keyboard>/b, <Keyboard>/a");
        konamiInput.Enable();
    }

    private void HandleKonamiCode(int key)
    {
        if (KonamiCode[currentIndex] == key)
        {
            currentIndex++;
            if (currentIndex == 10)
            {
                Debug.Log("Code Konami entré ! Voici votre message secret : \"Ce n'est qu'un début\" ");
                konamiCodeComplete = true;
                SceneManager.LoadScene("Game");
                /*SpriteRenderer sr = player.GetComponent<SpriteRenderer>();
                sr.sprite = newSprite;*/
                currentIndex = 0;

                konamiInput.performed -= ctx => HandleKonamiCode(ctx.ReadValue<Vector2Int>().x);
                konamiInput.Disable();
            }
        }
        else
        {
            currentIndex = 0;
        }
    }

    public void OnArrowUP(InputValue val)
    {
        HandleKonamiCode(38);
    }
    
    public void OnArrowDOWN(InputValue val)
    {
        HandleKonamiCode(40);
    }

    public void OnArrowLEFT(InputValue val)
    {
        HandleKonamiCode(37);
    }

    public void OnArrowRIGHT(InputValue val)
    {
        HandleKonamiCode(39);
    }

    public void OnBKey(InputValue val)
    {
        HandleKonamiCode(66);
    }

    public void OnAKey(InputValue val)
    {
        HandleKonamiCode(65);
    }
}