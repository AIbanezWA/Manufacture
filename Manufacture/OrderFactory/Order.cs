/*----------------------------------------------------
 * Author: Aristoteles Ibanez
 * Date: 29/04/2021
------------------------------------------------------*/
using Manufacture.Inventory;
using System.Collections.ObjectModel;
using System.Linq;

namespace Manufacture.OrderFactory
{
    /// <summary>
    /// General abstraction class for any order.
    /// </summary>
    /// <typeparam name="T">Document owner type.</typeparam>
    public abstract class Order<T> where T: Receiver, new()
    {
        /// <summary>
        /// Gets/sets the order number.
        /// </summary>
       public string Number { get; set; }

        /// <summary>
        /// Gets/sets the owner.
        /// </summary>
       public T Owner { get; set; }

        /// <summary>
        /// Gets the subtotal of this order.
        /// </summary>
        public double Total { get => LineItems.Sum(n=>n.Subtotal);  }

        /// <summary>
        /// Gets the items of this order.
        /// </summary>
       public Collection<Product> LineItems { get; }
       
        /// <summary>
        /// Creates a new instance of this order.
        /// </summary>
       public Order()
        {
            LineItems = new Collection<Product>();
            Owner = new T();
        }
    }
}