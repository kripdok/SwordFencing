using System;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "PointerContent", menuName = "MainMenu/PointerContent")]
public class PointerContent : AbstractContent<PointerSkinItem>
{
    private void OnValidate()
    {
        var swordSkinDuplicates = _objects.GroupBy(item => item.SkinType)
            .Where(array => array.Count() > 1);

        if (swordSkinDuplicates.Count() > 0)
        {
            throw new InvalidOperationException(nameof(_objects));
        }
    }
}
