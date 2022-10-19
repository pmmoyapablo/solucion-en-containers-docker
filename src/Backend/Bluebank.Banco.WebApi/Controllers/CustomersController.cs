using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Bluebank.Banco.Aplicacion.Customers;
using System.Threading.Tasks;

namespace Bluebank.Banco.WebApi.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : Controller
    {
        private readonly CustomersApplication _customersApplication;
        public CustomersController(CustomersApplication customersApplication)
        {
            _customersApplication = customersApplication;
        }

        #region "Métodos Sincronos"    
        /// <summary>
        /// Obtiene la lista de todos Clientes
        /// </summary>
        /// <returns>Lista de Clientes</returns>
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var response = _customersApplication.GetAll();
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Messange);
        }
    #endregion

        #region "Métodos Asincronos"
        /// <summary>
        /// Obtiene la lista de todos Clientes Asincrono
        /// </summary>
        /// <returns>Lista de Clientes</returns>
        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _customersApplication.GetAllAsync();
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Messange);
        }

        #endregion

    }
}