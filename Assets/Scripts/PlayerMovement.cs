using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour {
    
    [SerializeField] private float Speed;
    [SerializeField] private float JumpHeight;
    [SerializeField] private bool IsGrounded;
    private Transform GroundCheckTransform;
    [SerializeField] private LayerMask GroundLayer;
    private Rigidbody2D rb;
    private PlayerAnimation playerAnimScript;
    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        GroundCheckTransform = transform.GetChild(0);
        playerAnimScript = GetComponent<PlayerAnimation>();
    }
    private bool IsGroundedCheck() {
        return Physics2D.Raycast(GroundCheckTransform.position, Vector2.down, 0.1f, GroundLayer);
    }
    private void HandleInput() {
        playerAnimScript.IsStanding();
        if (Keyboard.current.dKey.isPressed) {
            rb.linearVelocity = new Vector2(Speed, rb.linearVelocityY);
            playerAnimScript.IsWalking(rb.linearVelocityX < 0);
        }
        else if (Keyboard.current.aKey.isPressed) {
            rb.linearVelocity = new Vector2(-Speed, rb.linearVelocityY);
            playerAnimScript.IsWalking(rb.linearVelocityX < 0);
        }
        if (Keyboard.current.wKey.isPressed && IsGrounded) {
            rb.AddForce(Vector2.up * JumpHeight, ForceMode2D.Impulse);
            playerAnimScript.IsJumping();
        }
    }

    private void FixedUpdate() {
        IsGrounded = IsGroundedCheck();
        HandleInput();
    }

}
