using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PreEntregaPF.Repository;

namespace PreEntregaPF.Controllers
{

        [Route("api/[controller]")]
        [ApiController]
        public  class ProductoVendidoController : ControllerBase
        {
            ProductoVendidoRepository _productoVendidoRepository;
            public  ProductoVendidoController()
            {
                _productoVendidoRepository = new ProductoVendidoRepository();
            }
            [HttpGet]

            public ActionResult ObtenerProductosVendidos([FromQuery] int id)

            {
                var result = _productoVendidoRepository.TraerProductosVendidos(id);
                return Ok(result);
            }


        }
    }

