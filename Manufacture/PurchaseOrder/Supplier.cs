/*----------------------------------------------------
 * Author: Aristoteles Ibanez
 * Date: 29/04/2021
------------------------------------------------------*/

using Manufacture.OrderFactory;

namespace Manufacture.PurchaseOrder
{
    /// <summary>
    /// Implements the Supplier structure.
    /// </summary>
    public class Supplier: Receiver
    {
        /// <summary>
        /// The payment address of the supplier.
        /// </summary>
        public string PaymentAddress { get; set; }
    }
}
