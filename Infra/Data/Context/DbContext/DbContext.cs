using Microsoft.Extensions.Configuration;
using System.Data;
using AppDapper.Infra.Data.Context.Enums;
using AppDapper.Infra.Data.Context.Interfaces;

namespace AppDapper.Infra.Data.Context.Db
{

    public abstract class DbContext : IDbContext
    {

        private readonly IConfiguration configuration;

        public IDbConnection Connection { get; protected set; }

        public DatabaseProviders Provider { get; protected set; }

        public string ConnectionStringName { get; protected set; }

        public string ConnectionString { get; private set; }
        
        public DbContext(IConfiguration configuration) => this.configuration = configuration;
        
        public IDbContext SelectContext()
        {
            ConnectDatabase();

            if (Connection.State != ConnectionState.Open)
            {
                Connection.Open();
            }

            return this;
        }
        
        public void Dispose()
        {
            if (Connection != null && Connection.State == ConnectionState.Open)
            {
                Connection.Close();
            }

            Connection?.Dispose();
        }
       
        private void ConnectDatabase()
        {
            ConnectionString = configuration.GetConnectionString(ConnectionStringName);
            this.Connection = this.Connection ?? DbConnectionFactory.Create(this);
        }
    }
}
