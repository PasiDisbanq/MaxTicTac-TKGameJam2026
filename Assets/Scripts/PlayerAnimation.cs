using UnityEngine;

public class PlayerAnimation : MonoBehaviour {
    [SerializeField] protected Animator animator;
    private SpriteRenderer spriteRenderer;

    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void UpdateAnimation(bool isGrounded, Vector2 velocity, Vector2 input) {
        if (Mathf.Abs(velocity.x) > 0 && input.x != 0) {
            spriteRenderer.flipX = input.x > 0 ? false : true;
        }
        animator.SetBool("IsWalking", isGrounded && Mathf.Abs(velocity.x) > 0.1f);
        animator.SetBool("IsJumping", !isGrounded);
    }
}