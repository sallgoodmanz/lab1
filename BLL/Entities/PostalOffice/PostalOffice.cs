using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;


namespace BLL.Entities
{
    public class PostalOffice : IPostalOffice
    {
        private IDataBase dataBase;
        private List<IStorage> listOfStorages;

        public PostalOffice()
        {
            dataBase = new RequestDataBase();
            listOfStorages = new List<IStorage>();
        }

        public List<Request> GetSubsRequest(ISubscriber sub)
        {
            List<Request> newList = new List<Request>();
            foreach (var req in GetListOfRequests())
            {
                if (req.subscriber == sub)
                {
                    newList.Add(req);
                }
            }
            return newList;
        }

        public void AddStorage(IStorage storage)
        {
            listOfStorages.Add(storage);
        }
        public void RemoveStorage(IStorage storage)
        {
            listOfStorages.Remove(storage);
        }
        public void Update()
        {
            foreach (var storage in listOfStorages)
                foreach (var req in this.GetListOfRequests())
                {
                    var product = storage.SearchForProduct(req);
                    if (product != null)
                    {
                        req.subscriber.GetProduct(product);
                        Unsubscribe(req);
                    }
                }
        }


        public List<Request> GetListOfRequests()
        {
            return dataBase.GetListOfRequests();
        }
        public void Subscribe(ISubscriber sub, IProductData product)
        {
            dataBase.AddRequest(new Request(sub, product));
        }

        public void Unsubscribe(Request request)
        {
            dataBase.RemoveRequest(request);
        }

    }
}
