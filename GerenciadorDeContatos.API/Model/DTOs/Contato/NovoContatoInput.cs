using GerenciadorDeContatos.API.Model.DTOs.Telefone;

namespace GerenciadorDeContatos.API.Model.DTOs.Contato
{
    public class NovoContatoInput
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public List<NovoTelefoneInput> Telefones { get; set; }
    }
}
