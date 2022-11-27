using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Data.Abstracts;
using RepositoryPattern.Data.Context;
using RepositoryPattern.Domain.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.Data.Concretes
{
    public class Repository<T> : IRepository<T> where T : BaseEntity // T, type Base Entity'den türeyecek.
    {
        public readonly AppDbContext _context;
        public DbSet<T> _table;
        public Repository(AppDbContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }
        public List<T> Add(T entity)
        {
            entity.Id = 0;
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _table.Add(entity);
            this.Save();
            var cachedList = _table.ToList();
            return cachedList;
        }

        public void Delete(T entity)
        {
            T existData = _table.Find(entity.Id);
            if (existData != null)
            {
                existData.IsDeleted = true;
                _context.Entry(existData).State = EntityState.Modified;
                this.Save();
            }
        }

        public IQueryable<T> Get()
        {
            return _table.Where(x => !x.IsDeleted).AsQueryable();
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate = null)
        {
            return predicate == null ? _table : _table.Where(predicate);
        }

        public void HardDelete(T entity)
        {
            T existData = _table.Find(entity.Id);
            if (existData != null)
            {
                _table.Remove(existData);
                this.Save();
            }
        }

        public virtual int Save()
        {
            return _context.SaveChanges();
        }

        public void GetById(int id)
        {
            _table.Find(id);
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            this.Save();            
        }
    }
}
