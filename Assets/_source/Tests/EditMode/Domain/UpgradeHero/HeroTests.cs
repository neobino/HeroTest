using Domain.Models.HeroUpgrade;
using NUnit.Framework;

public class HeroTests
{

    [Test]
    public void NormalizeValues()
    {
        var h = new Hero("", 0, -5);
        Assert.AreEqual("New Hero", h.Name);
        Assert.AreEqual(1, h.Level);
        Assert.AreEqual(0, h.Strength);
    }
}
