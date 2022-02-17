using System.Collections.Generic;
using BLL.Interfaces;

namespace BLL.Entities
{
    class RequestDataBase : IDataBase
    {
        private static List<Request> listOfRequests;
        internal RequestDataBase()
        {
            listOfRequests = new List<Request>();
        }

        public void AddRequest(Request request)
        {
            listOfRequests.Add(request);
        }

        public bool RemoveRequest(Request request)
        {
            return listOfRequests.Remove(request); 
        }

        public List<Request> GetListOfRequests()
        {
            return new List<Request>(listOfRequests);
        }   
    }
}
