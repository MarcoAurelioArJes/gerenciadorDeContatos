using Microsoft.EntityFrameworkCore;
using GerenciadorDeContatos.API.Model;

namespace GerenciadorDeContatos.API.Repositorio.BancoDeDados
{
    public class ContextoDoBancoDeDados : DbContext
    {
        public ContextoDoBancoDeDados(DbContextOptions options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>()
                        .HasKey(u => u.Id);

            modelBuilder.Entity<Contato>()
                        .HasKey(c => c.Id);

            modelBuilder.Entity<Telefone>()
                        .HasKey(c => c.Id);

            modelBuilder.Entity<Telefone>()
                        .HasOne(c => c.Contato)
                        .WithMany()
                        .HasForeignKey(c => c.ContatoID)
                        .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
