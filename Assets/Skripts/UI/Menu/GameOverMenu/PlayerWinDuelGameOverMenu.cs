using TMPro;
using UnityEngine;

public class PlayerWinDuelGameOverMenu : GameOverMenu
{
    [SerializeField] TMP_Text _numberOfCoinsWon;

    public void SetNumberOfCoinsWon(int coins)
    {
        _numberOfCoinsWon.text = coins.ToString();
    }
}
