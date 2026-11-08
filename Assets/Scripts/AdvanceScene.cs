using UnityEngine;

public class AdvanceScene : MonoBehaviour {
    [SerializeField] private int currentStageBeaten;
    private void OnTriggerEnter2D(Collider2D collision) {
        SceneLoader.Instance.UpdatenextDialogueIndexr(currentStageBeaten);
    }
}
