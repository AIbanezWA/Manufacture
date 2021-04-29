/*----------------------------------------------------
 * Author: Aristoteles Ibanez
 * Date: 29/04/2021
------------------------------------------------------*/
namespace Manufacture.OrderFactory
{
    /// <summary>
    /// Order's Owner 
    /// </summary>
    public class Receiver
    {
        /// <summary>
        /// Gets/sets the owner fullname.
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Gets/sets the owner main address.
        /// </summary>
        public string MainAddress { get; set; }

        /// <summary>
        /// Gets/sets the owner phone.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Gets/sets the owner email.
        /// </summary>
        public string Email { get; set; }
    }
}
