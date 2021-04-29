/*----------------------------------------------------
 * Author: Aristoteles Ibanez
 * Date: 29/04/2021
------------------------------------------------------*/

using Manufacture.Inventory;
using Manufacture.OrderFactory;
using Manufacture.PurchaseOrder;
using NUnit.Framework;

namespace ManufactureUnitTests
{
    /// <summary>
    /// Unit test class for PurchaseOrders.
    /// </summary>
    public class PurchaseOrderTests
    {
        // private Order<Supplier> purchaseOrder;
        private PurchaseOrder purchaseOrder;

        [SetUp]
        public void Setup()
        {
            //purchaseOrder = new PurchaseOrder() as Order<Supplier>;
            purchaseOrder = OrderFactory<Supplier>.CreateOrder<PurchaseOrder>();
        }

        [Test]
        public void CreateSimplePOTest()
        {
            purchaseOrder.Number = "PO-85217";
            purchaseOrder.Owner.Email = "aibanezw@gmail.com";
            purchaseOrder.Owner.FullName = "GCORP";
            purchaseOrder.Owner.MainAddress =
            purchaseOrder.Owner.PaymentAddress = "Av. Punta Sal 514, Surco. Lima-Peru";

            Product product1 = new Product() { Name = "anthena", Price = 0.5, Quantity = 15 };
            Product product2 = new Product(name: "3.5 headphone jack", price: 2.5, quantity: 10);
            
            purchaseOrder.LineItems.Add(product1);
            purchaseOrder.LineItems.Add(product2);

            Assert.IsTrue(purchaseOrder.LineItems.Count == 2);
            Assert.IsTrue(purchaseOrder.Total == 32.5);
        }
    }
}
