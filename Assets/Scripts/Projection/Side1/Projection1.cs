using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Projection1 : InteractableObject
{
    public static Projection1 instance;
    public Projection3 projection3;
    public GameObject necklace, shoes, face, cafeLogo, necklaceChain;
    public Side1Fragments Necklace, Shoes, SummerSunflower, NecklaceChain;
    public ScreenManager screenManager;


    private int collectedFragments;
    public bool collectedNecklace = false, collectedShoes = false, collectedSummerSunflower = false;
    [SerializeField] private int fragmentMaxCount = 2;
    [SerializeField] private TextMeshProUGUI fragmentCounterText;

    // Start is called before the first frame update
    void Start()
    {
        necklace.SetActive(false);
        cafeLogo.SetActive(false);
        instance = this;
        fragmentCounterText.text = "0/" + fragmentMaxCount;
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
        collectedFragments = 0;
        if (collectedNecklace == true)
        {
            collectedFragments += 1;
        }
        if (collectedShoes == true)
        {
            collectedFragments += 1;
        }
        if (collectedSummerSunflower == true)
        {
            collectedFragments += 1;
        }

        fragmentCounterText.text = collectedFragments + "/" + fragmentMaxCount;
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
            screenManager.LoadEndScreen();

        }
    }
}