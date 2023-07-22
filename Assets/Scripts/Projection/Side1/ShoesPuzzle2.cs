using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoesPuzzle2 : InteractableObject
{
    public Projection1 projection;
    public override void Interact()
    {
        Destroy(gameObject);
    }
}
