using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : Interactable
{
    public ItemClass itemClass; 
    public override void Interact()
    {
        InventoryManager.Instance.Add(itemClass);
        Destroy(gameObject);
    }
}
