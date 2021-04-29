/*----------------------------------------------------
 * Author: Aristoteles Ibanez
 * Date: 29/04/2021
------------------------------------------------------*/

using Manufacture.Inventory;
using NUnit.Framework;
using System;
using System.Linq;

namespace ManufactureUnitTests
{
    /// <summary>
    /// Unit test class for Products.
    /// </summary>
    public class Tests
    {
        Product product;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CreateSingleProduct()
        {
            product = new Product(name: "3.5 headphone jack", price: 2.5, quantity: 10);
            Assert.NotNull(product);
        }

        [Test]
        public void SingleProductSubtotal()
        {
            double price = 0.7;
            int quantity = 20;

            product = new Product() { Name = "2.5mm Screw", Price = price,
                Quantity = quantity };

            Assert.AreEqual(expected: price * quantity, actual: product.Subtotal);
            Assert.AreEqual(expected: 0, actual: product.Components.Count());
        }

        [Test]
        public void SingleProductAddConstraint()
        {
            product = new Product() { Name = "anthena", Price = 0.5, Quantity = 15 };

            Assert.Throws<InvalidOperationException>(() => product.Components.Add(new Product()));
        }

        [Test]
        public void SingleProductRemoveConstraint()
        {
            product = new Product() { Name = "anthena", Price = 0.5, Quantity = 15 };

            Assert.Throws<InvalidOperationException>(() => product.Components.Remove(new Product()));
        }

        [Test]
        public void CreateAssemblyProduct()
        {
            product = new Product(composite: true, name: "Vintage Stereo HiFi System");
            product.Components.Add(new Product(name: "Amplifier", price: 400, quantity: 1));
            product.Components.Add(new Product(name: "Turntable", price: 150, quantity: 1));
            product.Components.Add(new Product(name: "Cassette Deck", price: 250, quantity: 1));
            product.Components.Add(new Product(name: "Speakers", price: 100, quantity: 2));
            product.Components.Add(new Product(name: "Equalizer", price: 50, quantity: 1));
            product.Components.Add(new Product(name: "Tunner", price: 50, quantity: 1));

            Assert.IsTrue(product.Quantity == 1);
            Assert.IsTrue(product.Components.Count == 6);
            Assert.IsTrue(product.Subtotal == 1100);
        }

        [Test]
        public void ModifyAssemblyProduct()
        {

            product = new Product(composite: true, name: "Vintage Stereo HiFi System");
            Product p1;
            Product p2;

            product.Components.Add(new Product(name: "Amplifier", price: 400, quantity: 1));
            product.Components.Add(new Product(name: "Turntable", price: 150, quantity: 1));
            product.Components.Add(new Product(name: "Cassette Deck", price: 250, quantity: 1));
            product.Components.Add(p1 = new Product(name: "Speakers", price: 100, quantity: 2));
            product.Components.Add(p2 = new Product(name: "Equalizer", price: 50, quantity: 1));
            product.Components.Add(new Product(name: "Tunner", price: 50, quantity: 1));

            Assert.IsTrue(product.Quantity == 1);
            Assert.IsTrue(product.Components.Count == 6);
            Assert.IsTrue(product.Subtotal == 1100);

            product.Components.Remove(p1);
            Assert.IsTrue(product.Components.Count == 5);
            Assert.IsTrue(product.Subtotal == 900);

            product.Components.Remove(p2);
            Assert.IsTrue(product.Components.Count == 4);
            Assert.IsTrue(product.Subtotal == 850);

            product.Components.Add(p1);
            product.Components.Add(p2);
            Assert.IsTrue(product.Components.Count == 6);
            Assert.IsTrue(product.Subtotal == 1100);
        }
    }
}