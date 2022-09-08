using AutoMapper;
using LetsCode_WebIII.Core.Interfaces;
using LetsCode_WebIII.Core.Models;
using LetsCode_WebIII.Filters;
using Microsoft.AspNetCore.Mvc;

namespace LetsCode_WebIII.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    [TypeFilter(typeof(LogTempoExecucaoResourceFilter))]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        private readonly IMapper _mapper;

        public ClienteController(IClienteService clienteService, IMapper mapper)
        {
            _clienteService = clienteService;
            _mapper = mapper;
        }

        [HttpGet("/Cliente/{cpf}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [TypeFilter(typeof(VerificaCpfValidoActionFilter))]
        public ActionResult<Cliente> GetInfoCliente(string cpf)
        {
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
        [TypeFilter(typeof(VerificaCpfValidoActionFilter))]
        [ServiceFilter(typeof(GaranteCpfNaoFoiCadastradoActionFilter))]
        public ActionResult<Cliente> PostCliente(ClienteDTO cliente)
        {
            Cliente clienteMapeado = _mapper.Map<Cliente>(cliente);
            var result = _clienteService.InsertCliente(clienteMapeado);
            return CreatedAtAction(nameof(PostCliente), result);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [TypeFilter(typeof(VerificaCpfValidoActionFilter))]
        [ServiceFilter(typeof(ValidaUpdateActionFilter))]
        public IActionResult UpdateCliente(long id, ClienteDTO cliente)
        {
            Cliente clienteMapeado = _mapper.Map<Cliente>(cliente);
            _clienteService.UpdateCliente(id, clienteMapeado);
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
