using LetsCode_WebIII.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text.RegularExpressions;

namespace LetsCode_WebIII.Filters
{
    public class VerificaCpfValidoActionFilter : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string metodo = context.HttpContext.Request.Method;
            string cpf = "";

            if (metodo == "GET")
            {
                cpf = context.ActionArguments["cpf"].ToString();
            }
            else
            {
                ClienteDTO cliente = (ClienteDTO)context.ActionArguments["Cliente"];
                cpf = cliente.Cpf;
            }

            Regex RgxCpf = new(@"^\d{3}\.?\d{3}\.?\d{3}-?\d{2}$");
            if (!RgxCpf.Match(cpf).Success)
            {
                var problem = new ProblemDetails
                {
                    Status = 400,
                    Title = "Cpf inválido",
                    Detail = "O Cpf informado deve ter um formato válido, contendo 11 dígitos.",
                };

                context.Result = new ObjectResult(problem);
            }
        }
    }
}
