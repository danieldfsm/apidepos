using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UsuariosApi.models;

namespace PosApi.Controllers
{
   [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly UsuarioContext _databaseService;

        public UsuariosController(UsuarioContext databaseService)
        {
            _databaseService = databaseService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var usuarios = await _databaseService.EjecutarSPPOSLEConexion(request.Usuario, request.Password);
            
            if (usuarios == null || usuarios.Count == 0)
                return NotFound("Usuario no encontrado o credenciales incorrectas.");

            return Ok(usuarios);
        }

        [HttpPost("grupo")]
        public async Task<IActionResult> Grupo([FromBody] GrupoRequest request)
        {
            var grupos = await _databaseService.EjecutarSPPOSLE_Grupo();
            
            if (grupos == null || grupos.Count == 0)
                return NotFound("Grupo no encontrado o credenciales incorrectas.");

            return Ok(grupos);
        }

         [HttpPost("productos")]
        public async Task<IActionResult> Productos([FromBody] ProductosRequest request)
        {
            var productos = await _databaseService.EjecutarSPPOSLE_Productos_Select(request.Codigo_Grupo);
            
            if (productos == null || productos.Count == 0)
                return NotFound("Grupo no encontrado o credenciales incorrectas.");

            return Ok(productos);
        }
    }

    public class LoginRequest
    {
        public string? Usuario { get; set; }
        public string? Password { get; set; }
    }

     public class GrupoRequest
    {

    }
    public class ProductosRequest
    {
        public string? Codigo_Grupo { get; set; }

    }
}
