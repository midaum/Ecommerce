using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Product;

namespace Application.Abstractions.Interfaces
{
    public interface IProductRepository
    {
        void Add(Domain.Product.Product product);
        Domain.Product.Product GetProductById(Guid productId);
        void Update(Domain.Product.Product product);
        List<Domain.Product.Product> GetAllProducts();
        void CreateProduct(Domain.Product.Product product);


    }
}
