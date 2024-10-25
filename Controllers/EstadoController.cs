using Microsoft.AspNetCore.Mvc;
using sastreria_data.Sources.BasedeDatos.Tablas;
using sastreria_data.Sources.BasedeDatos;

namespace SastreriaPresentación.Controllers
{
    [ApiController]
    [Route("api/estado")]
    public class EstadoController : ControllerBase
    {
        private readonly SastreriaDbContext _db;
        private readonly ILogger<EstadoController> _logger;

        public EstadoController(SastreriaDbContext context, ILogger<EstadoController> logger)
        {
            _db = context;
            _logger = logger;
        }

        [HttpGet]
        [Route("")]
        public ActionResult<List<EstadoTable>> ListEstados()
        {
            try
            {
                var estados = _db.Estado.ToList();
                return Ok(estados);
            }
            catch (Exception ex)
            {
                _logger.LogError($"[EstadoController] error: {ex.Message} {ex.InnerException}");
                return StatusCode(500, "Error");
            }
        }

        //get x {id}
        [HttpGet("{id}")]
        public ActionResult<EstadoTable> GetEstados(int id)
        {
            try
            {
                var estado = _db.Estado.Find(id);

                if (estado == null)
                {
                    return NotFound();
                }

                return Ok(estado);
            }
            catch (Exception ex)
            {
                _logger.LogError($"[EstadoController] error: {ex.Message} {ex.InnerException}");
                return StatusCode(500, "Error");
            }
        }
    }
}
