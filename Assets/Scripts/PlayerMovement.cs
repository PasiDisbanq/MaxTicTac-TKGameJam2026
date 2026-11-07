using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour {
    
    [SerializeField] private float Speed;
    [SerializeField] private float AccelerationRate;
    [SerializeField] private float MaxJumpHeight;
    [SerializeField] private float JumpSpeed;
    private float startPos;
    [SerializeField] private bool IsGrounded;
    [SerializeField] private bool isHeadButted;
    [SerializeField] private bool ShouldJump;
    [SerializeField] private Transform GroundCheckTransform;
    [SerializeField] private Transform HeadCheckTransform;
    [SerializeField] private LayerMask GroundLayer;
    private Rigidbody2D rb;
    [SerializeField] private Vector2 moveInput;
    private PlayerAnimation playerAnimScript;
    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        playerAnimScript = GetComponent<PlayerAnimation>();
    }
    private bool IsGroundedCheck() { 
        RaycastHit2D ray = Physics2D.CapsuleCast(GroundCheckTransform.position, new Vector2(0.65f, 0.5f), CapsuleDirection2D.Horizontal, 0f, Vector2.down, 0.1f, GroundLayer);
        return ray.collider != null;
    }
    private bool HeadButted() {
        RaycastHit2D hit = Physics2D.CircleCast(HeadCheckTransform.position, 0.35f, Vector2.up, 0.1f, GroundLayer);
        return hit.collider != null;
    }

    private void Update() {
        IsGrounded = IsGroundedCheck();
        isHeadButted = HeadButted();
        moveInput = Vector2.zero;

        if (Keyboard.current.dKey.isPressed) {
            moveInput = new Vector2(1, moveInput.y);
        }
        if (Keyboard.current.aKey.isPressed) {
            moveInput = new Vector2(-1, moveInput.y);
        }
        if (Keyboard.current.wKey.wasPressedThisFrame && IsGrounded) {
            ShouldJump = true;
            startPos = transform.position.y;
        }
        if (Keyboard.current.wKey.wasReleasedThisFrame) {
            ShouldJump = false;
            rb.linearVelocityY = 0f;
        }

        if (isHeadButted) {
            ShouldJump = false;
        }
        playerAnimScript.UpdateAnimation(IsGrounded, rb.linearVelocity, moveInput);
    }

    private void TryJump() {
        if (IsGrounded && ShouldJump) {
            rb.AddForce(Vector2.up * (JumpSpeed/5), ForceMode2D.Impulse);
        }
        else if (ShouldJump) {
            rb.AddForce(Vector2.up * JumpSpeed);
        }
        if (transform.position.y > MaxJumpHeight + startPos && rb.linearVelocityY > 0) {
            ShouldJump = false;
            rb.linearVelocityY = 0f;
        }
        
    }

    private void FixedUpdate() {
        float targetSpeed = moveInput.x * Speed;
        float newSpeed = Mathf.MoveTowards(rb.linearVelocityX, targetSpeed, AccelerationRate * Time.fixedDeltaTime);
        rb.linearVelocityX = newSpeed;

        TryJump();
    }

}
