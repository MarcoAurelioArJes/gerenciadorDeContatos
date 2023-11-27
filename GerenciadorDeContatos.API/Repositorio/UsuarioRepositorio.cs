using Microsoft.EntityFrameworkCore;
using GerenciadorDeContatos.API.Model;
using GerenciadorDeContatos.API.Repositorio.BancoDeDados;

namespace GerenciadorDeContatos.API.Repositorio
{
    public class UsuarioRepositorio : ConjuntoDeDados<Usuario>
    {
        public UsuarioRepositorio(ContextoDoBancoDeDados contextoDoBancoDeDados)
        : base(contextoDoBancoDeDados)
        {

        }

        public void Criar(Usuario usuario)
        {
            _conjuntoDeDados.Add(usuario);
            Salvar();
        }

        public Usuario ObterPorEmail(string email)
        {
            return _conjuntoDeDados.Where(u => u.Email == email).FirstOrDefault();
        }

        public Usuario ObterPorId(int id)
        {
            return _conjuntoDeDados.Where(c => c.Id == id).FirstOrDefault();
        }
    }
}
