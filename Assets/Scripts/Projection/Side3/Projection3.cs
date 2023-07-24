using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projection3 : InteractableObject
{
    public bool isPuzzleComplete = false;
    public GameObject FamilyPhoto, Urn, SummerSunflower;
    public Side3Fragments photoFrame, familyPhoto, glassCover; 
    // Start is called before the first frame update
    void Start()
    {
        //PhotoFrame.SetActive(false);
        //GlassCover.SetActive(false);
        FamilyPhoto.SetActive(false);
        Urn.SetActive(false);
        SummerSunflower.SetActive(false);
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

    private int collected;
    public bool collectedPhotoFrame = false, collectedFamilyPhoto = false, collectedGlassCover = false;
    public void CheckProjectionFragments()
    {
        collected = 0;
        if (collectedPhotoFrame == true)
        {
            collected += 1;
        }
        if (collectedFamilyPhoto == true)
        {
            collected += 1;
        }
        if (collectedGlassCover == true)
        {
            collected += 1;
        }
    }

    public bool isProjectionComplete = false;
    public void CheckProjectionCompletion()
    {
        if (collectedPhotoFrame == true && collectedFamilyPhoto == true && collectedGlassCover == true)
        {
            isProjectionComplete = true;
        }
    }
    public override void Interact()
    {
        InventoryManager.Instance.Search(photoFrame, collectedPhotoFrame);
        InventoryManager.Instance.Search(familyPhoto, collectedFamilyPhoto);
        InventoryManager.Instance.Search(glassCover, collectedGlassCover);
        CheckProjectionFragments();
        CheckProjectionCompletion(); 
    }
}