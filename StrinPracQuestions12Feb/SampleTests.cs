using System; // ArgumentException
using NUnit.Framework; // NUnit

namespace ItTechGenie.M1.NUnit.Q1
{
    // Production code (student implements TODO)
    public class ValueNormalizer
    {
        // ✅ TODO: Student must implement only this method
        public int NormalizeToInt(string raw)
        {
            // TODO:
            // - handle spaces: "  10,500  "


            if (string.IsNullOrEmpty(raw)) return -1;
            int converted = 0;
            if (decimal.TryParse(raw.Trim().Replace("₹", "").Replace(",", ""), out decimal a))
            {
                converted = (int)Math.Floor(a);
            }
            else
            {
                return -1;
            }

            if (converted < 0) throw new ArgumentException();
            return converted;

            // - handle currency: "₹ 1,999.25" (ignore decimals => 1999)
            // - reject negatives: "-42"
            // - reject null/empty/invalid text
            throw new NotImplementedException();
        }
    }

    // NUnit tests (do NOT change)
    [TestFixture]
    public class ValueNormalizerTests
    {
        private ValueNormalizer vn;
        [SetUp]
        public void Setup()
        {
            vn = new ValueNormalizer();
        }
        [Test]
        public void NormalizeToInt_Should_RemoveSpacesAndCommas()
        {
            // Arrange
            var raw = "  10,500  ";                                             // input with spaces and comma

            // Act
            var result = vn.NormalizeToInt(raw);                    // call method

            // Assert
            Assert.That(result, Is.EqualTo(10500));                                      // expected normalized value
        }

        [Test]
        public void NormalizeToInt_Should_RemoveCurrencySymbolAndDecimals()
        {
            // Arrange
            var raw = "₹ 1,999.25";                                              // currency + decimals

            // Act
            var result = vn.NormalizeToInt(raw);                    // call method

            // Assert
            Assert.That(1999,Is.EqualTo(result));                                       // tests expect decimals to be ignored
        }

        [Test]
        public void NormalizeToInt_Should_Throw_ForNegative()
        {
            // Arrange
            var raw = " -42 ";                                                   // negative with spaces

            // Act + Assert
            Assert.Throws<ArgumentException>(() => {
                vn.NormalizeToInt(raw);
            }); // must throw
        }
    }
}