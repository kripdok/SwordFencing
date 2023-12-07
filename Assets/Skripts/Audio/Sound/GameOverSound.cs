using UnityEngine;

[CreateAssetMenu(fileName = "GameOverSound", menuName = "Sound/GameOverSound")]
public class GameOverSound : AbstractSound
{
    [SerializeField] private AudioClip _playerLose;
    [SerializeField] private AudioClip _playerWin;

    public void PlayWinClip()
    {
        PlaySound(_playerWin);
    }
    public void PlayLoseClip()
    {
        PlaySound(_playerLose);
    }
}
