using System;
using AutoMapper;
using System.Collections.Generic;
using Bluebank.Banco.Aplicacion.Common;
using System.Threading.Tasks;

namespace Bluebank.Banco.Aplicacion.Customers
{
  public class CustomersApplication
  {
    private readonly IMapper _mapper;
    private readonly IAppLogger<CustomersApplication> _logger;
    private ICustomersRepository _customersRepository;
    public CustomersApplication(ICustomersRepository customersRepository, IMapper mapper, IAppLogger<CustomersApplication> logger)
    {
      _mapper = mapper;
      _logger = logger;
      _customersRepository = customersRepository;
    }

    #region Métodos Síncronos

    public Response<IEnumerable<CustomerDTO>> GetAll()
    {
      var response = new Response<IEnumerable<CustomerDTO>>();
      try
      {
        var customers = _customersRepository.GetAll();
        response.Data = _mapper.Map<IEnumerable<CustomerDTO>>(customers);
        if (response.Data != null)
        {
          response.IsSuccess = true;
          response.Messange = "Consulta Exitosa!!!";
          _logger.LogInformation("Consulta Exitosa!!!");
        }
      }
      catch (Exception e)
      {
        response.Messange = e.Message;
        _logger.LogError(e.Message);
      }
      return response;
    }

    #endregion

    #region Métodos Asíncronos

    public async Task<Response<IEnumerable<CustomerDTO>>> GetAllAsync()
    {
      var response = new Response<IEnumerable<CustomerDTO>>();
      try
      {
        var customers = await _customersRepository.GetAllAsync();
        response.Data = _mapper.Map<IEnumerable<CustomerDTO>>(customers);
        if (response.Data != null)
        {
          response.IsSuccess = true;
          response.Messange = "Consulta Exitosa!!!";
        }
      }
      catch (Exception e)
      {
        response.Messange = e.Message;
      }
      return response;
    }
    #endregion

  }
}