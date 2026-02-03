using NUnit.Framework;

[TestFixture]
public class BankAccountTests
{
    private Program? bankAccount;

    [SetUp]
    public void Setup()
    {
        // Initialize bank account with initial balance of 1000
        bankAccount = new Program(1000m);
    }

    // Test Deposit method with valid amount
    [Test]
    public void Test_Deposit_ValidAmount()
    {
        // Arrange
        decimal depositAmount = 500m;
        decimal expectedBalance = 1500m;

        // Act
        bankAccount!.Deposit(depositAmount);

        // Assert
        Assert.That(bankAccount!.Balance, Is.EqualTo(expectedBalance));
    }

    // Test Deposit method with negative amount
    [Test]
    public void Test_Deposit_NegativeAmount()
    {
        // Arrange
        decimal negativeAmount = -100m;

        // Act & Assert
        Assert.Throws<System.InvalidOperationException>(() => bankAccount!.Deposit(negativeAmount));
    }

    // Test Withdraw method with valid amount
    [Test]
    public void Test_Withdraw_ValidAmount()
    {
        // Arrange
        decimal withdrawAmount = 300m;
        decimal expectedBalance = 700m;

        // Act
        bankAccount!.Withdraw(withdrawAmount);

        // Assert
        Assert.That(bankAccount!.Balance, Is.EqualTo(expectedBalance));
    }

    // Test Withdraw method with insufficient funds
    [Test]
    public void Test_Withdraw_InsufficientFunds()
    {
        // Arrange
        decimal withdrawAmount = 1500m;

        // Act & Assert
        Assert.Throws<System.InvalidOperationException>(() => bankAccount!.Withdraw(withdrawAmount));
    }
}
