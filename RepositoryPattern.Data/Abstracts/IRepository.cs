using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace RepositoryPattern.Data.Abstracts
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> Get();
        IQueryable<T> GetAll(Expression<Func<T, bool>>predicate=null);
        List<T> Add(T entity); // Ekleme
        void Update(T entity); // Güncelleme
        void Delete(T entity); // Silme
        void HardDelete(T entity); // Veri tabanını komple silme
        void GetById(int id);
        int Save();

    }
}
