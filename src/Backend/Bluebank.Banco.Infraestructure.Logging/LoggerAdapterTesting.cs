using Bluebank.Banco.Aplicacion.Common;
using System;

namespace Bluebank.Banco.Infraestructure.Logging
{
  public class LoggerAdapterTesting<T> : IAppLogger<T>
  {
    public void LogError(string message, params object[] args)
    {
      Console.WriteLine("ERROR: " + message, args);
    }

    public void LogInformation(string message, params object[] args)
    {
      Console.WriteLine("INFO: " + message, args);
    }

    public void LogWarning(string message, params object[] args)
    {
      Console.WriteLine("MARNING: " + message, args);
    }
  }
}