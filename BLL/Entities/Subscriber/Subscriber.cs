using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;
using BLL.Entities;

namespace BLL.Entities
{
    public class Subscriber : ISubscriber
    {
        #region data
        private string name;
        private string surname;
        private string homeAddress;
        public event EventHandler<IProduct> GotTheProduct;
        private List<IProduct> listOfProducts;
        #endregion
      
        #region properties
        public string Name
        {
            get { return name; }
            set
            {
                if (MyRegEx.Name.IsMatch(value))
                {
                    name = value;
                }
                else throw new MyRegException("Name");
            }
        }
        public string Surname
        {
            get { return surname; }
            set
            {
                if (MyRegEx.Surname.IsMatch(value))
                {
                    surname = value;
                }
                else throw new MyRegException("Surname");
            }
        }
        public string HomeAddress
        {
            get { return homeAddress; }
            set
            {
                if (MyRegEx.HomeAddress.IsMatch(value))
                {
                    homeAddress = value;
                }
                else throw new MyRegException("HomeAddress");
            }
        }
        #endregion

        public Subscriber(string name, string surname)
        {
            Name = name;
            Surname = surname;
            listOfProducts = new List<IProduct>();
        }
        public Subscriber(string name, string surname, string homeAddress)
            : this(name, surname)
        {
            HomeAddress = homeAddress;
        }

        public List<IProduct> GetListOfProducts()
        {
            return new List<IProduct>(listOfProducts);
        }
        public void GetProduct(IProduct product)
        {
            listOfProducts.Add(product);
            GotTheProduct?.Invoke(this, product);
        }
    }
}
