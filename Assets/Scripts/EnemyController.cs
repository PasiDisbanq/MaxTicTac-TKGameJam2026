using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Transform left;
    [SerializeField] private Transform right;
    [SerializeField] private float moveSpeedMultiplier;
    [SerializeField] private EnemyAnimController animController;

    private int direction = 1;
    
    void Update()
    {
        direction = ((transform.position.x >= right.position.x) ? -1 : (transform.position.x <= left.position.x ? 1 : direction));
        transform.position += new Vector3(moveSpeedMultiplier * direction * Time.deltaTime, 0, 0);
        animController.HandleAnimation(direction);
    }
}
