using UnityEngine;

public class BlinkingBlocksController : MonoBehaviour
{
    [SerializeField] private GameObject blocks;
    [SerializeField] private GameObject inversedBlocks;
    [SerializeField] private float interval = 1f;

    private float currentTime = 0f;
    private bool inverted = false;

    void Update()
    {
        currentTime -= Time.deltaTime;
        if (currentTime > 0f) return;
        
        blocks.SetActive(!inverted);
        inversedBlocks.SetActive(inverted);
        
        currentTime = interval;
        inverted = !inverted;
    }
}
