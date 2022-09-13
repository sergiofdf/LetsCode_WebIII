using LetsCode_WebIII.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LetsCode_WebIII.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TokenController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        private readonly ITokenService _tokenService;

        public TokenController(IClienteService clienteService, ITokenService tokenService)
        {
            _clienteService = clienteService;
            _tokenService = tokenService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<string> CreateToken(string cpf)
        {
            var cliente = _clienteService.GetCliente(cpf);
            if (cliente == null)
            {
                return BadRequest();
            }
            return Ok(_tokenService.GenerateTokenProdutos(cliente.Nome, cliente.Permissao));
        }


        [HttpGet("/Token/Eventos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<string> CreateTokenEvents(string cpf)
        {
            var cliente = _clienteService.GetCliente(cpf);
            if (cliente == null)
            {
                return BadRequest();
            }
            return Ok(_tokenService.GenerateTokenEventos(cliente.Nome, cliente.Permissao));
        }
    }
}
