using UnityEngine;

public class BlinkingBlocksController : MonoBehaviour
{
    [SerializeField] private BlinkingBlockSerialization[] blocks;
    [SerializeField] private float interval = 1f;

    private float currentTime = 0f;
    private bool inverted = false;

    void Update()
    {
        currentTime -= Time.deltaTime;
        if (currentTime > 0f) return;
        
        foreach(var i in blocks)
            i.block.SetActive(i.inverted != inverted);
        currentTime = interval;
        inverted = !inverted;
    }
}
