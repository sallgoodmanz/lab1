using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Entities;

namespace BLL.Interfaces
{
    interface IDataBase
    {
        void AddRequest(Request request);
        bool RemoveRequest(Request request);
        List<Request> GetListOfRequests();
    
    }
}
