using UnityEngine;

public class PlayerAnimation : MonoBehaviour {
    [SerializeField] protected Animator animator;
    private SpriteRenderer spriteRenderer;

    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void IsWalking(bool velocity) {
        spriteRenderer.flipX = velocity;
        animator.SetBool("IsWalking", true);
    }

    public void IsJumping() {
        animator.SetBool("IsJumping", true);
    }

    public void IsStanding() {
        animator.SetBool("IsJumping", false);
        animator.SetBool("IsWalking", false);
    }
}