using GerenciadorDeContatos.API.Model.Enums;

namespace GerenciadorDeContatos.API.Model.DTOs.Telefone
{
    public class NovoTelefoneInput
    {
        public string DDD { get; set; }
        public string Numero { get; set; }
        public TipoFoneEnum TipoFone { get; set; }

    }
}
