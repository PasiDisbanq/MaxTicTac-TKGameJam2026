using UnityEngine;

public class PlayAudioInRandomIntervals : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] audioClips;
    [SerializeField] private float minInterval = 1f;
    [SerializeField] private float maxInterval = 2f;
    [SerializeField] private bool disableRepeating = false;

    private float currentTime = 0f;
    private int lastIndex = -1;

    void Update()
    {
        currentTime -= Time.deltaTime;
        if (currentTime > 0) return;

        int clipIndex = GetRandomIndex();
        while (disableRepeating && clipIndex == lastIndex)
            clipIndex = GetRandomIndex();
        audioSource.PlayOneShot(audioClips[clipIndex]);
        lastIndex = clipIndex;

        currentTime = Random.Range(minInterval, maxInterval);
    }

    private int GetRandomIndex() => Random.Range(0, audioClips.Length);
}
