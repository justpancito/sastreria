using Microsoft.AspNetCore.Mvc;
using sastreria_data.Sources.BasedeDatos.Tablas;
using sastreria_data.Sources.BasedeDatos;

namespace SastreriaPresentación.Controllers
{
    [ApiController]
    [Route("api/datos")]
    public class DatoSastreriaController : ControllerBase
    {
        private readonly SastreriaDbContext _db;
        private readonly ILogger<DatoSastreriaController> _logger;

        public DatoSastreriaController(SastreriaDbContext context, ILogger<DatoSastreriaController> logger)
        {
            _db = context;
            _logger = logger;
        }

        [HttpGet]
        [Route("")]
        public ActionResult<List<DatoSastreriaTable>> ListDatosSastreria()
        {
            try
            {
                var datos = _db.DatoSastreria.ToList();
                return Ok(datos);
            }
            catch (Exception ex)
            {
                _logger.LogError($"[DatoSastreriaController] error: {ex.Message} {ex.InnerException}");
                return StatusCode(500, "Error");
            }
        }

        //get x {id}
        [HttpGet("{id}")]
        public ActionResult<DatoSastreriaTable> GetDatos(int id)
        {
            try
            {
                var datos = _db.DatoSastreria.Find(id);

                if (datos == null)
                {
                    return NotFound();
                }

                return Ok(datos);
            }
            catch (Exception ex)
            {
                _logger.LogError($"[DatoSastreriaController] error: {ex.Message} {ex.InnerException}");
                return StatusCode(500, "Error");
            }
        }
    }
}
