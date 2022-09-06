using LetsCode_WebIII.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LetsCode_WebIII.Filters
{
    public class ValidaUpdateActionFilter : IActionFilter
    {
        public IClienteService _clienteService;
        public ValidaUpdateActionFilter(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            var errosUpdate = context.ModelState.ErrorCount;
            if (errosUpdate > 0)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            long id = (long)context.ActionArguments["id"];
            var buscaCliente = _clienteService.GetCliente(id);
            if (buscaCliente == null)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status400BadRequest);
            }
        }
    }
}
