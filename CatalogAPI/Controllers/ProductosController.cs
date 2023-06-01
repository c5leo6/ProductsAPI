using CatalogRepository.Entidades;
using CatalogRepository.Modelos;
using CatalogRepository.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace CatalogAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        public IProductoRepository _repository;
        public ProductosController(IProductoRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult GetProductos([FromQuery] ModelRequestProducto request)
        {
            try
            {
                List<Producto> productos = _repository.Productos(request);
                return Ok(productos.Count > 0 ? productos : "No se han encontrado productos con este filtro");
            }
            catch (Exception ex)
            {
                return BadRequest("Ha ocurrido un error al realizar la petición. Detalles: " + ex.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult CreateProductos([FromBody] Producto producto)
        {
            try
            {
                _repository.Agregar(producto);
                return Ok("Producto creado");
            }
            catch(Exception ex)
            {
                return BadRequest("Ha ocurrido un error al realizar la petición. Detalles: " + ex.Message);
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult UpdateProductos([FromBody] Producto producto)
        {
            try
            {
                _repository.Editar(producto);
                return Ok("Producto actualizado");
            }
            catch (ArgumentNullException ex)
            {
                return NotFound("Producto no encontrado: " + ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest("Ha ocurrido un error al realizar la petición. Detalles: " + ex.Message);
            }
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult DeleteProductos(int idProducto)
        {
            try
            {
                _repository.Eliminar(idProducto);
                return Ok("Producto eliminado");
            }
            catch (ArgumentNullException ex)
            {
                return NotFound("Producto no encontrado: " + ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest("Ha ocurrido un error al realizar la petición. Detalles: " + ex.Message);
            }
        }
    }
}