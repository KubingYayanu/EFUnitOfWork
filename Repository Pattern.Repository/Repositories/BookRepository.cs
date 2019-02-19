using Repository_Pattern.Entity;
using System.Data.Entity;

namespace Repository_Pattern.Repository
{
    public class BookRepository : GenericRepository<RepositoryPatternContext, Book>, IBookRepository
    {
        public BookRepository(IDbContextFactory contextFactory)
            : base(contextFactory)
        {
        }
    }
}