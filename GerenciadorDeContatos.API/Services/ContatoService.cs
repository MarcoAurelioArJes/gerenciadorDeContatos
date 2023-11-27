using GerenciadorDeContatos.API.Model;
using GerenciadorDeContatos.API.Repositorio;
using GerenciadorDeContatos.API.Model.DTOs.Telefone;
using GerenciadorDeContatos.API.Services.ValidacoesService;

namespace GerenciadorDeContatos.API.Services
{
    public class ContatoService
    {
        private ContatoRepositorio _contatoRepositorio;
        private ValidarContatoService _validarContatoService;
        public ContatoService(ContatoRepositorio contatoRepositorio,
                              ValidarContatoService validarContatoService)
        {
            _contatoRepositorio = contatoRepositorio;
            _validarContatoService = validarContatoService;
        }
        
        public void Atualizar(int id, Contato novoContato)
        {
            novoContato.VerificarSeObjetoEhNulo();

            var contato = ObterPorId(id);
            contato.Nome = novoContato.Nome;
            contato.Email = novoContato.Email;

            _validarContatoService.Validar(contato);
            _contatoRepositorio.Atualizar(contato);
        }

        public void Criar(Contato contato)
        {
            contato.VerificarSeObjetoEhNulo();
            _validarContatoService.Validar(contato);

            contato.Telefones.ForEach(t => { t.Contato = contato; });
            _contatoRepositorio.Criar(contato);
        }

        public Contato ObterPorId(int id)
        {
            var contato = _contatoRepositorio.ObterPorId(id);
            if (contato is null)
                throw new BadHttpRequestException("Contato não encontrado", StatusCodes.Status404NotFound);

            return contato;
        }

        public List<Contato> ObterTodos()
        {
            var contatos = _contatoRepositorio.ObterTodos().ToList();
            if (contatos is null)
                throw new BadHttpRequestException("Não existem contatos", StatusCodes.Status404NotFound);

            return contatos;
        }

        public void Remover(int id)
        {
            var contato = ObterPorId(id);
            _contatoRepositorio.Remover(contato);
        }

        public Contato ObterPorEmail(string email)
        {
            return _contatoRepositorio.ObterPorEmail(email);
        }

        public void AtualizarTelefone(int idContato, int idTelefone, NovoTelefoneInput telefoneInput)
        {
            telefoneInput.VerificarSeObjetoEhNulo();

            var contato = ObterPorId(idContato);
            var telefone = contato.Telefones.FirstOrDefault(t => t.Id == idTelefone);

            if (telefone is null)
                throw new BadHttpRequestException("Telefone não encontrado", StatusCodes.Status404NotFound);

            telefone.DDD = telefoneInput.DDD;
            telefone.Numero = telefoneInput.Numero;
            telefone.TipoFone = telefoneInput.TipoFone;

            _contatoRepositorio.AtualizarTelefone(telefone);
        }
    }
}
