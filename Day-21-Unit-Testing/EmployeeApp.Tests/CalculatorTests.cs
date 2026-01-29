using NUnit.Framework;
using EmployeeApp.Core;
using System;


[TestFixture]
public class CalculatorTests
{
    private Calculator _calculator;

    [SetUp]
    public void SetUp()
    {
        // This method runs before each test
        _calculator = new Calculator();
    }

    [Test]
    public void Add_TwoPositiveNumbers_ReturnsCorrectSum()
    {
        // Arrange
        int a = 5;
        int b = 3;

        // Act
        int result = _calculator.Add(a, b);

        // Assert
        Assert.That(result, Is.EqualTo(8));
    }

    [Test]
    public void Add_NegativeAndPositive_ReturnsCorrectSum()
    {
        // Arrange
        int a = -5;
        int b = 3;

        // Act
        int result = _calculator.Add(a, b);

        // Assert
        Assert.That(result, Is.EqualTo(-2));
    }

    [Test]
    public void Subtract_TwoNumbers_ReturnsCorrectDifference()
    {
        // Arrange
        int a = 10;
        int b = 4;

        // Act
        int result = _calculator.Subtract(a, b);

        // Assert
        Assert.That(result, Is.EqualTo(6));
    }

    [Test]
    public void Multiply_TwoNumbers_ReturnsCorrectProduct()
    {
        // Arrange
        int a = 6;
        int b = 7;

        // Act
        int result = _calculator.Multiply(a, b);

        // Assert
        Assert.That(result, Is.EqualTo(42));
    }

    [Test]
    public void Multiply_ByZero_ReturnsZero()
    {
        // Arrange
        int a = 5;
        int b = 0;

        // Act
        int result = _calculator.Multiply(a, b);

        // Assert
        Assert.That(result, Is.EqualTo(0));
    }

    [Test]
    public void Divide_TwoNumbers_ReturnsCorrectQuotient()
    {
        // Arrange
        int a = 10;
        int b = 2;

        // Act
        double result = _calculator.Divide(a, b);

        // Assert
        Assert.That(result, Is.EqualTo(5.0));
    }

    [Test]
    public void Divide_WithRemainder_ReturnsDecimalValue()
    {
        // Arrange
        int a = 10;
        int b = 3;

        // Act
        double result = _calculator.Divide(a, b);

        // Assert
        Assert.That(result, Is.EqualTo(3.333).Within(0.001));
    }

    [Test]
    public void Divide_ByZero_ThrowsException()
    {
        // Arrange
        int a = 10;
        int b = 0;

        // Act & Assert
        Assert.Throws<DivideByZeroException>(() => _calculator.Divide(a, b));
    }

    [Test]
    public void Modulus_TwoNumbers_ReturnsCorrectRemainder()
    {
        // Arrange
        int a = 10;
        int b = 3;

        // Act
        int result = _calculator.Modulus(a, b);

        // Assert
        Assert.That(result, Is.EqualTo(1));
    }

    [Test]
    public void Modulus_ByZero_ThrowsException()
    {
        // Arrange
        int a = 10;
        int b = 0;

        // Act & Assert
        Assert.Throws<DivideByZeroException>(() => _calculator.Modulus(a, b));
    }

    // Testing multiple scenarios with TestCase attribute
    [TestCase(2, 3, 5)]
    [TestCase(0, 0, 0)]
    [TestCase(-5, 5, 0)]
    [TestCase(100, 200, 300)]
    public void Add_VariousInputs_ReturnsCorrectSum(int a, int b, int expected)
    {
        // Act
        int result = _calculator.Add(a, b);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [TearDown]
    public void TearDown()
    {
        // This method runs after each test
        // Cleanup code if needed
        _calculator = null!;
    }
}
