using LetsCode_WebIII.Core.Interfaces;
using LetsCode_WebIII.Core.Models;
using LetsCode_WebIII.Utils;
using Microsoft.AspNetCore.Mvc;

namespace LetsCode_WebIII.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet("/Cliente/{cpf}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Cliente> GetInfoCliente(string cpf)
        {
            bool cpfValido = ValidaCpf.IsCpfValid(cpf);
            if (!cpfValido)
            {
                return BadRequest("Cpf inválido!");
            }
            var cliente = _clienteService.GetCliente(cpf);
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
            return Ok(_clienteService.GetClientes());
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Cliente> PostCliente(Cliente cliente)
        {
            bool cpfCadastrado = _clienteService.CpfJaCadastrado(cliente.Cpf);
            if (cpfCadastrado)
            {
                return BadRequest("Cpf já cadastrado!");
            }
            _clienteService.InsertCliente(cliente);
            return CreatedAtAction(nameof(PostCliente), cliente);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateCliente(long id, Cliente clienteAtualizado)
        {
            if (!_clienteService.UpdateCliente(id, clienteAtualizado))
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<Cliente>> DeleteCliente(long id)
        {
            if (!_clienteService.DeleteCliente(id))
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
