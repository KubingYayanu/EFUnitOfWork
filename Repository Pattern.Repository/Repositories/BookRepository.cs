using Repository_Pattern.Entity;
using System.Data.Entity;

namespace Repository_Pattern.Repository
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public BookRepository(DbContext context)
            : base(context)
        {
        }
    }
}