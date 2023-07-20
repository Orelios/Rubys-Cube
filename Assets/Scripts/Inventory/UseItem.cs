using System.Collections;

using UnityEngine;

public class UseItem : MonoBehaviour
{
    public InventoryManager inventory;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if(inventory.selectedItem != null)
                inventory.selectedItem.UseItem(this); 
        }
    }
}
