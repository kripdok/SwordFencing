using UnityEngine;

[CreateAssetMenu(fileName = "SceneName", menuName = "SceneName/SceneName")]
public class ConcreteScene : ScriptableObject
{
    [field: SerializeField] public NameScenes Name { get; private set; }
}
