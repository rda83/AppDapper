using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AppDapper.Infra.Data.Context.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IDbContext Context { get; }
        IDbTransaction Transaction { get; }
        IDbTransaction BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Snapshot);
        void Commit();
        void Rollback();
    }
}
