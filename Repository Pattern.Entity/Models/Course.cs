using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository_Pattern.Entity
{
    [Table("Course")]
    public class Course
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; set; }

        public int FullPrice { get; set; }

        public int AuthorID { get; set; }

        [ForeignKey("AuthorID")]
        public Author Author { get; set; }
    }
}