using AutoMapper;
using RepositoryPattern.Data.Abstracts;
using RepositoryPattern.Domain.Entities;
using RepositoryPattern.Services.Abstracts;
using RepositoryPattern.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.Services.Concretes
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> repository;
        private readonly ICacheService cacheService;
        private const string cacheKey = "UserCacheKey";
        private readonly IMapper mapper;

        public UserService(IRepository<User> _repository, ICacheService _cacheService, IMapper _mapper)
        {
            repository = _repository;
            cacheService = _cacheService;
            mapper = _mapper;
        }
        public void Add(UserDTO userDTO)
        {
            var user = mapper.Map<User>(userDTO);
            var cachedList = repository.Add(user); 
            cacheService.Remove(cacheKey);
            cacheService.Set(cacheKey, cachedList);
        }

        public List<User> GetAllUsers()
        {
            var userList = repository.GetAll().ToList();
            cacheService.Set(cacheKey, userList);                    
            cacheService.TryGet<User>(cacheKey, out userList);     
            return userList;
        }
    }
}
