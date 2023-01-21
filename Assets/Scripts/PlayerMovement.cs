using UnityEngine;
using System;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    float horizontalMovement, verticalMovement;
    bool isInside = false;

    public Rigidbody2D rb;
    private Vector3 velocity = Vector3.zero;

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

    public void OnDeverouillerPorte(InputValue val)
    {
        if(isInside == true)
        {
            Debug.Log("Collision détectée et touche E pressée");
        }
    }
}
