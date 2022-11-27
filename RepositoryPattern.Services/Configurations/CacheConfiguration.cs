using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.Services.Configurations
{
    public class CacheConfiguration
    {
        public int AbsoluteExpirationInHours { get; set; } // cache'in hayatta kalacağı süre
        public int SlidingExpirationInMinutes { get; set; } // cache'in kullanılmadığı zaman otomatik olarak silinmesi için 
    }
}
