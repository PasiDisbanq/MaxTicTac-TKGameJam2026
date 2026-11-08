using System.Collections;
using UnityEngine;

public class AdvanceScene : MonoBehaviour {
    [SerializeField] private int currentStageBeaten;
    private bool active = true;
    private void OnTriggerEnter2D(Collider2D collision) {
        if (active) {
            active = false;
            SceneLoader.Instance.isFading = true;
            var c = WaitForSeconds(SceneLoader.Instance.FadeOutDuration);
            StartCoroutine(c);
        }
    }

    private IEnumerator WaitForSeconds(float seconds) {
        yield return new WaitForSeconds(seconds);
        SceneLoader.Instance.UpdatenextDialogueIndexr(currentStageBeaten);
    }
}
