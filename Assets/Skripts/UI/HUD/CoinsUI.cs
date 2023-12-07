using TMPro;
using UnityEngine;

public class CoinsUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _coins;

    public void DisplayCoins(int coins)
    {
        _coins.text = coins.ToString();
    }
}