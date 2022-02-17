using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Entities;

namespace BLL.Interfaces
{
    public interface IPrintingOffice
    {
        IStorage GetStorage();
        void printMagazine(string name, string edition);
        void printNewspaper(string name, string edition);
    }
}
