using AppDapper.Infra.Data.Context.Enums;
using System;
using System.Data;

namespace AppDapper.Infra.Data.Context.Interfaces
{

    public interface IDbContext : IDisposable        
    {
        DatabaseProviders Provider { get; }
        IDbConnection Connection { get; }
        string ConnectionStringName { get; }
        string ConnectionString { get; }
        IDbContext SelectContext();
    }
}
