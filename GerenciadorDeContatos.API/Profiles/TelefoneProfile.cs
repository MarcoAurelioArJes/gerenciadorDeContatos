using AutoMapper;
using GerenciadorDeContatos.API.Model;
using GerenciadorDeContatos.API.Model.DTOs.Telefone;

namespace GerenciadorDeContatos.API.Profiles
{
    public class TelefoneProfile : Profile
    {
        public TelefoneProfile() 
        {
            CreateMap<NovoTelefoneInput, Telefone>();
            CreateMap<Telefone, DetalhesTelefoneView>();
        }
    }
}
