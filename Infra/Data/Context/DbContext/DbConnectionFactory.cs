using System;
using System.Data;
using System.Data.SqlClient;
using AppDapper.Infra.Data.Context.Enums;
using AppDapper.Infra.Data.Context.Interfaces;

namespace AppDapper.Infra.Data.Context.Db
{
        public static class DbConnectionFactory
    {
        public static IDbConnection Create<T>(T dbContext) where T : IDbContext
        {
            if (string.IsNullOrEmpty(dbContext.ConnectionString))
            {
                throw new ArgumentException("Значение должно быть заполнено"
                                                , nameof(dbContext.ConnectionString));
            }

            switch (dbContext.Provider)
            {
                case DatabaseProviders.SQL_SERVER:
                    return new SqlConnection(dbContext.ConnectionString);
            }

            throw new ArgumentException("Неверный драйвер базы данных");
        }
    }
}
