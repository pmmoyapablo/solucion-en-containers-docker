using System;
using System.Threading.Tasks;
using Bluebank.Banco.Dominio;
using Xunit;

namespace BlueBank.Banca.Pruebas
{
  public class AssertExtensions
  {
    public static void ThrowsWithMessage(Action testCode, string messageExpected)
    {
      var message = Assert.Throws<ExceptionOfDomain>(testCode).Message;
      Assert.Equal(messageExpected, message);
    }

    public static void ThrowsWithMessageAsync(Func<Task> testCode, string messageExpected)
    {
      var result = Assert.ThrowsAsync<ExceptionOfDomain>(testCode).Result;
      Assert.Equal(messageExpected, result.Message);
    }
  }
}