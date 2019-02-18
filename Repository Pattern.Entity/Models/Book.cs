using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository_Pattern.Entity
{
    [Table("Books")]
    public class Book
    {
        [Key]
        public int ID { get; set; }

        public string Title { get; set; }

        public int AuthorID { get; set; }

        [ForeignKey("AuthorID")]
        public virtual Author Author { get; set; }
    }
}