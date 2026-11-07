using System.Collections;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    [SerializeField] private DialogueInputController inputController;
    [SerializeField] private DialogueSystem dialogueSystem;

    private bool disableUpdate = false;
    
    private void Start()
    {
        inputController.OnTypingFinish += ShowNextDialogue;
        inputController.OnTypingFinish += () => StartDelayCoroutine(dialogueSystem.DialogueAppearDelay);
    }

    private void ShowNextDialogue()
    {
        var a = dialogueSystem.InstantiateNextDialogue();
        StartCoroutine(a);
    }

    private void Update()
    {
        if (disableUpdate) return;
        
        disableUpdate = true;

        if (dialogueSystem.NextOwner == Owner.Player)
            inputController.Setup(dialogueSystem.NextText);
        else
        {
            ShowNextDialogue();
            StartDelayCoroutine(1);
        }
    }

    private void StartDelayCoroutine(float seconds)
    {
        var c = Delay(seconds);
        StartCoroutine(c);
    }

    IEnumerator Delay(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        disableUpdate = false;
    }

}
