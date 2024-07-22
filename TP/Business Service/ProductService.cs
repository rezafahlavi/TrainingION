using BusinessServiceFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TrainingDomainModel;

namespace BusinessService
{

    public class ProductService : BaseService<DomainRepository<Product>, Product>
    {
        public ProductService() : base()
        {

        }

        public void SearchProduct(Product product)
        {
            this.Equals(product);
            this.GetBy(x => x.ProductID == product.ProductID);
            this.Save();
        }
    }
}