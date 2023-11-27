using AutoMapper;
using GerenciadorDeContatos.API.Model;
using GerenciadorDeContatos.API.Model.DTOs.Contato;

namespace GerenciadorDeContatos.API.Profiles
{
    public class ContatoProfile : Profile
    {
        public ContatoProfile()
        {
            CreateMap<NovoContatoInput, Contato>();
            CreateMap<AtualizarContatoInput, Contato>();
            CreateMap<Contato, ParcialContatoView>();
            CreateMap<Contato, DetalhesContatoView>();
        }
    }
}
