using TMPro;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private RectTransform rt;
    [SerializeField] private RectTransform background;
    [SerializeField] private TextMeshProUGUI TMP;

    public RectTransform Rt => rt;
    public float Height => height; 
    
    private float height;

    public void Setup(string textInput)
    {
        height = background.rect.height;
        rt.sizeDelta = new Vector2(rt.sizeDelta.x, height);
        TMP.text = textInput;
    }
}
