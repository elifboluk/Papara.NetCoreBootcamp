using RepositoryPattern.Data.Abstracts;
using RepositoryPattern.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace RepositoryPattern.Data.Concretes
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IDapperRepository dapperRepository)
        {
            Products = dapperRepository;
          
        }

        public IDapperRepository Products { get;  }
    }
}
