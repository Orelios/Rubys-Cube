using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projection1 : InteractableObject
{
    public GameObject necklace, shoes, face, cafeLogo;
    public Side1Fragments Necklace, Shoes, SummerSunflower; 
    // Start is called before the first frame update
    void Start()
    {
        necklace.SetActive(false);
        cafeLogo.SetActive(false);
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
        InventoryManager.Instance.Search(Necklace, collectedShoes);
        InventoryManager.Instance.Search(Shoes, collectedNecklace);
        InventoryManager.Instance.Search(SummerSunflower, collectedSummerSunflower);
        CheckProjectionFragments();
        CheckProjectionCompletion(); 
    }
}