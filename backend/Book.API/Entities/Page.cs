using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Book.API.Entities
{
    public class Page
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public int PageNumber { get; set; }
        public string Content { get; set; }

        public Book Book { get; set; }

        [ForeignKey(nameof(Book))]
        public Guid BookId { get; set; }
    }
}
