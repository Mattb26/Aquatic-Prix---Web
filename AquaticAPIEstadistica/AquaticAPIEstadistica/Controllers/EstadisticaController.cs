using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AquaticAPIEstadistica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadisticaController : ControllerBase
    {
        [HttpGet("{idUsuario}/estadisticas")]
        public IActionResult Get([Required] Int32 idUsuario)
        {
            //Deal.Estadistica estadistica;
            try
            {
                //estadistica = new Deal.Estadistica();

                return Ok();

            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("estadisticas")]
        public IActionResult Get()
        {
            //Deal.Estadistica estadistica;
            try
            {
                //estadistica = new Deal.Estadistica();

                return Ok();

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
