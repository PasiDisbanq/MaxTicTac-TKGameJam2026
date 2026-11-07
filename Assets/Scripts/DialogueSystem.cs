using System;
using System.Collections;
using UnityEngine;
using DG.Tweening;
using UnityEngine.InputSystem;

public class DialogueSystem : MonoBehaviour
{
    [SerializeField] private RectTransform dialogueContainer;
    [SerializeField] private DialogueInstance[] dialogues;

    [SerializeField] private float dialogueAppearDuration = 1f;
    [SerializeField] private float containerMoveDuration = 1f;
    [SerializeField] private float verticalPadding = 10f;
    [SerializeField] private float dialogueAppearDelay = 1f;
    
    public Owner NextOwner => dialogues[currentIndex].Owner;
    public string NextText => dialogues[currentIndex].Content;
    public float DialogueAppearDelay => dialogueAppearDelay;

    private int currentIndex = 0;
    private float totalOffset = 0f;

    public IEnumerator InstantiateNextDialogue()
    {
        Dialogue d = Instantiate(dialogues[currentIndex].Prefab, dialogueContainer.transform);

        yield return null;
        
        d.Setup(dialogues[currentIndex].Content);
        
        float newPositionX = (dialogues[currentIndex].Owner == Owner.Player) ? 1200 : -1200;
        d.Rt.localPosition = new Vector2(newPositionX, -totalOffset);

        d.Rt.DOLocalMoveX(0, dialogueAppearDuration);
        // PlayDialogueAnimationSequence(d.Rt);
        currentIndex++;
    }

}