using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    BosstMoss = 0,
    ImmunMoss
}

public abstract class Item
{

    public string itemName;
    public string itemDescription;
    public ItemType itemType;

    public abstract void UseItem();
}
