using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {
    public static SceneLoader Instance { get; private set; }
    [SerializeField] private SO_Dialogues[] lista;

    public bool collected_fake_coin_stage1 = false;

    private void Awake() {
        if (Instance != null && Instance!=this) {
            Destroy(this);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(this);
    }
    int nextDialogueIndex = 0;

    public SO_Dialogues GetDialogue() {
        return lista[nextDialogueIndex];
    }
    public void UpdatenextDialogueIndexr(int beatenStage) {
        switch (beatenStage) {
            case 1:
                if (collected_fake_coin_stage1 == false) {
                    nextDialogueIndex = 2;
                    SceneManager.LoadScene("DialogueScene");
                    break;
                }
                nextDialogueIndex = 1;
                SceneManager.LoadScene("DialogueScene");
                break;
            case 2:
                break;
            case 3:
                break;
            default:
                break;
        }
    }
}
