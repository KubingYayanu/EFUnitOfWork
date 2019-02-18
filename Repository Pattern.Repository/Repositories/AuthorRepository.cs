using Repository_Pattern.Entity;
using System.Data.Entity;

namespace Repository_Pattern.Repository
{
    public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(DbContext context)
            : base(context)
        {
        }
    }
}