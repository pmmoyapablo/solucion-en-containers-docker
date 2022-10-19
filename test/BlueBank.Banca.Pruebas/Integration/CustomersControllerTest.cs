using Xunit;
using FluentAssertions;

namespace BlueBank.Banca.Pruebas.Integration
{
  public class CustomersControllerTest : IntegrationBuilder
  { 
    [Fact]
    public async void GetAll_Fine_Ok200()
    {
      //Arreange
      var messageExpected = "Consulta Exitosa!!!";

      //Act
      var petition = await this.TestClient.GetAsync("api/Customers/GetAll");
      var response = petition.Content.ReadAsStringAsync().Result;
      var respuestaConsulta = System.Text.Json.JsonSerializer.Deserialize<RespuestaConsultaDto>(response);

      //Assert
      respuestaConsulta.Messange.Should().Be(messageExpected);
    }
    	
  }
}