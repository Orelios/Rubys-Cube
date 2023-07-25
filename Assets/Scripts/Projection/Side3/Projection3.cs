using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Projection3 : InteractableObject
{
    public Projection1 projection1;
    public bool isPuzzleComplete = false;
    public GameObject FamilyPhoto, Urn, SummerSunflower;
    public Side3Fragments photoFrame, familyPhoto, glassCover;
    public ScreenManager screenManager;

    public bool isProjectionComplete = false;
    public bool collectedPhotoFrame = false, collectedFamilyPhoto = false, collectedGlassCover = false;
    private int collectedFragments;
    [SerializeField] private int fragmentMaxCount = 3;
    [SerializeField] private TextMeshProUGUI fragmentCounterText;

    // Start is called before the first frame update
    void Start()
    {
        //PhotoFrame.SetActive(false);
        //GlassCover.SetActive(false);
        FamilyPhoto.SetActive(false);
        Urn.SetActive(false);
        SummerSunflower.SetActive(false);
        fragmentCounterText.text = "0/" + fragmentMaxCount;
    }

    public void SetPuzzleComplete()
    {
        isPuzzleComplete = true;
        if (isPuzzleComplete == true)
        {
            //PhotoFrame.SetActive(true);
            //GlassCover.SetActive(true);
            FamilyPhoto.SetActive(true);
            Urn.SetActive(true);
            SummerSunflower.SetActive(true);
        }
    }

    public void CheckProjectionFragments()
    {
        collectedFragments = 0;
        if (collectedPhotoFrame == true)
        {
            collectedFragments += 1;
        }
        if (collectedFamilyPhoto == true)
        {
            collectedFragments += 1;
        }
        if (collectedGlassCover == true)
        {
            collectedFragments += 1;
        }

        fragmentCounterText.text = collectedFragments + "/" + fragmentMaxCount;
    }

    public void CheckProjectionCompletion()
    {
        if (collectedPhotoFrame == true && collectedFamilyPhoto == true && collectedGlassCover == true)
        {
            isProjectionComplete = true;
        }
    }
    public override void Interact()
    {
        if (InventoryManager.Instance.SearchFor(photoFrame) == true)
        {
            collectedPhotoFrame = true;
            InventoryManager.Instance.Remove(photoFrame);
        }
        if (InventoryManager.Instance.SearchFor(familyPhoto) == true)
        {
            collectedFamilyPhoto = true;
            InventoryManager.Instance.Remove(familyPhoto);
        }
        if (InventoryManager.Instance.SearchFor(glassCover) == true)
        {
            collectedGlassCover = true;
            InventoryManager.Instance.Remove(glassCover);
        }

        CheckProjectionFragments();
        CheckProjectionCompletion();

        if(isProjectionComplete == true && projection1.isProjectionComplete == true)
        {
            //need to add change scene to end demo. for now debug.log only
            Debug.Log("Demo complete!");
            screenManager.LoadEndScreen();
        }
    }
}