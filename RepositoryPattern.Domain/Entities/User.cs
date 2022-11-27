using RepositoryPattern.Domain.Entities.Abstracts;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepositoryPattern.Domain.Entities
{
    [Table("Users")]
    public class User : BaseEntity
    {
        public string UserId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}
