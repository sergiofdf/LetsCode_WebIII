using LetsCode_WebIII.Repository;
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
        private readonly ClienteRepository _repositoryCliente;

        public ClienteController(IConfiguration configuration)
        {
            _repositoryCliente = new ClienteRepository(configuration);
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
            var cliente = _repositoryCliente.GetCliente(cpf);
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
            return Ok(_repositoryCliente.GetClientes());
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Cliente> PostCliente(Cliente cliente)
        {
            bool cpfCadastrado = CpfJaCadastrado(cliente.Cpf);
            if (cpfCadastrado)
            {
                return BadRequest("Cpf já cadastrado!");
            }
            _repositoryCliente.InsertCliente(cliente);
            return CreatedAtAction(nameof(PostCliente), cliente);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateCliente(long id, Cliente clienteAtualizado)
        {
            if (!_repositoryCliente.UpdateCliente(id, clienteAtualizado))
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
            if (!_repositoryCliente.DeleteCliente(id))
            {
                return NotFound();
            }
            return NoContent();
        }


        public bool CpfJaCadastrado(string cpf)
        {
            return _repositoryCliente.GetCliente(cpf) != null;
        }
    }
}
