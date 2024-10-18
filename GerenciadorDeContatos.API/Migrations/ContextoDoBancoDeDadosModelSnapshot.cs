﻿// <auto-generated />
using System;
using GerenciadorDeContatos.API.Repositorio.BancoDeDados;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GerenciadorDeContatos.API.Migrations
{
    [DbContext(typeof(ContextoDoBancoDeDados))]
    partial class ContextoDoBancoDeDadosModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.14");

            modelBuilder.Entity("GerenciadorDeContatos.API.Model.Contato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("UsuarioID")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioID");

                    b.ToTable("Contato");
                });

            modelBuilder.Entity("GerenciadorDeContatos.API.Model.Telefone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ContatoID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("DDD")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("TipoFone")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ContatoID");

                    b.ToTable("Telefone");
                });

            modelBuilder.Entity("GerenciadorDeContatos.API.Model.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Cargo")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("GerenciadorDeContatos.API.Model.Contato", b =>
                {
                    b.HasOne("GerenciadorDeContatos.API.Model.Usuario", "Usuario")
                        .WithMany("Contatos")
                        .HasForeignKey("UsuarioID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("GerenciadorDeContatos.API.Model.Telefone", b =>
                {
                    b.HasOne("GerenciadorDeContatos.API.Model.Contato", "Contato")
                        .WithMany("Telefones")
                        .HasForeignKey("ContatoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contato");
                });

            modelBuilder.Entity("GerenciadorDeContatos.API.Model.Contato", b =>
                {
                    b.Navigation("Telefones");
                });

            modelBuilder.Entity("GerenciadorDeContatos.API.Model.Usuario", b =>
                {
                    b.Navigation("Contatos");
                });
#pragma warning restore 612, 618
        }
    }
}
