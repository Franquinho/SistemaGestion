using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PreEntregaPF.Repository;

namespace PreEntregaPF.Controllers
{

        [Route("api/[controller]")]
        [ApiController]
        public class ProductoController : ControllerBase
        {
            ProductoRepository _productoRepository;
            public  ProductoController()
            {
            _productoRepository = new ProductoRepository();
            }
            
            [HttpGet]

            public ActionResult ObtenerVentaPorId([FromQuery] int idusuario)

            {
                var result = _productoRepository.TraerProductoPorUsuario(idusuario);
                return Ok(result);
            }

        }
}

