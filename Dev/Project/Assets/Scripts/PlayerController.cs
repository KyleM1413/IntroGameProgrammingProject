using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D playerRigidBody;
    float _playerHorizMove = 0;
    float playerForce = 50;
    public float playerJumpForce = 1000;
    bool canJump = false;
    bool jumpQueued = false;
    bool sprinting = false;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();

    }
    void OnJump()
    {
        if(canJump)
        {
            jumpQueued = true;
            canJump = false;
        }

    }
    void OnReset()
    {
        Kill();
    }
    public void Kill()
    {
        transform.position = transform.parent.position;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            canJump = true;
    }
    void OnSprint(InputValue pressValue)
    {
        sprinting = pressValue.isPressed;
    }
    void OnMove(InputValue movementValue)
    {
        _playerHorizMove = movementValue.Get<Vector2>().x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float currentPlayerForce = sprinting ? playerForce * 1.5f : playerForce;
        playerRigidBody.AddForce(new Vector2(_playerHorizMove * currentPlayerForce, 0));
        if(jumpQueued)
        {
            jumpQueued = false;
            playerRigidBody.AddForce(new Vector2(0, playerJumpForce));
        }
    }
}
