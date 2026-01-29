using NUnit.Framework;
using NUnitDemo.Core;

namespace NUnitDemo.Tests;

[TestFixture]
public class BankAccountTests
{
    private BankAccount _account;

    [SetUp]
    public void Setup()
    {
        _account = new BankAccount(1000);
    }

    // 1️⃣ Constructor Exception
    [Test]
    public void Constructor_NegativeBalance_ThrowsException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            new BankAccount(-500);
        });
    }

    // 2️⃣ Deposit Exceptions
    [Test]
    public void Deposit_ZeroAmount_ThrowsException()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            _account.Deposit(0);
        });
    }

    [Test]
    public void Deposit_NegativeAmount_ThrowsException()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            _account.Deposit(-100);
        });
    }

    // 3️⃣ Withdraw Exceptions
    [Test]
    public void Withdraw_ZeroAmount_ThrowsException()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            _account.Withdraw(0);
        });
    }

    [Test]
    public void Withdraw_AmountGreaterThanBalance_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() =>
        {
            _account.Withdraw(2000);
        });
    }

    // 4️⃣ Happy Path (No Exception)
    [Test]
    public void Withdraw_ValidAmount_UpdatesBalance()
    {
        _account.Withdraw(200);

        Assert.That(_account.Balance, Is.EqualTo(800));
    }
}