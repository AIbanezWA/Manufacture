/*----------------------------------------------------
 * Author: Aristoteles Ibanez
 * Date: 29/04/2021
------------------------------------------------------*/
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Manufacture.Inventory
{
    /// <summary>
    /// Collection class to store product items in composite products.
    /// </summary>
    public class Components: Collection<Product>
    {
        /// <summary>
        /// Gets true if the collection belongs to a composite product otherwise returns false.
        /// </summary>
        private bool IsComposite { get; }

        /// <summary>
        /// Gets the subtotal.
        /// </summary>
        public double Subtotal { get => this.Sum(n=>n.Subtotal); } 

        /// <summary>
        /// Creates a new collection instance.
        /// </summary>
        /// <param name="isComposite">Used to indicate if the collection is composite or not.</param>
        public Components(bool isComposite)
        {
            IsComposite = isComposite;
        }
        
        /// <summary>
        /// Adds a new product at the end of the collection.
        /// </summary>
        /// <param name="item"></param>
        public new void Add(Product item)
        {
            if (!IsComposite)
                throw new InvalidOperationException("Cannot add a child product in a leaf product."); 

            base.Add(item);
        }

        /// <summary>
        /// Adds a new product in a specific position.
        /// </summary>
        /// <param name="index">Position in the collection.</param>
        /// <param name="item">Product to be added.</param>
        public new void Insert(int index, Product item)
        {
            if (!IsComposite)
                throw new InvalidOperationException("Cannot add a child product in a leaf product.");

            base.Insert(index, item);
        }

        /// <summary>
        /// Inserts a new product in a specific position.
        /// </summary>
        /// <param name="index">Position in the collection.</param>
        /// <param name="item">Product to be added.</param>
        public new void InsertItem(int index, Product item)
        {
            if (!IsComposite)
                throw new InvalidOperationException("Cannot add a child product in a leaf product.");

            base.InsertItem(index, item);
        }

        /// <summary>
        /// Updates a product in a specific position.
        /// </summary>
        /// <param name="index">Position in the collection.</param>
        /// <param name="item">Product to be added.</param>
        public new void SetItem(int index, Product item)
        {
            if (!IsComposite)
                throw new InvalidOperationException("Cannot set a child product in a leaf product.");
            
            base.SetItem(index, item);
        }

        /// <summary>
        /// Removes a product from the collection.
        /// </summary>
        /// <param name="item">Product to be removed.</param>
        public new void Remove(Product item)
        {
            if (!IsComposite)
                throw new InvalidOperationException("Cannot remove a child product.");

            base.Remove(item);
        }

        /// <summary>
        /// Removes a product from the collection in a specific position.
        /// </summary>
        /// <param name="index">The position of the product in the collection.</param>
        public new void RemoveAt(int index)
        {
            if (!IsComposite)
                throw new InvalidOperationException($"Cannot remove a child product at position {index}.");

            base.RemoveAt(index);
        }

        /// <summary>
        /// Removes all products.
        /// </summary>
        public new void Clear()
        {
            if (!IsComposite)
                throw new InvalidOperationException("Cannot clear items in a leaf product.");

            base.Clear();
        }

        /// <summary>
        /// Removes all products.
        /// </summary>
        public new void ClearItems()
        {
            if (!IsComposite)
                throw new InvalidOperationException("Cannot clear items in a leaf product.");

            base.ClearItems();
        }
    }
}
