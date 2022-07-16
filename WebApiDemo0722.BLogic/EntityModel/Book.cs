using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiDemo0722.BLogic.EntityModel
{
    [Table("Books")]
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
