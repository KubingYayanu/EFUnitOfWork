using Repository_Pattern.Entity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Repository_Pattern.Repository
{
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        public CourseRepository(DbContext context)
            : base(context)
        {
        }

        public IEnumerable<Course> GetCoursesWithAuthors(int pageIndex, int pageSize)
        {
            return _dbSet.Include(x => x.Author)
                .OrderBy(x => x.Name)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public IEnumerable<Course> GetTopSellingCoursed(int count)
        {
            return _dbSet.OrderByDescending(x => x.FullPrice).Take(count).ToList();
        }
    }
}