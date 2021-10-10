using AquaticAPIEstadistica.IServicios;
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

        private readonly IEstadisticaDeal _estadisticaDeal;

        public EstadisticaController(IEstadisticaDeal estadisticaDeal)
        {
            _estadisticaDeal = estadisticaDeal;
        }

        [HttpGet("{idUsuario}/estadisticas")]
        public IActionResult Get([Required] Int32 idUsuario)
        {
            //Deal.Estadistica estadistica;
            try
            {
                //estadistica = new Deal.Estadistica();
                _estadisticaDeal.Listado();

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
                _estadisticaDeal.Listado();
                return Ok();

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
