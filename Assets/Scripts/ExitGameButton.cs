using UnityEngine;
using UnityEngine.UI;

public class ExitGameButton : MonoBehaviour
{
    [SerializeField] private Button button;
    
    void Start()
    {
        button.onClick.AddListener(() => Application.Quit());
    }
}
