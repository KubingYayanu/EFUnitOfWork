using System;
using System.Data.Entity;
using System.Linq;

namespace Repository_Pattern.Repository
{
    public class UnitOfWork<TDbContext> : IUnitOfWork
    {
        private DbContext _context { get; }
        private bool _disposed;

        public UnitOfWork(
            IDbContextFactory contextFactory)
        {
            _context = contextFactory.GetDbContext<TDbContext>();
            Course = new CourseRepository(_context);
            Author = new AuthorRepository(_context);
            Book = new BookRepository(_context);
        }

        public ICourseRepository Course { get; private set; }
        public IAuthorRepository Author { get; private set; }
        public IBookRepository Book { get; private set; }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public void RejectChanges()
        {
            foreach (var entry in _context.ChangeTracker.Entries()
              .Where(e => e.State != EntityState.Unchanged))
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;

                    case EntityState.Modified:
                    case EntityState.Deleted:
                        entry.Reload();
                        break;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }

            _disposed = true;
        }
    }
}