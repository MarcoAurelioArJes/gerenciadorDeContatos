using Microsoft.EntityFrameworkCore;
using GerenciadorDeContatos.API.Model;
using GerenciadorDeContatos.API.Repositorio.BancoDeDados;

namespace GerenciadorDeContatos.API.Repositorio
{
    public class ContatoRepositorio : ConjuntoDeDados<Contato>
    {
        public ContatoRepositorio(ContextoDoBancoDeDados contextoDoBancoDeDados)
        : base(contextoDoBancoDeDados)
        {

        }

        public void Atualizar(Contato novoContato)
        {
            _conjuntoDeDados.Entry(novoContato).State = EntityState.Modified;
            _conjuntoDeDados.Update(novoContato);
            Salvar();
        }

        public void Criar(Contato objeto)
        {
            _conjuntoDeDados.Add(objeto);
            Salvar();
        }

        public Contato ObterPorId(int id)
        {
            return _conjuntoDeDados
                .Include(c => c.Telefones)
                .Where(c => c.Id == id).FirstOrDefault();
        }

        public List<Contato> ObterTodos()
        {
            return _conjuntoDeDados.ToList();
        }

        public Contato ObterPorEmail(string email)
        {
            return _conjuntoDeDados.FirstOrDefault(c => email.Equals(c.Email));
        }

        public void Remover(Contato contato)
        {
            if (contato != null)
            {
                _conjuntoDeDados.Entry(contato).State = EntityState.Deleted;
                _conjuntoDeDados.Remove(contato);
                Salvar();
            }
        }

        public void AtualizarTelefone(Telefone telefone)
        {
            var dbSetTelefone = _contextoDoBancoDeDados.Set<Telefone>();
            dbSetTelefone.Entry(telefone).State = EntityState.Modified;
            dbSetTelefone.Update(telefone);
            Salvar();
        }
    }
}
