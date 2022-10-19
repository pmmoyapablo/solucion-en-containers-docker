using System;
using AutoMapper;
using Bluebank.Banco.Dominio.Entity;
using Bluebank.Banco.Aplicacion.Common;
using System.Threading.Tasks;

namespace Bluebank.Banco.Aplicacion.Acounts
{
  public class AcountsAplicacion
  {
    private readonly IAcountRepository _acountsRepository;
    private readonly IMapper _mapper;
    private readonly IAppLogger<AcountsAplicacion> _logger;
    public AcountsAplicacion(IAcountRepository acountsRepository, IMapper mapper, IAppLogger<AcountsAplicacion> logger)
    {
      _acountsRepository = acountsRepository;
      _mapper = mapper;
      _logger = logger;
    }

    #region Métodos Síncronos
    public Response<bool> Create(AcountDTO acountDto)
    {
      var response = new Response<bool>();
      try
      {
        var acount = _mapper.Map<Acount>(acountDto);
        //Validate on Domain
        acount.Create();
        response.Data = _acountsRepository.CreateSave(acount);
        if (response.Data)
        {
          response.IsSuccess = true;
          response.Messange = "Registro Exitoso!!!";
          _logger.LogInformation(response.Messange);
        }
      }
      catch (Exception e)
      {
        response.Messange = e.Message;
        _logger.LogError(e.Message);
      }
      return response;
    }

    public Response<AcountDTO> Get(string codeAcount)
    {
      var response = new Response<AcountDTO>();
      try
      {
        var acount = _acountsRepository.Get(codeAcount);
        response.Data = _mapper.Map<AcountDTO>(acount);
        if (response.Data != null)
        {
          response.IsSuccess = true;
          response.Messange = "Consulta Exitosa!!!";
          _logger.LogInformation(response.Messange);
        }
      }
      catch (Exception e)
      {
        response.Messange = e.Message;
        _logger.LogError(e.Message);
      }
      return response;
    }

    public Response<bool> Move(AcountDTO acountDto)
    {
      var response = new Response<bool>();
      try
      {
        double amountMove = acountDto.Amount;
        var respdata = Get(acountDto.Code);
        if(respdata.Data != null)
          acountDto = respdata.Data;

        var acount = _mapper.Map<Acount>(acountDto);
        
        //Validate on Domain
        acount.Move(amountMove);    
        
        response.Data = _acountsRepository.MoveSave(acount);
        if (response.Data)
        {
          response.IsSuccess = true;
          response.Messange = "Movimiento Exitoso!!!";
          _logger.LogInformation(response.Messange);
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

    public async Task<Response<bool>> CreateAsync(AcountDTO acountDto)
    {
      var response = new Response<bool>();
      try
      {
        var acount = _mapper.Map<Acount>(acountDto);
        //Validate on Domain
        acount.Create();
        response.Data = await _acountsRepository.CreateSaveAsync(acount);
        if (response.Data)
        {
          response.IsSuccess = true;
          response.Messange = "Registro Exitoso!!!";
          _logger.LogInformation(response.Messange);
        }
      }
      catch (Exception e)
      {
        response.Messange = e.Message;
        _logger.LogError(e.Message);
      }
      return response;
    }
    public async Task<Response<bool>> MoveAsync(AcountDTO acountDto)
    {
      var response = new Response<bool>();
      try
      {
        double amountMove = acountDto.Amount;
        var respdata = Get(acountDto.Code);
        if(respdata.Data != null)
          acountDto = respdata.Data;

        var acount = _mapper.Map<Acount>(acountDto);
        
        //Validate on Domain
        acount.Move(amountMove);    

        response.Data = await _acountsRepository.MoveSaveAsync(acount);
        if (response.Data)
        {
          response.IsSuccess = true;
          response.Messange = "Movimiento Exitoso!!!";
          _logger.LogInformation(response.Messange);
        }
      }
      catch (Exception e)
      {
        response.Messange = e.Message;
        _logger.LogError(e.Message);
      }
      return response;
    }

    public async Task<Response<AcountDTO>> GetAsync(string codeAcount)
    {
      var response = new Response<AcountDTO>();
      try
      {
        var acount = await _acountsRepository.GetAsync(codeAcount);
        response.Data = _mapper.Map<AcountDTO>(acount);
        if (response.Data != null)
        {
          response.IsSuccess = true;
          response.Messange = "Consulta Exitosa!!!";
          _logger.LogInformation(response.Messange);
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

  }
}