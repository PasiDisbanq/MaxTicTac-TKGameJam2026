using TMPro;
using UnityEngine;

public class LevelsUI : MonoBehaviour {
    [SerializeField] CoinCollector coinCollectorScript;
    [SerializeField] TextMeshProUGUI gold;
    [SerializeField] TextMeshProUGUI time;

    private void Start() {
        coinCollectorScript.OnCollect += UpdateGold;
        time.text = "0";
        gold.text = "0";
    }
    private float timer;

    private void Update() {
        timer += Time.deltaTime;
        time.text = $"{Mathf.Round(timer * 100) / 100.00}s";
    }

    void UpdateGold() {
        gold.text = $"{coinCollectorScript.Points} gold";
    }
}
