using Microsoft.Extensions.Configuration;
using AppDapper.Infra.Data.Context.Enums;

namespace AppDapper.Infra.Data.Context.Db
{
    public sealed class SqlServerContext : DbContext
    {
        public SqlServerContext(IConfiguration configuration) : base(configuration)
        {
            this.Provider = DatabaseProviders.SQL_SERVER;
            this.ConnectionStringName = "DefaultConnection";
        }
    }
}