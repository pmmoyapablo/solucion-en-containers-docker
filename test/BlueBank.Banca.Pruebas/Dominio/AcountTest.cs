using Xunit;
using Bluebank.Banco.Dominio.Entity;

namespace BlueBank.Banca.Pruebas.Dominio
{
  public class AcountTest
  {
    [Fact]
    public void Create_FineArgs_Ok()
    {
      //Arrange
      var acount = new Acount();
      acount.CustomerID = "14526461";
      acount.Code = "120029300";

      //Act y Assert
      acount.Create();
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void Create_ClienteInvalid_Exception(string customerID)
    {
      //Arrange
      const string messageExpected = "Cliente invalido";
      var acount = new Acount();
      acount.CustomerID = customerID;
      acount.Code = "120029300";

      //Act y Assert
      AssertExtensions.ThrowsWithMessage(() => acount.Create(), messageExpected);
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void Create_CodeInvalid_Exception(string code)
    {
      //Arrange
      const string messageExpected = "Cuenta invalida";
      var acount = new Acount();
      acount.CustomerID = "14526461";
      acount.Code = code;

      //Act y Assert
      AssertExtensions.ThrowsWithMessage(() => acount.Create(), messageExpected);
    }

    [Fact]
    public void Move_FineArgs_Ok()
    {
      //Arrange
      var amountExpected = 50;
      var acount = new Acount();
      acount.CustomerID = "14526461";
      acount.Code = "120029300";
      acount.Amount = 100;

      //Act
      acount.Move(-50);

      //Assert
      Assert.Equal(amountExpected, acount.Amount);
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void Move_CodeInvalid_Exception(string code)
    {
      //Arrange
      const string messageExpected = "Cuenta invalida";
      var acount = new Acount();
      acount.CustomerID = "14526461";
      acount.Code = code;

      //Act y Assert
      AssertExtensions.ThrowsWithMessage(() => acount.Move(0), messageExpected);
    }
  }
}