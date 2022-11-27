using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.Services.Abstracts
{
    public interface ICacheService
    {
        bool TryGet<T>(string cacheKey, out List<T> value);
        T Set<T>(string cacheKey, T value);
        void Remove(string cacheKey);
    }

    // TryGet: cache varsa getirir true, yoksa false döner. 
    // Set: cache'lemek için kullanılan metod
    // Remove: cache'i silmek için kullandığımız method. 
}
