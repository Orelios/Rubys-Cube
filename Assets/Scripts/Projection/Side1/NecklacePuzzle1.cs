using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NecklacePuzzle1 : InteractableObject
{
    public Projection1 projection;
    public override void Interact()
    {
        projection.SetNecklacePuzzleComplete();
        Destroy(gameObject);
    }
}
