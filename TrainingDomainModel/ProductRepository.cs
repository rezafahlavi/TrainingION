using DomainModelFramework;
using DomainModelFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;


namespace TrainingDomainModel
{
    public class ProductRepository : DomainRepository<Product> 
    {
        public ProductRepository()
        {
        }
        public void SearchProduct(Product product)
        {
            this._context.Entry(product.ProductID).State = EntityState.Detached;//Ini yg bener supaya bisa search ISINYA APA??????
        }

    }
}
