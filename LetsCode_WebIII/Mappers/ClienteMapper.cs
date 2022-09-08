using AutoMapper;
using LetsCode_WebIII.Core.Models;

namespace LetsCode_WebIII.Mappers
{
    public class ClienteMapper : Profile
    {
        public ClienteMapper()
        {
            CreateMap<ClienteDTO, Cliente>();
        }
    }
}
