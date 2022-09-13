using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ItemTypes
{
    WritingBrush,
    Brush,
    Knife
}

public class Item
{
    public ItemTypes ItemType { get; }
    public GameObject ItemObj { get; }
    public Sprite ItemIcon { get; }

    public Item(ItemTypes itemType, GameObject itemObj, Sprite itemIcon)
    {
        ItemType = itemType;
        ItemObj = itemObj;
        ItemIcon = itemIcon;
    }
}
