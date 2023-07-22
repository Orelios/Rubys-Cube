using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacePuzzle3 : InteractableObject
{
    public Projection1 projection;
    public override void Interact()
    {
        projection.SetFacePuzzleComplete();
        Destroy(gameObject);
    }
}
