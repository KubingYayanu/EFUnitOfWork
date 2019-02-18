using Repository_Pattern.Entity;
using System.Collections.Generic;

namespace Repository_Pattern.Repository
{
    public interface ICourseRepository : IRepository<Course>
    {
        IEnumerable<Course> GetTopSellingCoursed(int count);
        IEnumerable<Course> GetCoursesWithAuthors(int pageIndex, int pageSize);
    }
}