using UnityEngine;

public class CheckPointController : MonoBehaviour {
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer renderer;
    [SerializeField] private Sprite ActiveCP;
    public void TurnOnCheckPoint() {
        animator.enabled = false;
        renderer.sprite = ActiveCP;
    }

}
