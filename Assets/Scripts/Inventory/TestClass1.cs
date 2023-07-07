using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "testClass1", menuName = "item/test1")]
public class TestClass1 : ItemClass
{
    public override ItemClass GetItem() { return this; }
    public override TestClass1 GetTestClass1() { return this; }
    public override TestClass2 GetTestClass2() { return null; }
}
