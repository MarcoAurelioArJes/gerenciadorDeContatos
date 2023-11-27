using FluentValidation;
using GerenciadorDeContatos.API.Model.Erros;
using System.Text.RegularExpressions;

namespace GerenciadorDeContatos.API.Services
{
    public abstract class ValidadorBaseService<T> : AbstractValidator<T>
    {
        public void Validar(T modelo)
        {
            var retornoDaValidacao = Validate(modelo);
            if (retornoDaValidacao.IsValid) 
                return;
            
            var lista = new List<RespostaDeErro>();
            foreach (var erro in retornoDaValidacao.Errors)
                lista.Add(new RespostaDeErro
                {   
                    NomeDaPropriedade = erro.PropertyName,
                    MensagemDeErro = erro.ErrorMessage  
                });
            
            throw new ExcecaoPersonalizada(lista.ObterStringDoJsonSerializado());
        }

        public static bool ObterSeEmailEhValido(string email)
        {
            if (string.IsNullOrWhiteSpace(email) == false)
            {
                var regex = new Regex(@"\w+.*@\w+\.+\w+");
                return regex.IsMatch(email);
            }

            return true;
        }

        public abstract bool ObterSeEmailJaEstaCadastrado(string email);
    }
}
