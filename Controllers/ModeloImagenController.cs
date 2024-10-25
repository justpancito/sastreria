using Microsoft.AspNetCore.Mvc;
using sastreria_data.Sources.BasedeDatos.Tablas;
using sastreria_data.Sources.BasedeDatos;

namespace SastreriaPresentación.Controllers
{
    [ApiController]
    [Route("api/modeloimagen")]
    public class ModeloImagenController : ControllerBase
    {
        private readonly SastreriaDbContext _db;
        private readonly ILogger<ModeloImagenController> _logger;

        public ModeloImagenController(SastreriaDbContext context, ILogger<ModeloImagenController> logger)
        {
            _db = context;
            _logger = logger;
        }

        [HttpGet]
        [Route("")]
        public ActionResult<List<ModeloImagenTable>> ListModelosImagen()
        {
            try
            {
                var modelosimagen = _db.ModeloImagen.ToList();
                return Ok(modelosimagen);
            }
            catch (Exception ex)
            {
                _logger.LogError($"[ModeloImagenController] error: {ex.Message} {ex.InnerException}");
                return StatusCode(500, "Error");
            }
        }

        //get x {id}
        [HttpGet("{id}")]
        public ActionResult<ModeloImagenTable> GetModeloImagen(int id)
        {
            try
            {
                var modeloimagen = _db.ModeloImagen.Find(id);

                if (modeloimagen == null)
                {
                    return NotFound();
                }

                return Ok(modeloimagen);
            }
            catch (Exception ex)
            {
                _logger.LogError($"[ModeloImagenController] error: {ex.Message} {ex.InnerException}");
                return StatusCode(500, "Error");
            }
        }
    }
}
