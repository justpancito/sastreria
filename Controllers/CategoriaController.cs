using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sastreria_data.Sources.BasedeDatos;
using sastreria_data.Sources.BasedeDatos.Tablas;

namespace SastreriaPresentación.Controllers
{
    [ApiController]
    [Route("api/categoria")]
    public class CategoriaController : ControllerBase
    {
        private readonly SastreriaDbContext _db;
        private readonly ILogger<CategoriaController> _logger;

        public CategoriaController(SastreriaDbContext context, ILogger<CategoriaController> logger)
        {
            _db = context;
            _logger = logger;
        }

        [HttpGet]
        [Route("")]
        public ActionResult<List<CategoriaTable>> ListCategorias()
        {
            try
            {
                var categorias = _db.Categoria.ToList();
                return Ok(categorias);
            }
            catch (Exception ex)
            {
                _logger.LogError($"[CategoriaController] error: {ex.Message} {ex.InnerException}");
                return StatusCode(500, "Error");
            }
        }

        //get x {id}
        [HttpGet("{id}")]
        public ActionResult<CategoriaTable> GetCategorias(int id)
        {
            try
            {
                var categoria = _db.Categoria.Find(id);

                if (categoria == null)
                {
                    return NotFound();
                }

                return Ok(categoria);
            }
            catch (Exception ex)
            {
                _logger.LogError($"[CategoriaController] error: {ex.Message} {ex.InnerException}");
                return StatusCode(500, "Error");
            }
        }

    }
}
