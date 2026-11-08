using UnityEngine;

public class EnemyAnimController : MonoBehaviour {
    [SerializeField] private SpriteRenderer SpriteRenderer;

    public void HandleAnimation(float dir) {
        if (dir > 0) {
            SpriteRenderer.flipX = true;
        }
        else {
            SpriteRenderer.flipX= false;
        }
    }
}
