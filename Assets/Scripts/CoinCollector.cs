using System;
using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    public int Points => points;

    public event Action OnCollect;
    
    private int points = 0;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Coin")) return;

        other.gameObject.GetComponent<Coin>().Collect();
        points++;
        OnCollect?.Invoke();
    }
}
