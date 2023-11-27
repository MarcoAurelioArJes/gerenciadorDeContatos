using GerenciadorDeContatos.API.Model.Enums;

namespace GerenciadorDeContatos.API.Model.DTOs.Telefone
{
    public class DetalhesTelefoneView
    {
        public int Id { get; set; }
        public int ContatoID { get; set; }
        public string DDD { get; set; }
        public string Numero { get; set; }
        public TipoFoneEnum TipoFone { get; set; }
    }
}
