using Microsoft.EntityFrameworkCore;

namespace GerenciadorDeContatos.API.Repositorio.BancoDeDados
{
    public abstract class ConjuntoDeDados<T> where T : class
    {
        public ContextoDoBancoDeDados _contextoDoBancoDeDados;
        public DbSet<T> _conjuntoDeDados;

        public ConjuntoDeDados(ContextoDoBancoDeDados contextoDoBancoDeDados)
        {
            _contextoDoBancoDeDados = contextoDoBancoDeDados;
            _conjuntoDeDados = _contextoDoBancoDeDados.Set<T>();
        }

        public void Salvar()
        {
            _contextoDoBancoDeDados.SaveChanges();
        }
    }
}
