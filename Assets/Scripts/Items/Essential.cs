using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Essential", menuName = "Inventory/Essential")]
public class Essential : Item
{
    public EssentialSlot essentialSlot;

    public override void Use()
    {
        EssentialsManager.instance.Apply(this);
        RemoveFromInventory();
    }
}

public enum EssentialSlot
{
    FieldDisruptor1,
    FieldDisruptor2,
    FieldDisruptor3,
    FieldDisruptor4,
}