using TMPro;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private RectTransform rt;
    [SerializeField] private RectTransform background;
    [SerializeField] private TextMeshProUGUI TMP;

    public RectTransform Rt => rt;
    

    public void Setup(string textInput)
    {
        rt.sizeDelta = new Vector2(rt.sizeDelta.x, background.rect.height);
        TMP.text = textInput;
    }
}
