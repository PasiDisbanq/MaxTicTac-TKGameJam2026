using UnityEngine;
using UnityEngine.UI;

public class BlinkingCursor : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private float delay = 1f;

    private Color startColor;
    private float currentDelay = 0f;
    private bool isEnabled = false;

    public void Toggle(bool set)
    {
        isEnabled = set;
        if (!set) image.color = Color.clear;
    }
    
    void Start()
    {
        startColor = image.color;
        image.color = Color.clear;
    }

    void Update()
    {
        if (!isEnabled) return;
        
        currentDelay -= Time.deltaTime;
        if (currentDelay > 0) return;
        
        image.color = (image.color == startColor) ? Color.clear : startColor;
        currentDelay = delay;
    }
}
