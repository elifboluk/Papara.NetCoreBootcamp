using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.Data.Abstracts
{
    public interface IUnitOfWork
    {
        IDapperRepository Products { get; }
    }
}
