using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour {
    
    [SerializeField] private float Speed;
    [SerializeField] private float AccelerationRate;
    [SerializeField] private float MaxJumpHeight;
    [SerializeField] private bool hasDoneImpact = false;
    [SerializeField] private float JumpSpeed;
    private float startPos;
    [SerializeField] private bool IsGrounded;
    [SerializeField] private float bufor = 0.3f;
    [SerializeField] private float currentTime;
    [SerializeField] private bool isHeadButted;
    [SerializeField] private bool ShouldJump = false;
    [SerializeField] private bool ShouldInitiateJump = false;
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
        RaycastHit2D ray = Physics2D.CapsuleCast(GroundCheckTransform.position, new Vector2(0.50f, 0.5f), CapsuleDirection2D.Horizontal, 0f, Vector2.down, 0.1f, GroundLayer);
        if (ray.collider == null) {
            currentTime += Time.deltaTime;
        }
        else {
            currentTime = 0;
            rb.linearVelocityY = -5f;
            hasDoneImpact = false;
            ShouldJump = false;
        }
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
        if (Keyboard.current.wKey.wasPressedThisFrame && (IsGrounded || currentTime <= bufor)) {
            ShouldInitiateJump = true;
            Debug.Log(1);
            startPos = transform.position.y;
        }
        if (Keyboard.current.wKey.wasReleasedThisFrame && rb.linearVelocityY > 0) {
            Debug.Log(2);
            ShouldJump = false;
            ShouldInitiateJump = false;
            hasDoneImpact = false;
            rb.linearVelocityY = 0f;
        }

        if (isHeadButted) {
            ShouldJump = false;
            ShouldInitiateJump = false;
        }
        playerAnimScript.UpdateAnimation(IsGrounded, rb.linearVelocity, moveInput);
    }

    private void TryJump() {
        if ((IsGrounded || currentTime <= bufor) && hasDoneImpact == false && ShouldInitiateJump) {
            hasDoneImpact = true;
            ShouldInitiateJump = false;
            ShouldJump = true;
            Debug.Log("DONE IMPACT");
            rb.linearVelocityY = 0;
            rb.AddForce(Vector2.up * (JumpSpeed / 3), ForceMode2D.Impulse);
        }
        if (ShouldJump && (transform.position.y > (MaxJumpHeight + startPos) && rb.linearVelocityY > 0)) {
            ShouldJump = false;
            ShouldInitiateJump = false;
            hasDoneImpact = false;
            rb.linearVelocityY = 0f;
            Debug.Log("Stop");
            return;
        }
        
        if (ShouldJump && ShouldInitiateJump == false) {
            Debug.Log("Add force");
            rb.AddForce(Vector2.up * JumpSpeed);
        }
    }

    private void FixedUpdate() {
        float targetSpeed = moveInput.x * Speed;
        float newSpeed = Mathf.MoveTowards(rb.linearVelocityX, targetSpeed, AccelerationRate * Time.fixedDeltaTime);
        rb.linearVelocityX = newSpeed;

        TryJump();
    }

}
