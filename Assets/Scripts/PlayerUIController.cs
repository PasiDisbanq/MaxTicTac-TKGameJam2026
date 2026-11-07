using TMPro;
using UnityEngine;

public class PlayerUIController : MonoBehaviour
{
    [SerializeField] private CoinCollector cc;
    [SerializeField] private TextMeshProUGUI coinTMP;

    private void Start()
    {
        cc.OnCollect += UpdateCoinPoints;
    }

    private void UpdateCoinPoints()
    {
        coinTMP.text = cc.Points.ToString();
    }
}
