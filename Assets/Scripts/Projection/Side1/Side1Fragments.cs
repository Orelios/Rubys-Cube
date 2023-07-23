using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "side1Fragments", menuName = "fragments/side1")]
public class Side1Fragments : ItemClass
{
    public side1Fragments side1; 
    public enum side1Fragments
    {
        Necklace, 
        Shoes, 
        SummerSunflower, 
        NecklacePendant, 
        NecklaceChain, 
    }
    public override ItemClass GetItem() { return this; }
    public override TestClass1 GetTestClass1() { return null; }
    public override TestClass2 GetTestClass2() { return null; }
    public override Side3Fragments GetSide3Fragments() { return null; }
    public override Side1Fragments GetSide1Fragments() { return this; }
}
