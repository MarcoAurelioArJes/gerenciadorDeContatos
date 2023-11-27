namespace GerenciadorDeContatos.API.Services
{
    public class SenhaHashService
    {
        private const int CUSTO_DE_TRABALHO = 13;
        private const BCrypt.Net.HashType TIPO_DE_CRIPTOGRAFIA = BCrypt.Net.HashType.SHA256;
        public static string ObterSenhaHash(string senha)
        {
            return BCrypt.Net.BCrypt.EnhancedHashPassword(senha, CUSTO_DE_TRABALHO, TIPO_DE_CRIPTOGRAFIA);
        }

        public static bool ObterSeSenhaEhValida(string senhaSalva, string senhaInserida)
        {
            return BCrypt.Net.BCrypt.EnhancedVerify(senhaInserida, senhaSalva, TIPO_DE_CRIPTOGRAFIA);
        }
    }
}
