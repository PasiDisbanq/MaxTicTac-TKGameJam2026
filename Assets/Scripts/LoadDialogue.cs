using UnityEngine;

public class LoadDialogue : MonoBehaviour {
    [SerializeField] SO_Dialogues dialogue;
    [SerializeField] DialogueSystem dialogueSystemScript;
    private void Awake() {
        dialogue = SceneLoader.Instance.GetDialogue();
        dialogueSystemScript.dialogues = dialogue;
    }
}
