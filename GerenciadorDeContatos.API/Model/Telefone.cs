using GerenciadorDeContatos.API.Model.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciadorDeContatos.API.Model
{
    public class Telefone
    {
        public int Id { get; set; }
        [ForeignKey(nameof(Contato))]
        public int ContatoID { get; set; }
        public string DDD { get; set; }
        public string Numero { get; set; }
        public TipoFoneEnum TipoFone { get; set; }

        public Contato Contato { get; set; }
    }
}
