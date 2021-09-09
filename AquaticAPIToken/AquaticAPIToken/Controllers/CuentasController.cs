using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AquaticAPIToken.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CuentasController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly SignInManager<IdentityUser> _siginManager;

        public CuentasController(UserManager<IdentityUser> userManager, IConfiguration configuration, SignInManager<IdentityUser> siginManager)
        {
            this._userManager = userManager;
            this._configuration = configuration;
            this._siginManager = siginManager;
        }

        // GET: api/<ValuesController>
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<Models.RespuestaAutenticacion>> Registrarar(Models.CredencialesUsuario credencialesUsuario)
        {
            try
            {
                var usuario = new IdentityUser 
                {
                    UserName = credencialesUsuario.Email,
                    Email = credencialesUsuario.Email
                };
                var resultado = await _userManager.CreateAsync(usuario, credencialesUsuario.Password);

                if (resultado.Succeeded)
                {
                    return Ok( RespuestaAutenticacion(credencialesUsuario));
                }
                else 
                {
                    return BadRequest(resultado.Errors);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<ActionResult<Models.RespuestaAutenticacion>> Login(Models.CredencialesUsuario credencialesUsuario)
        {
            try
            {
                //Se bloquea el usuario si no ingresa correctamente la clave con lockoutOnFailure
                var resultado = await _siginManager.PasswordSignInAsync(credencialesUsuario.Email, credencialesUsuario.Password, isPersistent: false, lockoutOnFailure: false);
                if (resultado.Succeeded)
                {
                    return RespuestaAutenticacion(credencialesUsuario);
                }
                else
                {
                    return BadRequest("login Incorrecto");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private Models.RespuestaAutenticacion RespuestaAutenticacion(Models.CredencialesUsuario credencialesUsuario)
        {
            try
            {
                var claims = new List<Claim>()
                {
                    new Claim("email", credencialesUsuario.Email),
                    new Claim("Lo que yo quiera", "Cualquier otro valor")
                };
                var llave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["llavejwt"]));
                var creds = new SigningCredentials(llave, SecurityAlgorithms.HmacSha256);
                var expiracion = DateTime.UtcNow.AddYears(1);
                var securityToken = new JwtSecurityToken(issuer: null, audience: null, claims: claims, expires: expiracion, signingCredentials : creds);

                return new Models.RespuestaAutenticacion()
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(securityToken),
                    Expiracion  = expiracion
                };
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
