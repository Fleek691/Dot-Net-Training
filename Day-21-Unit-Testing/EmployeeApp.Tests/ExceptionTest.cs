using NUnit.Framework;
public class ExceptionTests
{
    ExceptionClass ex;
    [SetUp]
    public void Setup()
    {
        ex=new ExceptionClass();
    }

    [Test]
    public void Calculate_ShouldThrowDifferentExceptions()
    {
        Assert.Multiple(() =>
        {
            Assert.Throws<DivideByZeroException>(() => ex.ExceptionMethod(1));
            Assert.Throws<NullReferenceException>(() => ex.ExceptionMethod(2));
            Assert.Throws<InvalidCastException>(() => ex.ExceptionMethod(3));
            Assert.Throws<StackOverflowException>(() => ex.ExceptionMethod(4));
        });
    }
}

