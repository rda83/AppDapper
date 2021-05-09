using AppDapper.Infra.Data.Context.Interfaces;
using System.Data;

namespace AppDapper.Infra.Context
{

    public class UnitOfWork : IUnitOfWork
    {

        public IDbContext Context { get; private set; }

        public IDbTransaction Transaction { get; private set; }

        public UnitOfWork(IDbContext context)
        {
            Context = context;
        }

        public IDbTransaction BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Snapshot)
        {
            if (Transaction == null)
            {
                Transaction = Context.Connection.BeginTransaction(isolationLevel);
            }

            return Transaction;
        }

        public void Commit()
        {
            if (Transaction != null)
            {
                Transaction.Commit();
                DisposeTransaction();
            }
        }

        public void Rollback()
        {
            if (Transaction != null)
            {
                Transaction.Rollback();
                DisposeTransaction();
            }
        }

        public void Dispose()
        {
            Rollback();
            DisposeContext();
        }

        private void DisposeContext()
        {
            if (Context != null)
            {
                Context.Dispose();
                Context = null;
            }
        }

        private void DisposeTransaction()
        {
            Transaction.Dispose();
            Transaction = null;
        }
    }
}
