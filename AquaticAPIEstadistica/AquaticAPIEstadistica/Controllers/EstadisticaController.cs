using AquaticAPIEstadistica.IServicios;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
            IEnumerable<Models.Estadisticas> estadistica;
            try
            {
                estadistica = _estadisticaDeal.Listado(idUsuario);

                if (estadistica != null)
                {
                    return Ok(estadistica);
                }
                else 
                {
                    return BadRequest("Sin registros");
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("estadisticas")]
        public IActionResult Get()
        {
            IEnumerable<Models.Estadisticas> estadistica;
            try
            {

                estadistica = _estadisticaDeal.Listado();

                if (estadistica != null)
                {
                    return Ok(estadistica);
                }
                else
                {
                    return BadRequest("Sin registros");
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
