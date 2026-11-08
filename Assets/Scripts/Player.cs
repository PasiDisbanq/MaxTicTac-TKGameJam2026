using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform BottomCheck;
    [SerializeField] private Vector3 RespawnPoint;
    [SerializeField] private LayerMask DeathLayer;
    [SerializeField] private bool isAlive;
    [SerializeField] private PlaySingleAudio playDeathSound;

    
    private void Die() {
       isAlive = false;
       playDeathSound.PlayClip();
    }
    private void Respawn() {
        transform.position = RespawnPoint;
        isAlive = true;
    }
    bool CheckBottomCollision() {
        Collider2D hit = Physics2D.OverlapBox(new Vector2(transform.position.x, transform.position.y-0.03f), new Vector2(0.9f, 1.91f), 0f, DeathLayer);
        return hit != null;
    }


    private void Start() {
        isAlive = true;
        RespawnPoint = transform.position;
    }

    private void Update() {
        if (!isAlive) {
            Respawn();
        }
        if (CheckBottomCollision()) {
            Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Enemy")) {
            Die();
        }
        if (collision.CompareTag("Checkpoint")) {
            RespawnPoint = collision.transform.position;
            collision.GetComponent<CheckPointController>().TurnOnCheckPoint();
        }
    }
}