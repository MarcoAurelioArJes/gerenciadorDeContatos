using GerenciadorDeContatos.API.Model.Enums;

namespace GerenciadorDeContatos.API.Model.DTOs.Usuario
{
    public class NovoUsuarioInput
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataNascimento { get; set; }
        public CargosEnum Cargo { get; set; }
    }
}
