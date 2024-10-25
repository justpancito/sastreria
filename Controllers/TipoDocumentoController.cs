using Microsoft.AspNetCore.Mvc;
using sastreria_data.Sources.BasedeDatos.Tablas;
using sastreria_data.Sources.BasedeDatos;

namespace SastreriaPresentación.Controllers
{
    [ApiController]
    [Route("api/tipodocumento")]
    public class TipoDocumentoController : ControllerBase
    {
        private readonly SastreriaDbContext _db;
        private readonly ILogger<TipoDocumentoController> _logger;

        public TipoDocumentoController(SastreriaDbContext context, ILogger<TipoDocumentoController> logger)
        {
            _db = context;
            _logger = logger;
        }

        [HttpGet]
        [Route("")]
        public ActionResult<List<TipoDocumentoTable>> ListTiposDocumento()
        {
            try
            {
                var tiposdocumentos = _db.TipoDocumento.ToList();
                return Ok(tiposdocumentos);
            }
            catch (Exception ex)
            {
                _logger.LogError($"[TipoDocumentoController] error: {ex.Message} {ex.InnerException}");
                return StatusCode(500, "Error");
            }
        }

        //get x {id}
        [HttpGet("{id}")]
        public ActionResult<TipoDocumentoTable> GetTiposDocumenetos(int id)
        {
            try
            {
                var tipodoc = _db.TipoDocumento.Find(id);

                if (tipodoc == null)
                {
                    return NotFound();
                }

                return Ok(tipodoc);
            }
            catch (Exception ex)
            {
                _logger.LogError($"[TipoDocumentoController] error: {ex.Message} {ex.InnerException}");
                return StatusCode(500, "Error");
            }
        }
    }
}
