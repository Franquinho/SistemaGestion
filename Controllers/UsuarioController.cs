using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PreEntregaPF.Repository;

namespace PreEntregaPF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        UsuarioRepository _usuarioRepository;
        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }
        [HttpGet]

        public ActionResult ObtenerUsuario([FromQuery] string usuario)

        { 
            var result = _usuarioRepository.TraerUsuario(usuario);
            return Ok(result);

        }

        public ActionResult ObtenerUsuarioContraseña([FromQuery] string usuario, [FromQuery] string contraseña)

        {
            var result = _usuarioRepository.LoguearUsuario(usuario,contraseña);
            return Ok(result);




        }
    }
}
