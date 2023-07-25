using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projection1 : InteractableObject
{
    public static Projection1 instance;
    public Projection3 projection3;
    public GameObject necklace, shoes, face, cafeLogo, necklaceChain;
    public Side1Fragments Necklace, Shoes, SummerSunflower, NecklaceChain; 

    // Start is called before the first frame update
    void Start()
    {
        necklace.SetActive(false);
        cafeLogo.SetActive(false);
        instance = this;
    }

    public void SetNecklacePuzzleComplete()
    {
        necklace.SetActive(true); 
    }
    public void SetFacePuzzleComplete()
    {
        face.SetActive(true);
    }
    public void SetCafeLogoPuzzleComplete()
    {
        cafeLogo.SetActive(true);
    }

    private int collected;
    public bool collectedNecklace = false, collectedShoes = false, collectedSummerSunflower = false;

    public void CheckProjectionFragments()
    {
        collected = 0;
        if (collectedNecklace == true)
        {
            collected += 1;
        }
        if (collectedShoes == true)
        {
            collected += 1;
        }
        if (collectedSummerSunflower == true)
        {
            collected += 1;
        }
    }
    public bool isProjectionComplete = false;
    public void CheckProjectionCompletion()
    {
        if (collectedNecklace == true && collectedShoes == true && collectedSummerSunflower == true)
        {
            isProjectionComplete = true;
        }
    }
    public override void Interact()
    {
        if (InventoryManager.Instance.SearchFor(Necklace) == true)
        {
            collectedNecklace = true;
            InventoryManager.Instance.Remove(Necklace);
        }
        if (InventoryManager.Instance.SearchFor(Shoes) == true)
        {
            collectedShoes = true;
            InventoryManager.Instance.Remove(Shoes);
        }
        if (InventoryManager.Instance.SearchFor(SummerSunflower) == true)
        {
            collectedSummerSunflower = true;
            InventoryManager.Instance.Remove(SummerSunflower);
        }

        CheckProjectionFragments();
        CheckProjectionCompletion();

        if (isProjectionComplete == true && projection3.isProjectionComplete == true)
        {
            //need to add change scene to end demo. for now debug.log only
            Debug.Log("Demo complete!");
        }
    }
}