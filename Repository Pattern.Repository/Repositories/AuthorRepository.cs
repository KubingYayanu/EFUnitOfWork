using Repository_Pattern.Entity;
using System.Data.Entity;

namespace Repository_Pattern.Repository
{
    public class AuthorRepository : GenericRepository<RepositoryPatternContext, Author>, IAuthorRepository
    {
        public AuthorRepository(IDbContextFactory contextFactory)
            : base(contextFactory)
        {
        }
    }
}