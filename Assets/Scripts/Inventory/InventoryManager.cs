using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    public GameObject slotHolder;
    public GameObject[] slots;

    [SerializeField] private GameObject selector; 
    [SerializeField] private int selectedSlotNum = 0;
    public ItemClass selectedItem;


    public List<SlotClass> items = new List<SlotClass>();

    public void Awake()
    {
        Instance = this; 
    }

    public void Start()
    {
        slots = new GameObject[slotHolder.transform.childCount];
        for (int i = 0; i < slotHolder.transform.childCount; i++)
        {
            slots[i] = slotHolder.transform.GetChild(i).gameObject;
        }

        RefreshUI();
    }

    private void Update()
    {
        int i = selectedSlotNum; 
        if(Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            selectedSlotNum = Mathf.Clamp(i + 1, 0, slots.Length -1);
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            selectedSlotNum = Mathf.Clamp(i - 1, 0, slots.Length -1);
        }
        selector.transform.position = slots[selectedSlotNum].transform.position;
        try
        {
            selectedItem = items[i].GetItem();
        }
        catch
        {
            selectedItem = null;
        }
    }

    public void RefreshUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            try
            {
                slots[i].transform.GetChild(0).GetComponent<Image>().enabled = true;
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = items[i].GetItem().itemIcon;
            }
            catch
            {
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = null;
                slots[i].transform.GetChild(0).GetComponent<Image>().enabled = false;
            }
            
        }
    }

    public void Add(ItemClass item)
    {
        //items.Add(item);
        items.Add(new SlotClass(item));
        RefreshUI();
    }

    public void Remove(ItemClass item)
    {
        SlotClass slotRemove = new SlotClass();
        foreach (SlotClass slot in items)
        {
            if(slot.GetItem() == item)
            {
                slotRemove = slot;
                break;
            }
        }

        items.Remove(slotRemove);
        RefreshUI();
    }
    public void Search(ItemClass item, bool fragment)
    {
        SlotClass slotRemove = new SlotClass();
        foreach (SlotClass slot in items)
        {
            if (slot.GetItem() == item)
            {
                slotRemove = slot;
                fragment = true;
                break;
            }
        }

        items.Remove(slotRemove);
        RefreshUI();
    }
    public bool SearchFor(ItemClass item)
    {
        foreach (SlotClass slot in items)
        {
            if (slot.GetItem() == item)
            {
                //itemFound = true;
                //Debug.Log("Item Found");
                //break;
                return true;
            }
        }
        return false;
    }
}
