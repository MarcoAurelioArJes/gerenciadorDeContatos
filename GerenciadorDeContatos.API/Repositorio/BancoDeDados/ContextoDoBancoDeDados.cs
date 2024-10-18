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

            modelBuilder.Entity<Usuario>()
                        .HasMany(c => c.Contatos)
                        .WithOne(c => c.Usuario)
                        .HasForeignKey(c => c.UsuarioID);

            modelBuilder.Entity<Contato>()
                        .HasOne(c => c.Usuario)
                        .WithMany(c => c.Contatos)
                        .HasForeignKey(c => c.UsuarioID);

            modelBuilder.Entity<Contato>()
                        .HasMany(c => c.Telefones)
                        .WithOne(c => c.Contato)
                        .HasForeignKey(c => c.ContatoID);

            modelBuilder.Entity<Telefone>()
                        .HasOne(c => c.Contato)
                        .WithMany(c => c.Telefones)
                        .HasForeignKey(c => c.ContatoID);
        }
    }
}
