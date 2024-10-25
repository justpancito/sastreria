using Microsoft.AspNetCore.Mvc;
using sastreria_data.Sources.BasedeDatos.Tablas;
using sastreria_data.Sources.BasedeDatos;

namespace SastreriaPresentación.Controllers
{
    [ApiController]
    [Route("api/modelo")]
    public class ModeloController : ControllerBase
    {
        private readonly SastreriaDbContext _db;
        private readonly ILogger<ModeloController> _logger;

        public ModeloController(SastreriaDbContext context, ILogger<ModeloController> logger)
        {
            _db = context;
            _logger = logger;
        }

        [HttpGet]
        [Route("")]
        public ActionResult<List<ModeloTable>> ListModelos()
        {
            try
            {
                var modelos = _db.Modelo.ToList();
                return Ok(modelos);
            }
            catch (Exception ex)
            {
                _logger.LogError($"[ModeloController] error: {ex.Message} {ex.InnerException}");
                return StatusCode(500, "Error");
            }
        }

        //get x {id}
        [HttpGet("{id}")]
        public ActionResult<ModeloTable> GetModelos(int id)
        {
            try
            {
                var modelos = _db.Modelo.Find(id);

                if (modelos == null)
                {
                    return NotFound();
                }

                return Ok(modelos);
            }
            catch (Exception ex)
            {
                _logger.LogError($"[ModeloController] error: {ex.Message} {ex.InnerException}");
                return StatusCode(500, "Error");
            }
        }
    }
}
