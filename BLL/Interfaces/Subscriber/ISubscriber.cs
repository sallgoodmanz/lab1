using BLL.Entities;
using System;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface ISubscriber
    {
        string Name { get; set; }
        string Surname { get; set; }
        string HomeAddress { get; set; }
        List<IProduct> GetListOfProducts();
        void GetProduct(IProduct product);
        event EventHandler<IProduct> GotTheProduct;
    }
}
