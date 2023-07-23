using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CafeLogoPuzzle4 : InteractableObject
{
    public Projection1 projection;
    public override void Interact()
    {
        projection.SetCafeLogoPuzzleComplete();
        Destroy(gameObject);
    }
}
