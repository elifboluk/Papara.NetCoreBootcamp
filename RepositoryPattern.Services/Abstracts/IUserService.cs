using RepositoryPattern.Domain.Entities;
using RepositoryPattern.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.Services.Abstracts
{
    public interface IUserService
    {
        void Add(UserDTO user);
        List<User> GetAllUsers();
    }
}
