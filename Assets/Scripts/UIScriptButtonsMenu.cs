using UnityEngine;

public class UIScriptButtonsMenu : MonoBehaviour {
    [SerializeField] private GameObject CreditsGO;
    public void Credits() {
        CreditsGO.SetActive(!CreditsGO.activeSelf);
    }

    public void Exit() {
        Application.Quit();
    }
}
