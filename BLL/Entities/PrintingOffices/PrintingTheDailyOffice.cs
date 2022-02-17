using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;

namespace BLL.Entities
{
    public class PrintingTheDailyOffice : IPrintingOffice
    {
        private IStorage storage;

        public PrintingTheDailyOffice(IStorage storage)
        {
            this.storage = storage;
        }
      
        public IStorage GetStorage()
        {
            return storage;
        }

        public void printMagazine(string name, string edition)
        {
            storage.MoveToStorage(new TheDailyMagazine(name, edition));
        }

        public void printNewspaper(string name, string edition)
        {
            storage.MoveToStorage(new TheDailyNewspaper(name, edition));
        }
    }
}
