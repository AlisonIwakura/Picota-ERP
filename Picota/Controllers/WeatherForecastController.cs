using Microsoft.AspNetCore.Mvc;
using Picota.Models;

namespace Picota.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetClientes()
        {
            return Ok(new[]
            {
                new { Id = 1, Nome = "teste1" },
                new { Id = 2, Nome = "teste2" }
            });
        }


        [HttpPost]
        public IActionResult CriarCliente(Cliente cliente)
        {
            return Ok(cliente);
        }

        [HttpGet]
        public IActionResult GetAgenda(Agenda agenda)
        {

            return Ok(agenda);
        }





    }
}