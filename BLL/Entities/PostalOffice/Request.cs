using BLL.Interfaces;

namespace BLL.Entities
{
    public class Request 
    {
        public ISubscriber subscriber { get; internal set; } 
     
        public IProductData productData { get; internal set; }

        public Request(ISubscriber sub, IProductData product)
        {
            this.subscriber = sub;
            productData = product;
        }
    }
}
