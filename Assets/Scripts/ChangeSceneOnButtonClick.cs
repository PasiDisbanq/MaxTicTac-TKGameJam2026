using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeSceneOnButtonClick : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private string sceneName;

    private void Start()
    {
       button.onClick.AddListener(() => SceneManager.LoadScene(sceneName)); 
    }
}