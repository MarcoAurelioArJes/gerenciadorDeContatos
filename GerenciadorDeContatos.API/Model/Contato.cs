namespace GerenciadorDeContatos.API.Model
{
    public class Contato
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public List<Telefone> Telefones { get; set; }
    }
}
