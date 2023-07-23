using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "testClass1", menuName = "item/test1")]
public class TestClass1 : ItemClass
{
    public override void UseItem(UseItem calledBy)
    {
        Debug.Log("Used Test Class 1");
        calledBy.inventory.Remove(this); 
    }
    public override ItemClass GetItem() { return this; }
    public override TestClass1 GetTestClass1() { return this; }
    public override TestClass2 GetTestClass2() { return null; }
    public override Side3Fragments GetSide3Fragments() { return null; }
    public override Side1Fragments GetSide1Fragments() { return null; }
}
