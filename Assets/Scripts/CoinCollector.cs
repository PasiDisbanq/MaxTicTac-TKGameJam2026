using System;
using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    
    public int Points => points;
    public bool CollectedFake => collectedFake;

    public event Action OnCollect;
    
    private int points = 0;
    private bool collectedFake = false;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            other.gameObject.GetComponent<Coin>().Collect();
            points++;
            audioSource.Play();
            OnCollect?.Invoke();
        }
        else if (other.gameObject.CompareTag("FakeCoin"))
            collectedFake = true;
    }
}
