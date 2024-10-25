using Microsoft.AspNetCore.Mvc;
using sastreria_data.Sources.BasedeDatos.Tablas;
using sastreria_data.Sources.BasedeDatos;

namespace SastreriaPresentación.Controllers
{
    [ApiController]
    [Route("api/cliente")]
    public class ClienteController : ControllerBase
    {
        private readonly SastreriaDbContext _db;
        private readonly ILogger<ClienteController> _logger;

        public ClienteController(SastreriaDbContext context, ILogger<ClienteController> logger)
        {
            _db = context;
            _logger = logger;
        }

        [HttpGet]
        [Route("")]
        public ActionResult<List<ClienteTable>> ListClientes()
        {
            try
            {
                var clientes = _db.Cliente.ToList();
                return Ok(clientes);
            }
            catch (Exception ex)
            {
                _logger.LogError($"[ClienteController] error: {ex.Message} {ex.InnerException}");
                return StatusCode(500, "Error");
            }
        }

        //get x {id}
        [HttpGet("{id}")]
        public ActionResult<ClienteTable> GetClientes(int id)
        {
            try
            {
                var cliente = _db.Cliente.Find(id);

                if (cliente == null)
                {
                    return NotFound();
                }

                return Ok(cliente);
            }
            catch (Exception ex)
            {
                _logger.LogError($"[ClienteController] error: {ex.Message} {ex.InnerException}");
                return StatusCode(500, "Error");
            }
        }
    }
}
