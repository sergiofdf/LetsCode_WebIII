using LetsCode_WebIII.Core.Models;

namespace LetsCode_WebIII.Core.Interfaces
{
    public interface IClienteService
    {
        List<Cliente> GetClientes();
        Cliente GetCliente(string cpf);
        Cliente GetCliente(long id);
        bool InsertCliente(Cliente cliente);
        bool UpdateCliente(long id, Cliente cliente);
        bool DeleteCliente(long id);
        bool CpfJaCadastrado(string cpf);
    }
}
