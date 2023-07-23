using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "side3Fragments", menuName = "fragments/side3")]
public class Side3Fragments : ItemClass
{
    public side3Fragments side3; 
    public enum side3Fragments
    {
        PhotoFrame,
        FamilyPhoto, 
        GlassCover, 
        Face, 
    }
    public override void UseItem(UseItem calledBy)
    {
        base.UseItem(calledBy);
    }
    public override ItemClass GetItem() { return this; }
    public override TestClass1 GetTestClass1() { return null; }
    public override TestClass2 GetTestClass2() { return null; }
    public override Side3Fragments GetSide3Fragments() { return this; }
    public override Side1Fragments GetSide1Fragments() { return null; }
}
