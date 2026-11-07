using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform BottomCheck;
    [SerializeField] private Vector3 RespawnPoint;
    [SerializeField] private LayerMask DeathLayer;
    [SerializeField] private bool isAlive;

    
    private void Die() {
       isAlive = false;
    }
    private void Respawn() {
        transform.position = RespawnPoint;
        isAlive = true;
    }
    bool CheckBottomCollision() {
        RaycastHit2D hit = Physics2D.Raycast(BottomCheck.position, Vector2.down, 0.1f, DeathLayer);
        return hit.collider != null;
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
        if (collision.CompareTag("Checkpoint")) {
            RespawnPoint = collision.transform.position;
            Destroy(collision.gameObject);
        }            
        
    }
}