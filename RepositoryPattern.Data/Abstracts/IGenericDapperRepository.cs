using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.Data.Abstracts
{
    public interface IGenericDapperRepository<T> where T : class 
    {
        Task<T> GetById(int id);
        Task<IReadOnlyList<T>> GetAll();
        Task<int> DapperAdd(T entity); // Ekleme
        Task<int> DapperUpdate(T entity); // Güncelleme
        Task<int> DapperDelete(int id); // Silme
        
    }
}
