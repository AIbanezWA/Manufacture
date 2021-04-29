/*----------------------------------------------------
 * Author: Aristoteles Ibanez
 * Date: 29/04/2021
------------------------------------------------------*/
using Manufacture.Inventory;
using Manufacture.OrderFactory;
using Manufacture.SaleOrder;
using NUnit.Framework;


namespace ManufactureUnitTests
{
    /// <summary>
    /// Unit test class for SalesOrders.
    /// </summary>
    public class SaleOrderTests
    {
        private SaleOrder purchaseOrder;

        [SetUp]
        public void Setup()
        {
            purchaseOrder = OrderFactory<Customer>.CreateOrder<SaleOrder>();
        }

        [Test]
        public void CreateSimplePOTest()
        {
            purchaseOrder.Number = "SO-39752";
            purchaseOrder.Owner.Email = "aibanezw@gmail.com";
            purchaseOrder.Owner.FullName = "GCORP";
            purchaseOrder.Owner.MainAddress =
            purchaseOrder.Owner.BillingAddress = "Av. Punta Sal 514, Surco. Lima-Peru";

            Product product1 = new Product() { Name = "anthena", Price = 0.5, Quantity = 15 };
            Product product2 = new Product(name: "3.5 headphone jack", price: 2.5, quantity: 10);

            purchaseOrder.LineItems.Add(product1);
            purchaseOrder.LineItems.Add(product2);

            Assert.IsTrue(purchaseOrder.LineItems.Count == 2);
            Assert.IsTrue(purchaseOrder.Total == 32.5);
        }
    }
}
