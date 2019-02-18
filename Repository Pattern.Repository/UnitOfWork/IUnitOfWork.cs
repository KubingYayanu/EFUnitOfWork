using System;

namespace Repository_Pattern.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();

        void RollBack();
    }
}