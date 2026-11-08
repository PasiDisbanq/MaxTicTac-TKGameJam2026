using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip clip1;
    [SerializeField] private AudioClip clip2;

    private AudioClip currentClip;
    
    void Start()
    {
        currentClip = clip1;
    }
   

    public void Play()
    {
        audioSource.PlayOneShot(currentClip);
        currentClip = (currentClip == clip1) ? clip2 : clip1;
    }
}
