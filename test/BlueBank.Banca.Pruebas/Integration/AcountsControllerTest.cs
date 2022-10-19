using Xunit;
using FluentAssertions;
using Bluebank.Banco.Aplicacion.Acounts;
using System.Net.Http.Formatting;
using System.Net.Http;
using System;

namespace BlueBank.Banca.Pruebas.Integration
{
  public class AcountsControllerTest : IntegrationBuilder
  { 
    [Fact]
    public async void Create_ArgsFine_Ok200()
    {
      //Arreange
      var codeExpected = 200;
      var dtoNewAcount = new
      {
        Code = "10030" + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Millisecond.ToString(),
        CustomerID = "10004",
        Amount = 300
      };

      //Act
      var petition = await this.TestClient.PostAsync("api/Acounts/Create", dtoNewAcount, new JsonMediaTypeFormatter());
      var code = (int)petition.StatusCode;

      //Assert
      Assert.Equal(codeExpected, code);
    }

    [Fact]
    public async void Create_ArgsNull_BadRequest400()
    {
      //Arreange
      var codeExpected = 400;
      AcountDTO dtoNewAcount = null;

      //Act
      var petition = await this.TestClient.PostAsync("api/Acounts/Create", dtoNewAcount, new JsonMediaTypeFormatter());
      var code = (int)petition.StatusCode;

      //Assert
      Assert.Equal(codeExpected, code);
    }

    [Fact]
    public async void Create_CustomerIdInExist_Error400()
    {
      //Arreange
      var codeExpected = 400;
      var dtoNewAcount = new
      {
        Code = "10030" + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Millisecond.ToString(),
        CustomerID = "A9999",
        Amount = 100
      };

      //Act
      var petition = await this.TestClient.PostAsync("api/Acounts/Create", dtoNewAcount, new JsonMediaTypeFormatter());
      var code = (int)petition.StatusCode;

      //Assert
      Assert.Equal(codeExpected, code);
    }

    [Fact]
    public async void Move_ArgsFine_Ok200()
    {
      //Arreange
      var codeExpected = 200;
      var codeAle = "20030" + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Millisecond.ToString();
      var dtoNewAcount = new
      {
        Code = codeAle,
        CustomerID = "10002",
        Amount = 300
      };
      var dtoUpAcount = new
      {
        Code = codeAle,
        CustomerID = "10002",
        Amount = 100
      };
      await this.TestClient.PostAsync("api/Acounts/Create", dtoNewAcount, new JsonMediaTypeFormatter());

      //Act
      var petition = await this.TestClient.PutAsync("api/Acounts/Move", dtoUpAcount, new JsonMediaTypeFormatter());
      var code = (int)petition.StatusCode;

      //Assert
      Assert.Equal(codeExpected, code);
    }

    [Fact]
    public async void Move_AcountInExist_Error400()
    {
      //Arreange
      var codeExpected = 400;
     
      var dtoUpAcount = new
      {
        Code = "BCD9900012",
        CustomerID = "10002",
        Amount = 100
      };

      //Act 
      var petition = await this.TestClient.PutAsync("api/Acounts/Move", dtoUpAcount, new JsonMediaTypeFormatter());     
      var code = (int)petition.StatusCode;

      //Assert
      Assert.Equal(codeExpected, code);
    }

    [Fact]
    public async void Get_AcountFine_Ok200()
    {
      //System.Diagnostics.Debugger.Launch();
      //Arreange
      var messageExpected = "Consulta Exitosa!!!";
      var codeAle = "30030" + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Millisecond.ToString();
      var dtoNewAcount = new
      {
        Code = codeAle,
        CustomerID = "12345",
        Amount = 300
      };
      await this.TestClient.PostAsync("api/Acounts/Create", dtoNewAcount, new JsonMediaTypeFormatter());
      //Retardador por la asincronicidad
      System.Threading.Thread.Sleep(1000);

      //Act
      var petition = await this.TestClient.GetAsync("api/Acounts/Get/" + codeAle);
      var response = petition.Content.ReadAsStringAsync().Result;
      var respuestaConsulta = System.Text.Json.JsonSerializer.Deserialize<RespuestaConsultaDto>(response);

      //Assert
      respuestaConsulta.Messange.Should().Be(messageExpected);
    } 
    
  }
}