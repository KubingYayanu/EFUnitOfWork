using System.Data.Entity;

namespace Repository_Pattern.Entity
{
    public class RepositoryPatternContext : DbContext
    {
        public RepositoryPatternContext()
            : base("name=RepositoryPattern")
        {
        }

        public virtual DbSet<Course> Course { get; set; }

        public virtual DbSet<Author> Author { get; set; }

        public virtual DbSet<Book> Book { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}