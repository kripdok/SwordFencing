using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;

public class EventBus
{
    private static EventBus _instance;
    private Dictionary<string, List<CallbackWithPriority>> _signalCallbacks = new Dictionary<string, List<CallbackWithPriority>>();

    public static EventBus Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new EventBus();
            }

            return _instance;
        }
    }

    private EventBus() { }

    public void Subscribe<ISignal>(Action<ISignal> callback, int priority = 0)
    {
        string key = typeof(ISignal).Name;

        if (_signalCallbacks.ContainsKey(key))
        {
            _signalCallbacks[key].Add(new CallbackWithPriority(priority, callback));
        }
        else
        {
            _signalCallbacks.Add(key, new List<CallbackWithPriority>() { new(priority, callback) });
        }

        _signalCallbacks[key] = _signalCallbacks[key].OrderByDescending(x => x.Priority).ToList();
    }

    public void Invoke<ISignal>(ISignal signal)
    {
        string key = typeof(ISignal).Name;

        if (_signalCallbacks.ContainsKey(key))
        {
            foreach (var obj in _signalCallbacks[key])
            {
                var callback = obj.Callback as Action<ISignal>;
                callback?.Invoke(signal);
            }
        }
    }

    public void UnSubscribe<ISignal>(Action<ISignal> callback)
    {
        string key = typeof(ISignal).Name;

        if (_signalCallbacks.ContainsKey(key))
        {
            var callbackToDelete = _signalCallbacks[key].FirstOrDefault(x => x.Callback.Equals(callback));
            if (callbackToDelete != null)
            {
                _signalCallbacks[key].Remove(callbackToDelete);
            }
        }
        else
        {
            Debug.LogErrorFormat("Trying to unsubscribe for not existing key! {0} ", key);
        }
    }
}