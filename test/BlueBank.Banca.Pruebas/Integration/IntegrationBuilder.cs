using System;
using System.Net.Http;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace BlueBank.Banca.Pruebas.Integration
{
  public class IntegrationBuilder : IDisposable
  {
    protected HttpClient TestClient;
    private bool Disposed;

    public IntegrationBuilder()
    {
      BootstrapTestingSuite();
    }
    protected void BootstrapTestingSuite()
    {
      Disposed = false;
     
      TestServer testServer = new TestServer(new WebHostBuilder()
                 .ConfigureAppConfiguration((context, builder) =>
                 {
                   builder.AddJsonFile("appsettings.Test.json");
                 })
                 .UseStartup<Bluebank.Banco.WebApi.Startup>());

      TestClient = testServer.CreateClient();
    }
    public void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    }
    protected virtual void Dispose(bool disposing)
    {
      if (Disposed)
        return;

      if (disposing)
      {
        TestClient.Dispose();
      }

      Disposed = true;
    }
  }

  public class RespuestaConsultaDto
  {
    [JsonPropertyName("data")]
    public object Data { get; set; }

    [JsonPropertyName("messange")]
    public string Messange { get; set; }

    [JsonPropertyName("isSuccess")]
    public bool IsSuccess { get; set; }
  }
}