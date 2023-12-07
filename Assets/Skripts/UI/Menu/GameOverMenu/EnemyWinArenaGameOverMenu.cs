using TMPro;
using UnityEngine;

public class EnemyWinArenaGameOverMenu : GameOverMenu
{
    [SerializeField] TMP_Text _numberOfCoinsWon;
    [SerializeField] TMP_Text _numberOfEnemyDied;
    [SerializeField] private RestartButton _button;

    public override void Initialize(ConcreteScene scene)
    {
        _button.SetScene(scene);
    }

    public void SetNumberOfCoinsWon(int number)
    {
        _numberOfCoinsWon.text = number.ToString();
    }

    public void SetNumberEnemyDied( int number )
    {
        _numberOfEnemyDied.text = number.ToString();
    }
}