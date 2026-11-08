using UnityEngine;

public class PlayAudioInterchangeably : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip clip1;
    [SerializeField] private AudioClip clip2;

    private AudioClip currentClip;
    
    void Start()
    {
        currentClip = clip1;
    }
   

    public void PlayAudio()
    {
        audioSource.PlayOneShot(currentClip);
        currentClip = (currentClip == clip1) ? clip2 : clip1;
    }
}
