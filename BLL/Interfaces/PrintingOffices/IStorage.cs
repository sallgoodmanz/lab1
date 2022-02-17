using System.Collections.Generic;
using BLL.Entities;


namespace BLL.Interfaces
{
    public interface IStorage
    {
        int Count { get; }
        bool MoveToStorage(IProduct product);
        bool RemoveFromStorage(IProduct product);
        List<IProduct> getListOfGoods();
        IProduct SearchForProduct(Request req);
    }
}
