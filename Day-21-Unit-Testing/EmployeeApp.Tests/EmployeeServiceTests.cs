using NUnit.Framework;
using Moq;
using System.Collections.Generic;

[TestFixture]
public class EmployeeServiceTests
{
    [Test]
    public void GetEmployeeCount_ReturnsCorrectCount()
    {
        // Arrange
        var mockRepo = new Mock<IEmployeeRepository>();
        mockRepo.Setup(r => r.GetAll()).Returns(new List<Employee>
        {
            new Employee { Id = 1, Name = "Ravi", Salary = 50000 },
            new Employee { Id = 2, Name = "Anu", Salary = 60000 }
        });

        var service = new EmployeeService(mockRepo.Object);

        // Act
        int count = service.GetEmployeeCount();

        // Assert
        Assert.That(count, Is.EqualTo(2));
    }

    [Test]
    public void GetEmployeeCount_WithEmptyList_ReturnsZero()
    {
        // Arrange
        var mockRepo = new Mock<IEmployeeRepository>();
        mockRepo.Setup(r => r.GetAll()).Returns(new List<Employee>());

        var service = new EmployeeService(mockRepo.Object);

        // Act
        int count = service.GetEmployeeCount();

        // Assert
        Assert.That(count, Is.EqualTo(0));
    }

    [Test]
    public void GetEmployeeCount_WithMultipleEmployees_ReturnsCorrectCount()
    {
        // Arrange
        var mockRepo = new Mock<IEmployeeRepository>();
        mockRepo.Setup(r => r.GetAll()).Returns(new List<Employee>
        {
            new Employee { Id = 1, Name = "Ravi", Salary = 50000 },
            new Employee { Id = 2, Name = "Anu", Salary = 60000 },
            new Employee { Id = 3, Name = "Raj", Salary = 55000 },
            new Employee { Id = 4, Name = "Priya", Salary = 65000 }
        });

        var service = new EmployeeService(mockRepo.Object);

        // Act
        int count = service.GetEmployeeCount();

        // Assert
        Assert.That(count, Is.EqualTo(4));
    }
}
