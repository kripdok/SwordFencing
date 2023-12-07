using Newtonsoft.Json;
using System;
using System.Collections.Generic;

public class SettingsData
{
    private Dictionary<MixerName, bool> _mixersIsWork;

    public IDictionary<MixerName, bool> MixersIsWork => _mixersIsWork;

    public SettingsData() 
    {
        _mixersIsWork = new Dictionary<MixerName, bool>() {
            { MixerName.Effects, true},
            { MixerName.Music, true}
        };
    }

    [JsonConstructor]
    public SettingsData(Dictionary<MixerName, bool> mixersIsWork)
    {
        _mixersIsWork = mixersIsWork;
    }

    public void SetMixerIsWork(MixerName mixerName, bool isWork)
    {
        if(_mixersIsWork.ContainsKey(mixerName) == false)
        {
            new ArgumentException($"{mixerName} not registered in the software");
        }

        _mixersIsWork[mixerName] = isWork;
    }

    public bool GetMixerIsWork(MixerName mixerName)
    {
        if (_mixersIsWork.ContainsKey(mixerName) == false)
        {
            new ArgumentException($"{mixerName} not registered in the software");
        }

        return _mixersIsWork[mixerName];
    }
}
