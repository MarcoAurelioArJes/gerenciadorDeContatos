namespace GerenciadorDeContatos.API.Services.ValidacoesService
{
    public static class ValidaParametrosService
    {
        public static void VerificarSeObjetoEhNulo<T>(this T model)
        {
            if (model == null)
                throw new ArgumentNullException(string.Empty, "Necessário informar o objeto");
        }
    }
}
