using System.Collections.Generic;
using BLL.Interfaces;

namespace BLL.Entities
{
    public class ProductStorage : IStorage
    {
        private List<IProduct> products;
        public int Count { get { return products.Count; } }

        public ProductStorage()
        {
            products = new List<IProduct>();
        }

        public bool MoveToStorage(IProduct product)
        {
            products.Add(product);
            return true;
        }

        public bool RemoveFromStorage(IProduct product)
        {
            return products.Remove(product);
        }

        public List<IProduct> getListOfGoods()
        {
            return new List<IProduct>(products);
        }

        public IProduct SearchForProduct(Request req)
        {
            foreach (var product in getListOfGoods())
                if (req.productData.Name == product.Name && req.productData.EditionNumber == product.EditionNumber)
                {
                    IProduct tempProduct = product;
                    this.RemoveFromStorage(product);
                    return tempProduct;
                }
            return null;
        }
    }
}
