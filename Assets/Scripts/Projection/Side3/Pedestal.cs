using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedestal : InteractableObject
{
    public Projection3 projection;
    public ItemClass puzzleItem;
    private bool itemFound = false;
    public Pedestal otherPedestal1, otherPedestal2;
    public int sequence = 0;
    [SerializeField] private int correctSequence;
    public bool itemPlaced = false;
    public bool isSequenceCorrect = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual int CheckItemPlaced()
    {
        if(itemPlaced == true)
        {
            return (1);
        }
        else
        {
            return (0);
        }
    }

    public void CheckSequence()
    {
        if(sequence == correctSequence)
        {
            isSequenceCorrect = true;
        }
    }

    public void CheckAttempt()
    {
        if(itemPlaced == true && otherPedestal1.itemPlaced == true && otherPedestal2.itemPlaced == true)
        {
            if(isSequenceCorrect == true && otherPedestal1.isSequenceCorrect == true && otherPedestal2.isSequenceCorrect == true)
            {
                projection.SetPuzzleComplete();
            }
            else
            {
                Debug.Log("Incorrect sequence");
            }
        }
    }

    public override void Interact()
    {
        InventoryManager.Instance.SearchFor(puzzleItem, itemFound);
        if(itemFound == true)
        {
            InventoryManager.Instance.Remove(puzzleItem);
            sequence = 1 + otherPedestal1.CheckItemPlaced() + otherPedestal2.CheckItemPlaced();
            CheckSequence();
            CheckAttempt();
        }
    }
}
