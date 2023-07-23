using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ProjectionClass
{
    public bool isPuzzleComplete = false; 

    public string id;
    public ForSide side;
}

public enum ForSide
{
    Side1,
    Side2,
    Side3,
    Side4
}
