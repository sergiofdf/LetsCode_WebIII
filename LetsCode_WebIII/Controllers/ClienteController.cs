using LetsCode_WebIII.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LetsCode_WebIII.Controllers
{


    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {

        [HttpGet]
        public List<Cliente> GetInfoCliente()
        {
            return ListaClientes.clienteList;
        }

        [HttpPost]
        public Cliente PostCliente(Cliente cliente)
        {
            ListaClientes.clienteList.Add(cliente);
            return cliente;
        }

        [HttpPut]
        public Cliente UpdateCliente(Cliente clienteAtualizado)
        {
            ListaClientes.clienteList.RemoveAll(c => c.Cpf == clienteAtualizado.Cpf);
            ListaClientes.clienteList.Add(clienteAtualizado);
            return clienteAtualizado;
        }

        [HttpDelete]
        public List<Cliente> DeleteCliente(string cpf)
        {
            ListaClientes.clienteList.RemoveAll(c => c.Cpf == cpf);
            return ListaClientes.clienteList;
        }

    }
}
