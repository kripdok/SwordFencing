using System;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "SwordContent", menuName = "MainMenu/SwordContent")]
public class SwordContent : AbstractContent<SwordSkinItem>
{
    private void OnValidate()
    {
        var swordSkinDuplicates = _objects.GroupBy(item => item.SkinType)
            .Where(array => array.Count() > 1);

        if(swordSkinDuplicates.Count() > 0)
        {
            throw new InvalidOperationException(nameof(_objects));
        }
    }
}
