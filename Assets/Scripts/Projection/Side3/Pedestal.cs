using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedestal : InteractableObject
{
    public Projection3 projection;
    public ItemClass puzzleItem;
    public GameObject miniItem;
    public Pedestal otherPedestal1, otherPedestal2;
    public int sequence = 0;
    [SerializeField] private int correctSequence;
    public bool itemPlaced = false;
    public bool isSequenceCorrect = false;
    Vector3 miniFacePosition = new Vector3(3.58f, 2.88f, -9.0f);
    Quaternion miniFaceRotation = Quaternion.Euler(-90,0,0);
    Vector3 miniPondPosition = new Vector3(-3.413747f, 2.845497f, -8.995007f);
    Quaternion miniPondRotation = Quaternion.Euler(0, 180, 0);
    Vector3 miniBoulderPosition = new Vector3(0.131f, 3.107747f, -9.132f);
    Quaternion miniBoulderRotation = Quaternion.Euler(0, 180, 0);

    void Start()
    {
 
    }


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

    public void InstantiateMiniItem()
    {
        if (correctSequence == 1)
        {
            Instantiate(miniItem, miniFacePosition, miniFaceRotation);
        }
        else if (correctSequence == 2)
        {
            Instantiate(miniItem, miniPondPosition, miniPondRotation);
        }
        else if (correctSequence == 3)
        {
            Instantiate(miniItem, miniBoulderPosition, miniBoulderRotation);
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
                InstantiateMiniItem();
                itemPlaced = false;
                otherPedestal1.itemPlaced = false;
                otherPedestal2.itemPlaced = false;
                Debug.Log("Incorrect sequence");
            }
        }
    }

    public override void Interact()
    {
        if(InventoryManager.Instance.SearchFor(puzzleItem) == true)
        {
            Debug.Log("interacted");
            InventoryManager.Instance.Remove(puzzleItem);
            InstantiateMiniItem();
            itemPlaced = true;
            sequence = 0;
            sequence = 1 + otherPedestal1.CheckItemPlaced() + otherPedestal2.CheckItemPlaced();
            CheckSequence();
            CheckAttempt();
        }
    }
}
