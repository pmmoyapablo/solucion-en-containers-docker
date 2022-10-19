using Bluebank.Banco.Dominio.Entity;
using Bluebank.Banco.Aplicacion.Acounts;
using Bluebank.Banco.Aplicacion.Common;
using Dapper;
using System.Data;
using System.Threading.Tasks;

namespace Bluebank.Banco.Infraestructure.Repository
{
  public class AcountRepository : IAcountRepository
  {

    private readonly IConnectionFactory _connectionFactory;
    public AcountRepository(IConnectionFactory connectionFactory)
    {
      _connectionFactory = connectionFactory;
    }

    #region Métodos Síncronos
    public bool CreateSave(Acount acount)
    {
      using (var connection = _connectionFactory.GetConnection)
      {
        var query = "AcountsInsert";
        var parameters = new DynamicParameters();
        parameters.Add("CustomerID", acount.CustomerID);
        parameters.Add("Code", acount.Code);
        parameters.Add("@Amount", acount.Amount);

        var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
        return result > 0;
      }
    }

    public Acount Get(string codeAcount)
    {
      using (var connection = _connectionFactory.GetConnection)
      {
        var query = "AcountsGet";
        var parameters = new DynamicParameters();
        parameters.Add("Code", codeAcount);

        var customer = connection.QuerySingle<Acount>(query, param: parameters, commandType: CommandType.StoredProcedure);
        return customer;
      }
    }

    public bool MoveSave(Acount acount)
    {
      using (var connection = _connectionFactory.GetConnection)
      {
        var query = "AcountsMove";
        var parameters = new DynamicParameters();
        parameters.Add("Code", acount.Code);
        parameters.Add("@Amount", acount.Amount);

        var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
        return result > 0;
      }
    }

    #endregion

    #region Métodos Asíncronos

    public async Task<bool> CreateSaveAsync(Acount acount)
    {
      using (var connection = _connectionFactory.GetConnection)
      {
        var query = "AcountsInsert";
        var parameters = new DynamicParameters();
        parameters.Add("CustomerID", acount.CustomerID);
        parameters.Add("Code", acount.Code);
        parameters.Add("@Amount", acount.Amount);

        var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
        return result > 0;
      }
    }
    public async Task<Acount> GetAsync(string codeAcount)
    {
      using (var connection = _connectionFactory.GetConnection)
      {
        var query = "AcountsGet";
        var parameters = new DynamicParameters();
        parameters.Add("Code", codeAcount);

        var customer = await connection.QuerySingleAsync<Acount>(query, param: parameters, commandType: CommandType.StoredProcedure);
        return customer;
      }
    }
    public async Task<bool> MoveSaveAsync(Acount acount)
    {
      using (var connection = _connectionFactory.GetConnection)
      {
        var query = "AcountsMove";
        var parameters = new DynamicParameters();
        parameters.Add("Code", acount.Code);
        parameters.Add("@Amount", acount.Amount);

        var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
        return result > 0;
      }
    }

    #endregion
  }
}