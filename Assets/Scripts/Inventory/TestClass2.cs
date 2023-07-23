using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "testClass2", menuName = "item/test2")]
public class TestClass2 : ItemClass
{
    public override void UseItem(UseItem calledBy)
    {
        Debug.Log("Used Test Class 2");
        calledBy.inventory.Remove(this);
    }
    public override ItemClass GetItem() { return this; }
    public override TestClass1 GetTestClass1() { return null; }
    public override TestClass2 GetTestClass2() { return this; }
    public override Side3Fragments GetSide3Fragments() { return null; }
    public override Side1Fragments GetSide1Fragments() { return null; }
}
