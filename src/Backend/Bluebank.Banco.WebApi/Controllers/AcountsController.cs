using Microsoft.AspNetCore.Mvc;
using Bluebank.Banco.Aplicacion.Acounts;
using System.Threading.Tasks;

namespace Bluebank.Banco.WebApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AcountsController : Controller
  {
    private readonly AcountsAplicacion _acountsApplication;
    public AcountsController(AcountsAplicacion acountsApplication)
    {
      _acountsApplication = acountsApplication;
    }

    #region "Métodos Sincronos"
    /// <summary>
    /// Crea una Nueva Cuenta de Ahorro
    /// </summary>
    /// <param name="acountDto">Datos de la cuenta</param>
    /// <returns></returns>
    [HttpPost("Create")]
    public IActionResult Create([FromBody] AcountDTO acountDto)
    {
      if (acountDto == null)
        return BadRequest();
      var response = _acountsApplication.Create(acountDto);
      if (response.IsSuccess)
        return Ok(response);

      return BadRequest(response.Messange);
    }
    /// <summary>
    /// Hace Movimientos en una Cuenta de Ahorro
    /// </summary>
    /// <param name="acountDto">Datos de la cuenta</param>
    /// <returns></returns>
    [HttpPut("Move")]
    public IActionResult Move([FromBody] AcountDTO acountDto)
    {
      if (acountDto == null)
        return BadRequest();
      var response = _acountsApplication.Move(acountDto);
      if (response.IsSuccess)
        return Ok(response);

      return BadRequest(response.Messange);
    }

    /// <summary>
    /// Consulta una Cuenta de Ahorro
    /// </summary>
    /// <param name="codeAcount">Nro de la cuenta a consultar</param>
    /// <returns></returns>
    [HttpGet("Get/{codeAcount}")]
    public IActionResult Get(string codeAcount)
    {
      if (string.IsNullOrEmpty(codeAcount))
        return BadRequest();
      var response = _acountsApplication.Get(codeAcount);
      if (response.IsSuccess)
        return Ok(response);

      return BadRequest(response.Messange);
    }

    #endregion

    #region "Métodos Asincronos"
    /// <summary>
    /// Crea una Nueva Cuenta de Ahorro Asincrono
    /// </summary>
    /// <param name="acountDto">Datos de la cuenta</param>
    /// <returns></returns>
    [HttpPost("CreateAsync")]
    public async Task<IActionResult> CreateAsync([FromBody] AcountDTO acountDto)
    {
      if (acountDto == null)
        return BadRequest();
      var response = await _acountsApplication.CreateAsync(acountDto);
      if (response.IsSuccess)
        return Ok(response);

      return BadRequest(response.Messange);
    }
    /// <summary>
    /// Hace Movimientos en una Cuenta de Ahorro Asincrono
    /// </summary>
    /// <param name="acountDto">Datos de la cuenta</param>
    /// <returns></returns>
    [HttpPut("MoveAsync")]
    public async Task<IActionResult> MoveAsync([FromBody] AcountDTO acountDto)
    {
      if (acountDto == null)
        return BadRequest();
      var response = await _acountsApplication.MoveAsync(acountDto);
      if (response.IsSuccess)
        return Ok(response);

      return BadRequest(response.Messange);
    }

    /// <summary>
    /// Consulta una Cuenta de Ahorro Asincrono
    /// </summary>
    /// <param name="codeAcount">Nro de la cuenta a consultar</param>
    /// <returns></returns>
    [HttpGet("GetAsync/{codeAcount}")]
    public async Task<IActionResult> GetAsync(string codeAcount)
    {
      if (string.IsNullOrEmpty(codeAcount))
        return BadRequest();
      var response = await _acountsApplication.GetAsync(codeAcount);
      if (response.IsSuccess)
        return Ok(response);

      return BadRequest(response.Messange);
    }

    #endregion
  }
}