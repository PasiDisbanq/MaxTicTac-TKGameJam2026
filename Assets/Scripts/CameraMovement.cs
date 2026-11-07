using UnityEngine;

public class CameraMovement : MonoBehaviour {
    [SerializeField ] Transform PlayerTransform;

    [SerializeField] private float Duration;
    private void Update() {
        transform.position = Vector3.Lerp(transform.position, new Vector3(PlayerTransform.position.x, PlayerTransform.position.y, -10), Time.deltaTime/Duration);
    }
}