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
            bool cpfCadastrado = CpfJaCadastrado(cliente.Cpf);
            if (cpfCadastrado)
            {
                return BadRequest("Cpf já cadastrado!");
            }
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
            bool cpfValido = ValidaCpf.IsCpfValid(cpf);
            if (!cpfValido)
            {
                return BadRequest("Cpf inválido!");
            }
            var clienteRemovido = ListaClientes.clienteList.RemoveAll(c => c.Cpf == cpf);
            if (clienteRemovido == 0)
            {
                return NotFound();
            }
            return Ok(ListaClientes.clienteList);
        }


        public bool CpfJaCadastrado(string cpf)
        {
            return ListaClientes.clienteList.FindAll(c => c.Cpf == cpf).Any();
        }
    }
}
