using System.Net.Mail;
using NUnit.Framework;

[TestFixture]
public class Membershiptest
{
    public Membership mem;
    [SetUp]
    public void SetUp()
    {
        mem = new Membership();
    }
    [Test]
    public void ValidateEnrollment_ReturnTrue()
    {
        mem.Tier = "Basic";
        mem.DurationInMonths = 24;
        Assert.That(mem.ValidateEnrollment(), Is.True);
    }
    [Test]
    public void ValidateEnrollment_ThrowsException(){
        mem.Tier = "Gold";
        mem.DurationInMonths=10;
        Assert.Throws<InvalidTierException>(() => mem.ValidateEnrollment());
    }
    [Test]
    public  void ValidateEnrollment_ThrowsExceptionI(){
        mem.Tier="Elite";
        mem.DurationInMonths=-2;
        Assert.Throws<Exception>(()=>mem.ValidateEnrollment());
    }
    [Test]
    [TestCase("Basic", 10, 100, 980)]
    [TestCase("Premium",10,100,930)]
    public void CalculateTotalBill(string tier,int mont,double price,double expected){
        mem.Tier=tier;
        mem.DurationInMonths=mont;
        mem.BasePricePerMonth=price;
        double actual=mem.CalculateBill();
        Assert.That(expected,Is.EqualTo(actual));
    }
}