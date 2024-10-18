using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciadorDeContatos.API.Model
{
    public class Contato
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public List<Telefone> Telefones { get; set; }
        [ForeignKey(nameof(Usuario))]
        public int UsuarioID { get; set; }
        public Usuario Usuario { get; set; }
    }
}
