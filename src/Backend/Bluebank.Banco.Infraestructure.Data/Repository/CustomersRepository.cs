using Bluebank.Banco.Dominio.Entity;
using Bluebank.Banco.Aplicacion.Customers;
using Bluebank.Banco.Aplicacion.Common;
using Dapper;
using System.Data;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Bluebank.Banco.Infraestructure.Repository
{
  public class CustomersRepository : ICustomersRepository
  {
    private readonly IConnectionFactory _connectionFactory;
    public CustomersRepository(IConnectionFactory connectionFactory)
    {
      _connectionFactory = connectionFactory;
    }

    #region Métodos Síncronos        

    public IEnumerable<Customer> GetAll()
    {
      using (var connection = _connectionFactory.GetConnection)
      {
        var query = "CustomersList";

        var customers = connection.Query<Customer>(query, commandType: CommandType.StoredProcedure);
        return customers;
      }
    }

    #endregion

    #region Métodos Asíncronos

    public async Task<IEnumerable<Customer>> GetAllAsync()
    {
      using (var connection = _connectionFactory.GetConnection)
      {
        var query = "CustomersList";

        var customers = await connection.QueryAsync<Customer>(query, commandType: CommandType.StoredProcedure);
        return customers;
      }
    }

    #endregion
  }
}