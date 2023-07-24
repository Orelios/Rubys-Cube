using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projection1 : InteractableObject
{
    public static Projection1 instance; 
    public GameObject necklace, shoes, face, cafeLogo, necklaceChain;
    public Side1Fragments Necklace, Shoes, NecklaceChain;
    private int collected;
    public bool collectedNecklace = false, collectedShoes = false, collectedSummerSunflower = false;
    // Start is called before the first frame update

    public void Awake()
    {
        instance = this; 
    }
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
        //InventoryManager.Instance.Search(SummerSunflower, collectedSummerSunflower);
        CheckProjectionFragments();
        CheckProjectionCompletion(); 
    }
}