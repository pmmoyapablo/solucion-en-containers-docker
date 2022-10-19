using System.Collections.Generic;
using Bluebank.Banco.Dominio.Entity;
using System.Threading.Tasks;

namespace Bluebank.Banco.Aplicacion.Customers
{
  public interface ICustomersRepository
  {
    #region Métodos Síncronos
    IEnumerable<Customer> GetAll();

    #endregion

    #region Métodos Asíncronos
    Task<IEnumerable<Customer>> GetAllAsync();

    #endregion
  }
}