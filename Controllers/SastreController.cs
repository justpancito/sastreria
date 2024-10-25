using Microsoft.AspNetCore.Mvc;
using sastreria_data.Sources.BasedeDatos.Tablas;
using sastreria_data.Sources.BasedeDatos;

namespace SastreriaPresentación.Controllers
{
    [ApiController]
    [Route("api/sastre")]
    public class SastreController : ControllerBase
    {
        private readonly SastreriaDbContext _db;
        private readonly ILogger<SastreController> _logger;

        public SastreController(SastreriaDbContext context, ILogger<SastreController> logger)
        {
            _db = context;
            _logger = logger;
        }

        [HttpGet]
        [Route("")]
        public ActionResult<List<SastreTable>> ListSastres()
        {
            try
            {
                var sastres = _db.Sastre.ToList();
                return Ok(sastres);
            }
            catch (Exception ex)
            {
                _logger.LogError($"[SastreController] error: {ex.Message} {ex.InnerException}");
                return StatusCode(500, "Error");
            }
        }

        //get x {id}
        [HttpGet("{id}")]
        public ActionResult<SastreTable> GetSastres(int id)
        {
            try
            {
                var sastre = _db.Sastre.Find(id);

                if (sastre == null)
                {
                    return NotFound();
                }

                return Ok(sastre);
            }
            catch (Exception ex)
            {
                _logger.LogError($"[SastreController] error: {ex.Message} {ex.InnerException}");
                return StatusCode(500, "Error");
            }
        }
    }
}
