using UnityEngine;

public class CheckPointController : MonoBehaviour {
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer renderer;
    [SerializeField] private Sprite ActiveCP;
    [SerializeField] private AudioSource audioSource;
    
    public void TurnOnCheckPoint() {
        animator.enabled = false;
        renderer.sprite = ActiveCP;
        audioSource.Stop();
    }

}
