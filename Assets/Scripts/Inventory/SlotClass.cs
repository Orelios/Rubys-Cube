using System.Collections;
using UnityEngine;

[System.Serializable]
public class SlotClass 
{
    [SerializeField] private ItemClass item;

    public SlotClass()
    {
        item = null;
    }
    public SlotClass(ItemClass _item)
    {
        item = _item;
    }

    public ItemClass GetItem() { return item; }
}
