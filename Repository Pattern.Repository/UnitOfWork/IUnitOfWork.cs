using System;

namespace Repository_Pattern.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        void BeginTransaction();

        void Commit();

        void RollBack();
    }
}