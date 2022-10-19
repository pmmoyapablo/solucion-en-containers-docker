using GenFu;
using Moq;
using Xunit;
using Bluebank.Banco.Aplicacion.Customers;
using Bluebank.Banco.Dominio.Entity;
using AutoMapper;
using Bluebank.Banco.Aplicacion.Mapper;
using Bluebank.Banco.Aplicacion.Common;
using Bluebank.Banco.Infraestructure.Logging;

namespace BlueBank.Banca.Pruebas.Aplicacion
{
  public class CustomersApplicationTest
  {
    private static Mock<ICustomersRepository> _repositoryMock;
    private IMapper _mapper;
    private IAppLogger<CustomersApplication> _logger;
    public CustomersApplicationTest()
    {
      //Repository
      _repositoryMock = new Mock<ICustomersRepository>();
      //Simulacion para listar con Data Dummie Casi Real
      A.Configure<Customer>()
                .Fill(x => x.ContactName).AsFirstName()
                .Fill(x => x.ContactTitle).AsArticleTitle()
                .Fill(x => x.City).AsCity()
                .Fill(x => x.Country).AsCanadianProvince()
                .Fill(x => x.Country, () => { return "Canada"; })
                .Fill(x => x.Phone).AsPhoneNumber()
                .Fill(x => x.Fax).AsPhoneNumber()
                .Fill(x => x.CustomerId).AsTwitterHandle()
                .Fill(x => x.Address).AsAddress()
                .Fill(x => x.PostalCode, () => { return "1235"; });

      var listCustomers = A.ListOf<Customer>(30);
      listCustomers[0].CustomerId = "000000000";

      _repositoryMock.Setup(a => a.GetAll()).Returns(listCustomers);
      //Simulacion para Insert si Aplicase sin tipo retorno
      //_repositoryMock.Setup(a => a.SaveCustomer(It.IsAny<Customer>()));
      //Simulacion para Update si Aplicase con tipo de retorno
      //_repositoryMock.Setup(a => a.UpdateCustomer(It.IsAny<Customer>())).Returns(1);

      // Auto Mapper Configurations
      var mappingConfig = new MapperConfiguration(mc =>
      {
        mc.AddProfile(new MappingsProfile());
      });
      _mapper = mappingConfig.CreateMapper();

      //Looger
      _logger = new LoggerAdapterTesting<CustomersApplication>();
  }

    [Fact]
    public void GetAll_Fine_Ok()
    {
      //System.Diagnostics.Debugger.Launch();

      //Arrange    
      var customerApp = new CustomersApplication(_repositoryMock.Object, _mapper, _logger);

      //Act
      var listCustomers = customerApp.GetAll();

      //Assert
      Assert.True(listCustomers.IsSuccess);
    }
  }
}