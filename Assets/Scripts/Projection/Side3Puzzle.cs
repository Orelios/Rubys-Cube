using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Side3Puzzle : InteractableObject
{
    public Projection3 projection;

    public override void Interact()
    {
        projection.SetPuzzleComplete(); 
        Destroy(gameObject);
    }
}
