namespace Bluebank.Banco.Dominio.Entity
{
  public class Acount
  {
    public string Code { get; set; }
    public string CustomerID { get; set; }
    public double Amount { get; set; }

    public void Create()
    {
      ExceptionOfDomain.ThrowWhen(string.IsNullOrEmpty(CustomerID), "Cliente invalido");
      ExceptionOfDomain.ThrowWhen(string.IsNullOrEmpty(Code), "Cuenta invalida");
    }

    public void Move(double amountMove)
    {
      ExceptionOfDomain.ThrowWhen(string.IsNullOrEmpty(Code), "Cuenta invalida");

      Amount = Amount + amountMove;
    }
  }
}
