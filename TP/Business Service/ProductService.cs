using BusinessServiceFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingDomainModel;

namespace BusinessService
{

    public class ProductService : BaseService <ProductRepository,Product>
    {
        public ProductService() : base()
        { 
        
        }

        public void SearchProduct(Product product)
        {
            this.Equals(product);
            this.Repository.SearchProduct(product);
            this.Save();
        }
    }
}
