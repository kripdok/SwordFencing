using UnityEngine;

public class ExitGameButton : AbstractButton
{
    protected override void OnButtonClicked()
    {
        Application.Quit();
    }
}