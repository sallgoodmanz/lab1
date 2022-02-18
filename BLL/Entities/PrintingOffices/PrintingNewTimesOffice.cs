using BLL.Interfaces;

namespace BLL.Entities
{
    public class PrintinNewTimesOffice : IPrintingOffice
    {
        private IStorage storage;

        public PrintinNewTimesOffice(IStorage storage)
        {
            this.storage = storage;
        }

        public IStorage GetStorage()
        {
            return storage;
        }

        public void printMagazine(string name, string edition)
        {
            storage.MoveToStorage(new NewTimesMagazine(name, edition));
        }

        public void printNewspaper(string name, string edition)
        {
            storage.MoveToStorage(new NewTimesNewspaper(name, edition));
        }
    }
}
