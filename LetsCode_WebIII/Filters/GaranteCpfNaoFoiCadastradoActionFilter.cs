using LetsCode_WebIII.Core.Interfaces;
using LetsCode_WebIII.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LetsCode_WebIII.Filters
{
    public class GaranteCpfNaoFoiCadastradoActionFilter : ActionFilterAttribute
    {
        public IClienteService _clienteService;
        public GaranteCpfNaoFoiCadastradoActionFilter(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Cliente cliente = (Cliente)context.ActionArguments["Cliente"];
            string cpf = cliente.Cpf;
            var buscaCliente = _clienteService.GetCliente(cpf);

            if (buscaCliente != null)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status409Conflict);
            }
        }
    }
}
