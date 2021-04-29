/*----------------------------------------------------
 * Author: Aristoteles Ibanez
 * Date: 29/04/2021
------------------------------------------------------*/
namespace Manufacture.Inventory
{
    /// <summary>
    /// Represents a product class for inventory system.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Creates a new product instance.
        /// </summary>
        public Product()
        {
            Components = new Components(false);
        }

        /// <summary>
        /// Creates a new product instance.
        /// </summary>
        /// <param name="name">Product name.</param>
        /// <param name="price">Product price.</param>
        /// <param name="quantity">Product quantity.</param>
        public Product(string name, double price, int quantity): this()
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        /// <summary>
        /// Creates a new product instance.
        /// </summary>
        /// <param name="name">Product name.</param>
        /// <param name="composite">Indicates if the product is composite or not.</param>
        public Product(string name, bool composite = true)
        {
            Name = name;
            Quantity = 1;
            Composite = composite;
            Components = new Components(composite);
        }

        /// <summary>
        /// Product Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Product price.
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Product quantity.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Inicates if the product is composed or not.
        /// </summary>
        public bool Composite { get; }

        /// <summary>
        /// Gets the subtotal price for the current product.
        /// </summary>
        public double Subtotal { get => (Composite ? Components.Subtotal: Price) * Quantity; }

        /// <summary>
        /// Gets all product childs of this product.
        /// </summary>
        public Components Components { get; }
    }
}