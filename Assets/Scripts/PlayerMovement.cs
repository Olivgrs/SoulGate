using UnityEngine;
using System;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float horizontalMovement, verticalMovement;
    bool isInside = false;

    public bool isPause = false;

    public Rigidbody2D rb;
    private Vector3 velocity = Vector3.zero;

    public Button play;
    public GameObject pause;

    private void Start()
    {
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
        isInside = true;
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        isInside = false;
    }

    void MovePlayer(float _horizontalMovement, float _verticalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, _verticalMovement);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);
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
