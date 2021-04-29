/*----------------------------------------------------
 * Author: Aristoteles Ibanez
 * Date: 29/04/2021
------------------------------------------------------*/
namespace Manufacture.OrderFactory
{
    /// <summary>
    /// Factory Method Design Pattern for Orders.
    /// </summary>
    /// <typeparam name="R"></typeparam>
    public class OrderFactory<R> where R: Receiver, new()
    {
        private static readonly Order<R> instance;

        /// <summary>
        /// Creates a unique instance of a order.
        /// </summary>
        /// <typeparam name="T">Order type.</typeparam>
        /// <returns>Returns a new shared order.</returns>
        public static T CreateOrder<T>() where T: Order<R>, new()
        {
            return instance == null? new T(): instance as T;
        }
    }
}
