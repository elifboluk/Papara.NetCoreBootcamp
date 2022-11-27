using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using RepositoryPattern.Services.Abstracts;
using RepositoryPattern.Services.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.Services.Concretes
{
    public class CacheService : ICacheService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly CacheConfiguration _cacheConfig;
        private MemoryCacheEntryOptions _cacheOptions;


        public CacheService(IMemoryCache memoryCache, IOptions<CacheConfiguration> cacheConfig)
        {
            _memoryCache = memoryCache;
            _cacheConfig = cacheConfig.Value;
            if (_cacheConfig != null)
            {
                _cacheOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.Now.AddHours(_cacheConfig.AbsoluteExpirationInHours),
                    Priority = CacheItemPriority.High,
                    SlidingExpiration = TimeSpan.FromMinutes(_cacheConfig.SlidingExpirationInMinutes)
                };
            }
        }
        public bool TryGet<T>(string cacheKey, out List<T> value)
        {
            _memoryCache.TryGetValue(cacheKey, out value);
            if (value == null) return false;
            else return true;
        }

        public T Set<T>(string cacheKey, T value)
        {
            return _memoryCache.Set(cacheKey, value, _cacheOptions);
        }

        public void Remove(string cacheKey)
        {
            _memoryCache.Remove(cacheKey);
        }
    }
}

// IMemoryCache: core projelerinde in-memory cache kullanmamızı sağlayan arayüzün adıdır. Bu interface'e ait metotları vs. kullanarak cache set, get, remove gibi işlemleri yapabiliriz.

// CacheConfiguration: Benim oluşturduğum cache'in ne kadar süre hayatta kalacağı ile ilgili olan configuration'ları içeriyor.

// MemoryCacheEntryOptions: Kullacağım ilgili cache'in ekleme çıkarma işlemlerini kullanacağı class'tır. Ne kadar hayatta kalacağını söyler.

// IOptions: İlgili appsetting'den section'a göre veri getiren interface'tir.

// AbsoluteExpiration : Cache'in ne kadara süre hayatta kalacağını söyleyen property.

// SlidingExpiration: Cache kullanılmazsa silinecek süreyi söyleyen property.
