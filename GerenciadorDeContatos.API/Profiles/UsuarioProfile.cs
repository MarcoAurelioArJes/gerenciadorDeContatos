using AutoMapper;
using GerenciadorDeContatos.API.Model;
using GerenciadorDeContatos.API.Model.DTOs.Usuario;

namespace GerenciadorDeContatos.API.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile() 
        {
            CreateMap<LoginUsuarioInput, Usuario>();
            CreateMap<NovoUsuarioInput, Usuario>();
        }
    }
}
