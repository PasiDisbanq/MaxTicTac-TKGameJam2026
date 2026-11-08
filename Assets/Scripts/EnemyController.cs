using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Transform left;
    [SerializeField] private Transform right;
    [SerializeField] private float moveSpeedMultiplier;

    private int direction = 1;
    
    void Update()
    {
        if (transform.position.x >= right.position.x || transform.position.x <= left.position.x)
            direction *= -1;
        transform.position += new Vector3(moveSpeedMultiplier * direction * Time.deltaTime, 0, 0);
    }
}
