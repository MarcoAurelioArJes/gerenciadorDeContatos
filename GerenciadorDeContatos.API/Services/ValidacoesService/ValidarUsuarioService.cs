using FluentValidation;
using System.Text.RegularExpressions;
using GerenciadorDeContatos.API.Model;
using GerenciadorDeContatos.API.Repositorio;

namespace GerenciadorDeContatos.API.Services
{
    public class ValidarUsuarioService : ValidadorBaseService<Usuario>
    {
        private UsuarioRepositorio _usuarioRepository;
        public ValidarUsuarioService(UsuarioRepositorio usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;

            RuleFor(u => u.Nome)
                .NotEmpty()
                .WithMessage("Informe o nome do usuário");

            RuleFor(u => u.Sobrenome)
                .NotEmpty()
                .WithMessage("Informe o sobrenome do usuário");

            RuleFor(u => u.Senha)
                .NotEmpty()
                .MinimumLength(8)
                .WithMessage("A senha do usuário é obrigatória e precisa ter no mínimo 8 caracteres");

            RuleFor(u => u.Email)
                .NotEmpty()
                .WithMessage("Informe um email")
                .Must(ObterSeEmailEhValido)
                .WithMessage("Informe um email válido");


            RuleFor(u => u.DataNascimento)
                .InclusiveBetween(DateTime.Parse("1930/01/01"), DateTime.Today)
                .WithMessage("{PropertyName} precisa " +
                             "ser maior que 31/12/1929 " +
                             "e menor que a data atual: " +
                             $"{DateTime.Today:dd/MM/yyyy}");

            RuleFor(u => u.Cargo)
                .IsInEnum()
                .WithMessage("Necessário informar um cargo válido");
        }

        public override bool ObterSeEmailJaEstaCadastrado(string email)
        {
            return _usuarioRepository.ObterPorEmail(email) == null;
        }
    }
}
