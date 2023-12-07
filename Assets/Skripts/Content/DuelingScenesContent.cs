using System;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "DuelingScenesContent", menuName = "MainMenu/DuelingScenesContent")]
public class DuelingScenesContent : AbstractContent<ConcreteScene>
{
    private void OnValidate()
    {
        var swordSkinDuplicates = _objects.GroupBy(item => item.Name)
            .Where(array => array.Count() > 1);

        if (swordSkinDuplicates.Count() > 0)
        {
            throw new InvalidOperationException(nameof(_objects));
        }
    }
}