using RepositoryPattern.Domain.Entities;
using System.Collections.Generic;

namespace RepositoryPattern.Services.Abstracts
{
    public interface IProductService
    {
        public IEnumerable<Product> GetAll();
        public void Add(Product product);
        public void Update(Product product);
        public void Delete(Product product);
        public void HardDelete(Product product);
        public void GetById(int Id);

    }
}
