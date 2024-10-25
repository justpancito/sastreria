using Microsoft.AspNetCore.Mvc;
using sastreria_data.Sources.BasedeDatos.Tablas;
using sastreria_data.Sources.BasedeDatos;

namespace SastreriaPresentación.Controllers
{
    [ApiController]
    [Route("api/cita")]
    public class CitaController : ControllerBase
    {
        private readonly SastreriaDbContext _db;
        private readonly ILogger<CitaController> _logger;

        public CitaController(SastreriaDbContext context, ILogger<CitaController> logger)
        {
            _db = context;
            _logger = logger;
        }

        [HttpGet]
        [Route("")]
        public ActionResult<List<CitaTable>> ListCitas()
        {
            try
            {
                var citas = _db.Cita.ToList();
                return Ok(citas);
            }
            catch (Exception ex)
            {
                _logger.LogError($"[CitaController] error: {ex.Message} {ex.InnerException}");
                return StatusCode(500, "Error");
            }
        }

        //get x {id}
        [HttpGet("{id}")]
        public ActionResult<CitaTable> GetCitas(int id)
        {
            try
            {
                var cita = _db.Cita.Find(id);

                if (cita == null)
                {
                    return NotFound();
                }

                return Ok(cita);
            }
            catch (Exception ex)
            {
                _logger.LogError($"[CitaController] error: {ex.Message} {ex.InnerException}");
                return StatusCode(500, "Error");
            }
        }

    }
}
