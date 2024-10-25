using Microsoft.AspNetCore.Mvc;
using sastreria_data.Sources.BasedeDatos;
using sastreria_data.Sources.BasedeDatos.Tablas;

namespace SastreriaPresentación.Controllers
{
    [ApiController]
    [Route("api/horario")]
    public class HorarioController : ControllerBase
    {
        private readonly SastreriaDbContext _db;
        private readonly ILogger<HorarioController> _logger;

        public HorarioController(SastreriaDbContext context, ILogger<HorarioController> logger)
        {
            _db = context;
            _logger = logger;
        }

        [HttpGet]
        [Route("")]
        public ActionResult<List<HorarioTable>> ListHorarios()
        {
            try
            {
                var horarios = _db.Horario.ToList();
                return Ok(horarios);
            }
            catch (Exception ex)
            {
                _logger.LogError($"[HorarioController] error: {ex.Message} {ex.InnerException}");
                return StatusCode(500, "Error");
            }
        }

        //get x {id}
        [HttpGet("{id}")]
        public ActionResult<HorarioTable> GetHorario(int id)
        {
            try
            {
                var horario = _db.Horario.Find(id);

                if (horario == null)
                {
                    return NotFound();
                }

                return Ok(horario);
            }
            catch (Exception ex)
            {
                _logger.LogError($"[HorarioController] error: {ex.Message} {ex.InnerException}");
                return StatusCode(500, "Error");
            }
        }
    }
}
