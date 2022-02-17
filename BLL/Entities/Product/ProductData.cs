using BLL.Interfaces;

namespace BLL.Entities
{
    public class ProductData : IProductData
    {
        public string Name { get; set; }
        public string EditionNumber { get; set; }

        public ProductData(string name, string editionNimber)
        {
            Name = name;
            EditionNumber = editionNimber;
        }
    }
}
