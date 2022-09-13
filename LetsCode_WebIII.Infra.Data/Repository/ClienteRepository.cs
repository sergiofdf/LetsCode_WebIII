using Dapper;
using LetsCode_WebIII.Core.Interfaces;
using LetsCode_WebIII.Core.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace LetsCode_WebIII.Infra.Data.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly IConfiguration _configuration;

        public ClienteRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<Cliente> GetClientes()
        {
            var query = "SELECT * FROM base854.dbo.clientes";

            try
            {
                using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

                return conn.Query<Cliente>(query).ToList();

            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"\nErro ao comunicar com o banco, \nMensagem: {ex.Message} \nStack Trace: {ex.StackTrace} " +
                    $"\nTarget Site: {ex.TargetSite}");

                return null;
            }
        }

        public Cliente GetCliente(string cpf)
        {
            var query = "SELECT * FROM base854.dbo.clientes WHERE cpf=@cpf";

            var parameters = new DynamicParameters();
            parameters.Add("cpf", cpf);

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            return conn.QueryFirstOrDefault<Cliente>(query, parameters);
        }

        public Cliente GetCliente(long id)
        {
            var query = "SELECT * FROM base854.dbo.clientes WHERE id=@id";

            var parameters = new DynamicParameters();
            parameters.Add("id", id);

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            return conn.QueryFirstOrDefault<Cliente>(query, parameters);
        }

        public bool InsertCliente(Cliente cliente)
        {
            var query = "INSERT INTO base854.dbo.clientes VALUES(@cpf, @nome, @dataNascimento, @idade)";

            var parameters = new DynamicParameters(cliente);

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            return conn.Execute(query, parameters) == 1;
        }

        public bool UpdateCliente(long id, Cliente cliente)
        {
            var query = "UPDATE base854.dbo.clientes SET cpf=@cpf, nome=@nome, dataNascimento=@dataNascimento, idade=@idade WHERE id = @id";
            cliente.Id = id;
            var parameters = new DynamicParameters(cliente);

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            return conn.Execute(query, parameters) == 1;
        }

        public bool DeleteCliente(long id)
        {
            var query = "DELETE FROM base854.dbo.clientes WHERE id=@id";

            var parameters = new DynamicParameters();
            parameters.Add("id", id);

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            return conn.Execute(query, parameters) == 1;
        }
    }
}
