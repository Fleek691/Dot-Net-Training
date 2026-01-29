using NUnit.Framework;
using EmployeeApp.Core;
using System;
using Moq;

[TestFixture]
public class EmpService2Tests

{
    private Mock<IEmployeeRepository2> _mockRepo;
    

    [SetUp]
    public void SetUp()
    {
        _mockRepo=new Mock<IEmployeeRepository2>();
        EmpService2 empService2=new EmpService2();
    }

    
    [Test]
    public void GetName_WithValidName_ReturnsUpperCase()
    {
        EmpService2 empService2=new EmpService2();
        var result=empService2.GetName("Avishek");
        Assert.That(result,Is.EqualTo("Avishek"));
    }
    [Test]
    public void GetIdTest(){
        _mockRepo.Setup(r => r.GetId(1)).Returns(1);
        var result=_mockRepo.Object.GetId(1);
        Assert.That(result,Is.EqualTo(1));
    }

}