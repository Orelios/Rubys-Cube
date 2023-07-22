using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projection1 : MonoBehaviour
{
    public GameObject necklace, shoes, face, cafeLogo;
    // Start is called before the first frame update
    void Start()
    {
        necklace.SetActive(false);
        face.SetActive(false);
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
}