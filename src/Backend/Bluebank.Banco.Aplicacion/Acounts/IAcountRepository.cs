using Bluebank.Banco.Dominio.Entity;
using System.Threading.Tasks;

namespace Bluebank.Banco.Aplicacion.Acounts
{
  public interface IAcountRepository
  {
    #region Métodos Síncronos

    bool CreateSave(Acount acount);
    bool MoveSave(Acount acount);
    Acount Get(string codeAcount);

    #endregion

    #region Métodos Asíncronos

    Task<bool> CreateSaveAsync(Acount acount);
    Task<bool> MoveSaveAsync(Acount acount);
    Task<Acount> GetAsync(string codeAcount);

    #endregion
  }
}