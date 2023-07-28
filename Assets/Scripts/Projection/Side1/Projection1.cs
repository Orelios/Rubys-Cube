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

    public Material[] material;
    public Material lambert85;
    public int ProjectionCombo;
    Renderer rend;

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

        ProjectionCombo = 0;
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = lambert85;
    }

    void Update()
    {
        rend.sharedMaterial = material[ProjectionCombo];
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
        ChangeProjectionCombo();
        fragmentCounterText.text = collectedFragments + "/" + fragmentMaxCount;
    }

    public void ChangeProjectionCombo()
    {
        if (collectedNecklace == true)
        {
            ProjectionCombo = 1;
        }
        if (collectedSummerSunflower == true)
        {
            ProjectionCombo = 2;
        }
        if (collectedShoes == true)
        {
            ProjectionCombo = 3;
        }
        if (collectedNecklace == true && collectedSummerSunflower == true)
        {
            ProjectionCombo = 4;
        }
        if (collectedShoes == true && collectedSummerSunflower == true)
        {
            ProjectionCombo = 5;
        }
        if (collectedNecklace == true && collectedShoes == true)
        {
            ProjectionCombo = 6;
        }
        if (collectedNecklace == true && collectedShoes == true && collectedSummerSunflower == true)
        {
            ProjectionCombo = 7;
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
            screenManager.LoadEndScreen();

        }
    }
}