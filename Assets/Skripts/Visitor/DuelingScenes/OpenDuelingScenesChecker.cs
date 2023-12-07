using System.Linq;

public class OpenDuelingScenesChecker : IDuelingScenesVisitor
{
    private IPersistentData _persistentData;

    public bool IsOpened { get; private set; }

    public OpenDuelingScenesChecker(in IPersistentData persistentData) => _persistentData = persistentData;

    public void Visit(ConcreteScene sceneName)
    {
        IsOpened = _persistentData.PlayerData.OpenLevels.Contains(sceneName.Name);
    }
}