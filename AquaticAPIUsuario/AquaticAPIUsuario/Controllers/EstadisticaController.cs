using AquaticAPIUsuario.IServicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AquaticAPIUsuario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadisticaController : ControllerBase
    {
        private readonly IEstadisticas _estadisticas;
        private readonly ILogger<EstadisticaController> _logger;
        public EstadisticaController(IEstadisticas estadisticas, ILogger<EstadisticaController> logger)
        {
            _estadisticas = estadisticas;
            _logger = logger;
        }

        [HttpGet()]
        public IActionResult Get()
        {

            try
            {

                _estadisticas.ListadoGeneral();
                return Ok();



            }
            catch (Exception ex)
            {
                _logger.LogError("", ex);
                throw;
            }

        }
    }
}
