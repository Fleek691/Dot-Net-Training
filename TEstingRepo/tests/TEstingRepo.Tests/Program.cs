using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;

[TestFixture]
public class EmployeeServiceTest
{
    private Mock<IEmployeeRepository> _repoMock = null!;
    private EmployeeService _service = null!;

    [SetUp]
    public void SetUp()
    {
        _repoMock = new Mock<IEmployeeRepository>();
        _service = new EmployeeService(_repoMock.Object);
    }

    [Test]
    public void GetEmployeeById_WithInvalidId_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => _service.GetEmployeeById(0));
        Assert.Throws<ArgumentException>(() => _service.GetEmployeeById(-10));
    }

    [Test]
    public void GetEmployeeById_WhenEmployeeNotFound_ThrowsKeyNotFoundException()
    {
        // Arrange
        _repoMock.Setup(r => r.GetById(1)).Returns((Employee?)null);

        // Act + Assert
        Assert.Throws<KeyNotFoundException>(() => _service.GetEmployeeById(1));
        _repoMock.Verify(r => r.GetById(1), Times.Once);
    }

    [Test]
    public void GetEmployeeById_WithValidId_ReturnsEmployee()
    {
        // Arrange
        var expected = new Employee();
        _repoMock.Setup(r => r.GetById(2)).Returns(expected);

        // Act
        var result = _service.GetEmployeeById(2);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.SameAs(expected));
        _repoMock.Verify(r => r.GetById(2), Times.Once);
    }

    [Test]
    public void BasicRepository_GetWelcomeMessage_ReturnsExpectedMessage()
    {
        var repository = new BasicEmployeeRepository();

        var result = repository.GetWelcomeMessage();

        Assert.That(result, Is.EqualTo("Repository is working"));
    }
}