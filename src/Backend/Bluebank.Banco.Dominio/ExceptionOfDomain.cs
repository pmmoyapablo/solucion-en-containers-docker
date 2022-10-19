using System;

namespace Bluebank.Banco.Dominio
{
  public class ExceptionOfDomain : Exception
  {
    public ExceptionOfDomain(string message)
      : base(message)
    { }
    public static void ThrowWhen(bool ruleInvalid, string message)
    {
      if (ruleInvalid)
        throw new ExceptionOfDomain(message);
    }
  }
}