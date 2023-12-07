using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public abstract class GameOver : MonoBehaviour
{
    [SerializeField] protected ConcreteScene RestartScene;
    [SerializeField] protected GameOverSound Sound;

    protected MenuWindows MenuWindows;
    protected GameOverMenu GameOverMenu;

    public void Initialize(MenuWindows menuWindows)
    {
        MenuWindows = menuWindows;
        Sound.Initialize(GetComponent<AudioSource>());
    }

    public void OpenMenu()
    {
        GameOverMenu.gameObject.SetActive(true);
    }

    protected GameOverMenu InstantiateMenu(GameOverMenu menu)
    {
        var obj = Instantiate(menu, MenuWindows.transform);
        obj.Initialize(RestartScene);
        obj.gameObject.SetActive(false);
        return obj;
    }

    protected abstract void ReactToEnemyWin(PlayerLoseSignal signal);
}