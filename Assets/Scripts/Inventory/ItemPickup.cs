using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : InteractableObject
{
    public ItemClass itemClass;
    public override void Interact()
    {
        InventoryManager.Instance.Add(itemClass);
        Destroy(gameObject);
    }
}
