using FluentValidation;
using GerenciadorDeContatos.API.Model;
using GerenciadorDeContatos.API.Repositorio;

namespace GerenciadorDeContatos.API.Services.ValidacoesService
{
    public class ValidarContatoService : ValidadorBaseService<Contato>
    {
        private ContatoRepositorio _contatoRepositorio;
        public ValidarContatoService(ContatoRepositorio contatoService)
        {
            _contatoRepositorio = contatoService;

            RuleFor(c => c.Nome)
                .NotEmpty()
                .WithMessage("Informe o nome do contato");

            RuleFor(c => c.Telefones)
                .NotNull()
                .Must(c => c.Count > 0)
                .WithMessage("Informe pelo menos um telefone para contato");

            RuleFor(c => c.Email)
                .NotEmpty()
                .WithMessage("Informe um email")
                .Must(ObterSeEmailEhValido)
                .WithMessage("Informe um email válido");
        }

        public override bool ObterSeEmailJaEstaCadastrado(string email)
        {
            return _contatoRepositorio.ObterPorEmail(email) == null;
        }
    }
}
