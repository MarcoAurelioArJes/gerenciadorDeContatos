namespace GerenciadorDeContatos.API.Model.Erros
{
    public class ExcecaoPersonalizada : ArgumentException
    {
        public ExcecaoPersonalizada(string message) : base(message) { }
    }
}
