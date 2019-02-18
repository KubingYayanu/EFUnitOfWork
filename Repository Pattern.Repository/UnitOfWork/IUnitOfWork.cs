using System;

namespace Repository_Pattern.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        int Commit();

        void RollBack();
    }
}