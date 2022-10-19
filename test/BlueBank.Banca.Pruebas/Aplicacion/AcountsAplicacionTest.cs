using Xunit;
using Bluebank.Banco.Aplicacion.Acounts;
using Bluebank.Banco.Dominio.Entity;
using AutoMapper;
using Bluebank.Banco.Aplicacion.Mapper;
using Bluebank.Banco.Aplicacion.Common;
using Bluebank.Banco.Infraestructure.Logging;
using NSubstitute;

namespace BlueBank.Banca.Pruebas.Aplicacion
{
  public class AcountsAplicacionTest
  {
    private readonly IAcountRepository _acountRepository;
    private IMapper _mapper;
    private IAppLogger<AcountsAplicacion> _logger;
    private Acount _acount;

    public AcountsAplicacionTest()
    {
      _acount = new Acount {
        Code = "902938495",
        Amount = 2000.25,
        CustomerID = "123456789"
      };

      _acountRepository = Substitute.For<IAcountRepository>();

      // Auto Mapper Configurations
      var mappingConfig = new MapperConfiguration(mc =>
      {
        mc.AddProfile(new MappingsProfile());
      });
      _mapper = mappingConfig.CreateMapper();

      //Looger
      _logger = new LoggerAdapterTesting<AcountsAplicacion>();
    }

    [Fact]
    public void Create_ArgsFine_Ok()
    {
      //Arrange
      var acountApp = new AcountsAplicacion(_acountRepository, _mapper, _logger);

      //Act
      var acountDto = _mapper.Map<AcountDTO>(_acount);

      //Assert
      acountApp.Create(Arg.Is<AcountDTO>(dto =>
                    dto == acountDto));
    }

    [Fact]
    public void Create_CuentaInvalida_Exception()
    {
      // Arrange
      var acountApp = new AcountsAplicacion(_acountRepository, _mapper, _logger);
      var acountDto = new AcountDTO();
      acountDto.CustomerID = "098393041";
      var messageExpected = "Cuenta invalida";

      //Act
      var response = acountApp.Create(acountDto);

      //Assert
      Assert.Equal(messageExpected, response.Messange);
    }

    [Fact]
    public void Move_ArgsFine_Ok()
    {
      //Arrange
      var acountApp = new AcountsAplicacion(_acountRepository, _mapper, _logger);

      //Act
      _acount.Amount = -500;
      var acountDto = _mapper.Map<AcountDTO>(_acount);

      //Assert
      acountApp.Move(Arg.Is<AcountDTO>(dto =>
                    dto == acountDto));
    }
   
    [Fact]
    public void Move_CuentaInvalida_Exception()
    {
      //System.Diagnostics.Debugger.Launch();
      // Arrange
      var acountApp = new AcountsAplicacion(_acountRepository, _mapper, _logger);
      var acountDto = new AcountDTO();
      var messageExpected = "Cuenta invalida";

      //Act
      var response = acountApp.Move(acountDto);

      //Assert
      Assert.Equal(messageExpected, response.Messange);
    }
    
    //[Fact]
    //public void Get_AcountExist_Ok()
    //{
    //  System.Diagnostics.Debugger.Launch();
    //  // Arrange
    //  var acountApp = new AcountsAplicacion(_acountRepository, _mapper, _logger);
    //  var codeAcount = "213456789";
    //  var acountDto = new AcountDTO()
    //  {
    //    Code = codeAcount,
    //    CustomerID = "14354341",
    //    Amount = 100.00
    //  };
    //  acountApp.Create(acountDto);
    //  // Act
    //  var response = acountApp.Get(codeAcount);
    //  //Assert
    //  Assert.True(response.IsSuccess);
    //}
  }
}