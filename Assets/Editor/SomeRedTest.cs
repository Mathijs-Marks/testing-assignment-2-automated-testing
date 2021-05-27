using NUnit.Framework;
using UnityEngine;

public class SomeRedTest : MonoBehaviour
{
    [Test]
    public void SomeGreenTestPassing()
    {
        Assert.Fail();
    }
}
