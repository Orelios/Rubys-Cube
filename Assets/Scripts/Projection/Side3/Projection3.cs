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

    public Material[] material;
    public Material lambert87;
    public int ProjectionCombo;
    Renderer rend;

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

        ProjectionCombo = 0;
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = lambert87;
    }

    void Update()
    {
        rend.sharedMaterial = material[ProjectionCombo];
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
        ChangeProjectionCombo();
        fragmentCounterText.text = collectedFragments + "/" + fragmentMaxCount;
    }

    public void ChangeProjectionCombo()
    {
        if (collectedFamilyPhoto == true)
        {
            ProjectionCombo = 1;
        }
        if (collectedPhotoFrame == true)
        {
            ProjectionCombo = 2;
        }
        if (collectedGlassCover == true)
        {
            ProjectionCombo = 3;
        }
        if (collectedGlassCover == true && collectedPhotoFrame == true)
        {
            ProjectionCombo = 4;
        }
        if (collectedGlassCover == true && collectedFamilyPhoto == true)
        {
            ProjectionCombo = 5;
        }
        if (collectedPhotoFrame == true && collectedFamilyPhoto == true)
        {
            ProjectionCombo = 6;
        }
        if (collectedPhotoFrame == true && collectedFamilyPhoto == true && collectedGlassCover == true)
        {
            ProjectionCombo = 7;
        }
    }

    public void CheckProjectionCompletion()
    {
        if (collectedPhotoFrame == true && collectedFamilyPhoto == true && collectedGlassCover == true)
        {
            isProjectionComplete = true;
            ProjectionCompletionPopUp.instance.ProjectionNumber(2); 
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