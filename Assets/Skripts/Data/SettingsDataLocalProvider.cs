using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using UnityEngine;

public class SettingsDataLocalProvider : IDataProvider
{
    private const string FileName = "Settings";
    private const string SaveFileExtension = ".json";

    private IPersistentData _persistentData;

    public SettingsDataLocalProvider(IPersistentData persistentData)
    {
        _persistentData = persistentData;
    }

    private string SavePath => Application.persistentDataPath;
    private string FullPath => Path.Combine(SavePath, $"{FileName}{SaveFileExtension}");

    public void Save()
    {
        var settings = new JsonSerializerSettings
        {
            Converters = new List<JsonConverter> { new StringEnumConverter() },
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        };

        string json = JsonConvert.SerializeObject(_persistentData.SettingsData);

        File.WriteAllText(FullPath, json);
    }

    public bool TryLoad()
    {
        if (IsDataAlreadyExist() == false)
        {
            return false;
        }

        _persistentData.SettingsData = JsonConvert.DeserializeObject<SettingsData>(File.ReadAllText(FullPath));
        return true;
    }

    private bool IsDataAlreadyExist() => File.Exists(FullPath);
}