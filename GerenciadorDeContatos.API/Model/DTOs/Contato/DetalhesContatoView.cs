using GerenciadorDeContatos.API.Model.DTOs.Telefone;

namespace GerenciadorDeContatos.API.Model.DTOs.Contato
{
    public class DetalhesContatoView
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public List<DetalhesTelefoneView> Telefones { get; set; }
    }
}
