using System.Collections;
using UnityEngine;

public sealed class Coroutines : MonoBehaviour
{
    private static Coroutines _instance
    {
        get
        {
            if (m_instance == null)
            {
                var obj = new GameObject("CoroutinesManager");
                m_instance = obj.AddComponent<Coroutines>();
            }

            return m_instance;
        }
    }

    private static Coroutines m_instance;

    public static Coroutine StartRoutine(IEnumerator enumerator)
    {
        return _instance.StartCoroutine(enumerator);
    }

    public static void StopRoutine(Coroutine routine)
    {
        _instance.StopCoroutine(routine);
    }
}
