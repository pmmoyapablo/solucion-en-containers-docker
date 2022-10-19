namespace Bluebank.Banco.Aplicacion.Common
{
  public class Response<T>
  {
    public T Data { get; set; }
    public bool IsSuccess { get; set; }
    public string Messange { get; set; }
  }
}