using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class PlayerDataLocalProvider : IDataProvider
{
    private const string FileName = "PlayerSave";
    private const string SaveFileExtension = ".json";

    private IPersistentData _persistentData;

    public PlayerDataLocalProvider (IPersistentData persistentData)
    {
        _persistentData = persistentData;
    }

    private string SavePath => Application.persistentDataPath;
    private string FullPath => Path.Combine (SavePath, $"{FileName}{SaveFileExtension}");

    public void Save()
    {
        File.WriteAllText(FullPath,JsonConvert.SerializeObject(_persistentData.PlayerData,Formatting.Indented, new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        }));

        
    }

    public bool TryLoad()
    {
        if(IsDataAlreadyExist() == false)
        {
            return false;
        }

        _persistentData.PlayerData = JsonConvert.DeserializeObject<PlayerData>(File.ReadAllText(FullPath));
        return true;
    }

    private bool IsDataAlreadyExist() => File.Exists(FullPath);
}