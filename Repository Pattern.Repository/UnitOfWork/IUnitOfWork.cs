using System;

namespace Repository_Pattern.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        ICourseRepository Course { get; }
        IAuthorRepository Author { get; }
        IBookRepository Book { get; }

        int Commit();

        void RejectChanges();
    }
}