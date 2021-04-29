/*----------------------------------------------------
 * Author: Aristoteles Ibanez
 * Date: 29/04/2021
------------------------------------------------------*/

using Manufacture.OrderFactory;

namespace Manufacture.SaleOrder
{
    /// <summary>
    /// Implements the customer structure.
    /// </summary>
    public class Customer: Receiver
    {
        /// <summary>
        /// The billing address of the customer.
        /// </summary>
        public string BillingAddress { get; set; }
    }
}
