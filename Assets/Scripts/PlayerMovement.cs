using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.UI.Image;

public class PlayerMovement : MonoBehaviour {
    [SerializeField] private float Speed;
    [SerializeField] private float JumpHeight;
    [SerializeField] private bool IsGrounded;
    private Transform GroundCheckTransform;
    [SerializeField] private LayerMask GroundLayer;
    private Rigidbody2D rb;
    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        GroundCheckTransform = transform.GetChild(0);
    }
    private bool IsGroundedCheck() {
        return Physics2D.Raycast(GroundCheckTransform.position, Vector2.down, 0.1f, GroundLayer);
    }
    private void HandleInput() {
        if (Keyboard.current.dKey.isPressed) {
            rb.linearVelocity = new Vector2(Speed, rb.linearVelocityY);
        }
        else if (Keyboard.current.aKey.isPressed) {
            rb.linearVelocity = new Vector2(-Speed, rb.linearVelocityY);
        }
        if (Keyboard.current.wKey.isPressed && IsGrounded) {
            rb.AddForce(Vector2.up * JumpHeight, ForceMode2D.Impulse);
        }
    }

    private void FixedUpdate() {
        IsGrounded = IsGroundedCheck();
        HandleInput();
    }

}
