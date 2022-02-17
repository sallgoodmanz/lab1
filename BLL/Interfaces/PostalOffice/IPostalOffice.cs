using System.Collections.Generic;
using BLL.Entities;

namespace BLL.Interfaces
{
    public interface IPostalOffice
    {
        List<Request> GetSubsRequest(ISubscriber sub);
        List<Request> GetListOfRequests();
        void Update();
        void AddStorage(IStorage storage);
        void RemoveStorage(IStorage storage);
        void Subscribe(ISubscriber subscriber, IProductData product);
        void Unsubscribe(Request request);
    }
}
