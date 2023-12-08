using System.IO;
using UnityEngine;

public abstract class AbstractDataLocalProvider : IDataProvider
{
    protected IPersistentData PersistentData;
    private const string SaveFileExtension = ".json";

    protected abstract string FileName { get;}

    private string SavePath => Application.persistentDataPath;
    protected string FullPath => Path.Combine(SavePath, $"{FileName}{SaveFileExtension}");

    public abstract void Save();

    public abstract bool TryLoad();

    protected bool IsDataAlreadyExist() => File.Exists(FullPath);
}