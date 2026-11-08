using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour {
    
    [SerializeField] private float Speed;
    [SerializeField] private float AccelerationRate;
    [SerializeField] private float MaxJumpHeight;
    [SerializeField] private bool hasDoneImpact = false;
    [SerializeField] private float JumpSpeed;
    private float startPos;
    [SerializeField] private bool isGrounded;
    [SerializeField] private float bufor = 0.3f;
    [SerializeField] private float currentTime;
    [SerializeField] private bool isHeadButted;
    [SerializeField] private bool isStickyButted;
    [SerializeField] private bool ShouldJump = false;
    [SerializeField] private bool ShouldInitiateJump = false;
    [SerializeField] private Transform GroundCheckTransform;
    [SerializeField] private Transform HeadCheckTransform;
    [SerializeField] private LayerMask GroundLayer;
    [SerializeField] private LayerMask StickyLayer;
    private Rigidbody2D rb;
    [SerializeField] private Vector2 moveInput;
    private PlayerAnimation playerAnimScript;

    public bool IsGrounded => isGrounded;
    public Vector2 Velocity => rb.linearVelocity;
    
    
    
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
        Collider2D hit = Physics2D.OverlapBox(HeadCheckTransform.position, new Vector2(0.69f, 0.65f), 0, GroundLayer);
        return hit != null;
    }
    private bool StickyButted() {
        Collider2D hit = Physics2D.OverlapBox(HeadCheckTransform.position, new Vector2(0.69f, 0.65f), 0, StickyLayer);
        return hit != null;
    }

    private void Update() {
        isGrounded = IsGroundedCheck();
        isHeadButted = HeadButted();
        isStickyButted = StickyButted();
        moveInput = Vector2.zero;

        if (Keyboard.current.dKey.isPressed) {
            moveInput = new Vector2(1, moveInput.y);
        }
        if (Keyboard.current.aKey.isPressed) {
            moveInput = new Vector2(-1, moveInput.y);
        }
        if (Keyboard.current.wKey.wasPressedThisFrame && (isGrounded || currentTime <= bufor)) {
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
        if (isStickyButted) {
            if (Keyboard.current.wKey.wasReleasedThisFrame) {
                ShouldJump = false;
            }
        }
        if (isHeadButted) {
            Debug.Log("butt");

            ShouldJump = false;
            ShouldInitiateJump = false;
        }
        playerAnimScript.UpdateAnimation(isGrounded, rb.linearVelocity, moveInput);
    }

    private void TryJump() {
        if ((isGrounded || currentTime <= bufor) && hasDoneImpact == false && ShouldInitiateJump) {
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
