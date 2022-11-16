using System;

namespace OwnerAPI.Models
{
    public class Owner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }
        public string Type { get; set; }
    }
}
    