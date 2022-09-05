﻿using LetsCode_WebIII.Core.Interfaces;
using LetsCode_WebIII.Core.Models;

namespace LetsCode_WebIII.Core.Services
{
    public class ClienteService : IClienteService
    {
        public IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public List<Cliente> GetClientes()
        {
            return _clienteRepository.GetClientes();
        }

        public Cliente GetCliente(string cpf)
        {
            return _clienteRepository.GetCliente(cpf);
        }

        public bool InsertCliente(Cliente cliente)
        {
            return _clienteRepository.InsertCliente(cliente);
        }

        public bool UpdateCliente(long id, Cliente cliente)
        {
            return _clienteRepository.UpdateCliente(id, cliente);
        }

        public bool DeleteCliente(long id)
        {
            return _clienteRepository.DeleteCliente(id);
        }
        public bool CpfJaCadastrado(string cpf)
        {
            return _clienteRepository.GetCliente(cpf) != null;
        }

    }
}
