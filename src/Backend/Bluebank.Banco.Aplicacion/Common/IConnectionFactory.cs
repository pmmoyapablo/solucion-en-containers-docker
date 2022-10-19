using System.Data;

namespace Bluebank.Banco.Aplicacion.Common
{
  public interface IConnectionFactory
  {
    IDbConnection GetConnection { get; }
  }
}
