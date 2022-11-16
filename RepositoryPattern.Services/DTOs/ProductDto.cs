using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.Services.DTOs
{
    public class ProductDto
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public int Barcode { get; set; }
    }
}
