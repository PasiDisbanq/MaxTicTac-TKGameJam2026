using UnityEngine;

public class PlaySingleAudio : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip clip;
    
   public void PlayClip()
    {
        audioSource.PlayOneShot(clip);
    }
}
