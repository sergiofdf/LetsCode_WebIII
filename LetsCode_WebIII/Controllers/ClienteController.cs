using LetsCode_WebIII.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LetsCode_WebIII.Controllers
{


    [ApiController]
    [Route("[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class ClienteController : ControllerBase
    {

        [HttpGet("/Cliente/{cpf}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Cliente> GetInfoCliente(string cpf)
        {
            var cliente = ListaClientes.clienteList.Find(c => c.Cpf == cpf);
            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente);
        }

        [HttpGet("/Clientes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<Cliente>> GetAllClients()
        {
            return Ok(ListaClientes.clienteList);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Cliente> PostCliente(Cliente cliente)
        {
            ListaClientes.clienteList.Add(cliente);
            return CreatedAtAction(nameof(PostCliente), cliente);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateCliente(Cliente clienteAtualizado)
        {
            var clienteRemovido = ListaClientes.clienteList.RemoveAll(c => c.Cpf == clienteAtualizado.Cpf);
            if (clienteRemovido == 0)
            {
                return NotFound();
            }
            ListaClientes.clienteList.Add(clienteAtualizado);
            return NoContent();
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<Cliente>> DeleteCliente(string cpf)
        {
            var clienteRemovido = ListaClientes.clienteList.RemoveAll(c => c.Cpf == cpf);
            if (clienteRemovido == 0)
            {
                return NotFound();
            }
            return Ok(ListaClientes.clienteList);
        }
    }
}
