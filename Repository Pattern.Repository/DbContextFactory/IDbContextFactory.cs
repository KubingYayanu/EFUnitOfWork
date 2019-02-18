using System;
using System.Data.Entity;

namespace Repository_Pattern.Repository
{
    public interface IDbContextFactory
    {
        DbContext GetDbContext(Type contextType);

        DbContext GetDbContext<T>();

        void Clear();
    }
}