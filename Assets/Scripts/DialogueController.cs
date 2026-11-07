using System;
using UnityEngine;
using DG.Tweening;
using UnityEngine.InputSystem;

public class DialogueController : MonoBehaviour
{
    [SerializeField] private RectTransform dialogueContainer;
    [SerializeField] private DialogueInstance[] dialogueBoxes;

    [SerializeField] private float dialogueAppearDuration = 1f;
    [SerializeField] private float containerMoveDuration = 1f;
    [SerializeField] private float verticalPadding = 10f;

    private int currentIndex = 0;
    private float totalOffset = 0f;

    private void InstantiateNextDialogue()
    {
        var dialogue = Instantiate(dialogueBoxes[currentIndex].prefab, dialogueContainer);
        totalOffset += dialogue.sizeDelta.y + verticalPadding;
        
        float newPositionX = (dialogueBoxes[currentIndex].owner == Owner.Player) ? 1200 : -1200;
        dialogue.localPosition = new Vector2(newPositionX, -totalOffset);

        PlayDialogueAnimationSequence(dialogue);
        currentIndex++;
    }

    private void PlayDialogueAnimationSequence(RectTransform dialogue)
    {
        var seq = DOTween.Sequence();
        seq.Append(dialogueContainer.DOMoveY(dialogueContainer.position.y + dialogue.sizeDelta.y, containerMoveDuration));
        seq.Append(dialogue.DOLocalMoveX(0, dialogueAppearDuration));
        seq.Play();
    }
   
    private void Update()
    {
        if(Keyboard.current.spaceKey.wasPressedThisFrame)
            InstantiateNextDialogue();
    }
}