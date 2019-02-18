using System;
using System.Data.Entity;

namespace Repository_Pattern.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext _context { get; }
        private DbContextTransaction _transaction { get; }
        private bool _disposed;

        public UnitOfWork(DbContext context)
        {
            _context = context;
            _transaction = _context.Database.BeginTransaction();
        }

        public void Commit()
        {
            _transaction.Commit();
        }

        public void RollBack()
        {
            _transaction.Rollback();
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