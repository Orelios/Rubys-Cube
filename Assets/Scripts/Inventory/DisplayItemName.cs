using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class DisplayItemName : MonoBehaviour
{
    public InventoryManager inventoryManager; 
    [SerializeField] TextMeshProUGUI displayItemName; 
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        inventoryManager.SelectedItemName();
        displayItemName.text = inventoryManager.itemName;
    }
}
