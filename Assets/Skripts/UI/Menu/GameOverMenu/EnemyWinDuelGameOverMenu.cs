using UnityEngine;

public class EnemyWinDuelGameOverMenu : GameOverMenu
{
    [SerializeField] private RestartButton _button;

    public override void Initialize(ConcreteScene scene)
    {
        _button.SetScene(scene);
    }
}