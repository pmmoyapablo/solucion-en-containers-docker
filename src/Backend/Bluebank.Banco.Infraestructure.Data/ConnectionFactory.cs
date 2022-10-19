using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Bluebank.Banco.Aplicacion.Common;
using System.Data;
using System;

namespace Bluebank.Banco.Infraestructure.Data
{
  public class ConnectionFactory : IConnectionFactory
  {
    private readonly IConfiguration _configuration;

    public ConnectionFactory(IConfiguration configuration)
    {
      _configuration = configuration;
    }

    public IDbConnection GetConnection
    {
      get
      {
        var sqlConnection = new SqlConnection();
        if (sqlConnection == null) return null;
        var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
        sqlConnection.ConnectionString = String.IsNullOrEmpty(connectionString)? _configuration.GetConnectionString("BlueBankConnection") : connectionString;
        sqlConnection.Open();
        return sqlConnection;
      }
    }
  }
}