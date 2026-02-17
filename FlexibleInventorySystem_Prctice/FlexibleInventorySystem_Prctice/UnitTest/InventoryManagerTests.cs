using System;
using FlexibleInventorySystem_Practice.Models;
using FlexibleInventorySystem_Practice.Services;
using NUnit.Framework;

namespace FlexibleInventorySystem_Prctice.UnitTest
{
    // Example test cases (not provided - students should create their own)
    [TestFixture]
    public class InventoryManagerTests
    {
        private InventoryManager? manager;

        [SetUp]
        public void SetUp()
        {
            manager = new InventoryManager();
        }

        [Test]
        public void AddProduct_ValidProduct_ReturnsTrue()
        {
            var product = CreateElectronicProduct("E001", 10, 999.99m);
            var res = manager!.AddProduct(product);
            Assert.IsTrue(res);
        }

        [Test]
        public void AddProduct_DuplicateId_ReturnsFalse()
        {
            manager!.AddProduct(CreateElectronicProduct("E001", 10, 999.99m));
            var result = manager.AddProduct(CreateElectronicProduct("E001", 5, 199.99m));

            Assert.IsFalse(result);
        }

        [Test]
        public void AddProduct_NullProduct_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => manager!.AddProduct(null!));
        }

        [Test]
        public void FindProduct_ExistingId_ReturnsProduct()
        {
            var product = CreateElectronicProduct("E001", 10, 999.99m);
            manager!.AddProduct(product);

            var found = manager.FindProduct("E001");

            Assert.IsNotNull(found);
            Assert.AreEqual("E001", found.Id);
        }

        [Test]
        public void UpdateQuantity_ExistingId_UpdatesAndReturnsTrue()
        {
            var product = CreateElectronicProduct("E001", 10, 999.99m);
            manager!.AddProduct(product);

            var updated = manager.UpdateQuantity("E001", 25);

            Assert.IsTrue(updated);
            Assert.AreEqual(25, manager.FindProduct("E001")!.Quantity);
        }

        [Test]
        public void RemoveProduct_ExistingId_RemovesAndReturnsTrue()
        {
            manager!.AddProduct(CreateElectronicProduct("E001", 10, 999.99m));

            var removed = manager.RemoveProduct("E001");

            Assert.IsTrue(removed);
            Assert.IsNull(manager.FindProduct("E001"));
        }

        [Test]
        public void GetLowStockProducts_ReturnsItemsAtOrBelowThreshold()
        {
            manager!.AddProduct(CreateElectronicProduct("E001", 2, 999.99m));
            manager.AddProduct(CreateElectronicProduct("E002", 5, 499.99m));
            manager.AddProduct(CreateElectronicProduct("E003", 20, 199.99m));

            var lowStock = manager.GetLowStockProducts(5);

            Assert.AreEqual(2, lowStock.Count);
            Assert.IsTrue(lowStock.Any(p => p.Id == "E001"));
            Assert.IsTrue(lowStock.Any(p => p.Id == "E002"));
        }

        [Test]
        public void GetTotalInventoryValue_SumsAllProductValues()
        {
            manager!.AddProduct(CreateElectronicProduct("E001", 2, 100m));
            manager.AddProduct(CreateElectronicProduct("E002", 3, 50m));

            var total = manager.GetTotalInventoryValue();

            Assert.AreEqual(350m, total);
        }

        private static Product CreateElectronicProduct(string id, int quantity, decimal price)
        {
            return new ElectronicProduct
            {
                Id = id,
                Name = "Laptop",
                Price = price,
                Quantity = quantity,
                Category = "Electronics",
                Brand = "Dell",
                WarrantyMonths = 24,
                Voltage = "110-240V"
            };
        }

        // TODO: Add more test methods
    }
}
