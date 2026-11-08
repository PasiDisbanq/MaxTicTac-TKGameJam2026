using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour {
    [SerializeField] protected float currentTime = 0;
    [SerializeField] private RawImage ImageSprite;

    void Update() {
        if (!SceneLoader.Instance.isFading) {
            currentTime = 0;
        }
        currentTime += Time.deltaTime;
        ImageSprite.color = SceneLoader.Instance.SceneFadeOut(currentTime);
    }
}
