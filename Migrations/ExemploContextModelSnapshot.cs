﻿// <auto-generated />
using System;
using ControleDeChamado.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ControleDeChamado.Migrations
{
    [DbContext(typeof(ExemploContext))]
    partial class ExemploContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ControleDeChamado.Models.Chamado", b =>
                {
                    b.Property<int>("IdChamado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdChamado"));

                    b.Property<int>("ClassificacaoId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("DataFinal")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DataInicial")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("ExecutanteId")
                        .HasColumnType("integer");

                    b.Property<string>("Prioridade")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("SolicitanteId")
                        .HasColumnType("integer");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("IdChamado");

                    b.HasIndex("ClassificacaoId");

                    b.HasIndex("ExecutanteId");

                    b.HasIndex("SolicitanteId");

                    b.ToTable("Chamados");
                });

            modelBuilder.Entity("ControleDeChamado.Models.Classificacao", b =>
                {
                    b.Property<int>("IdClassificacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdClassificacao"));

                    b.Property<string>("NomeClassificacao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("IdClassificacao");

                    b.ToTable("Classificacao");
                });

            modelBuilder.Entity("ControleDeChamado.Models.Funcionario", b =>
                {
                    b.Property<int>("IdFuncionario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdFuncionario"));

                    b.Property<string>("NomeFuncionario")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("SetorId")
                        .HasColumnType("integer");

                    b.Property<bool>("Status")
                        .HasColumnType("boolean");

                    b.Property<int>("TipoFuncionarioId")
                        .HasColumnType("integer");

                    b.Property<string>("Usuario")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("IdFuncionario");

                    b.HasIndex("SetorId");

                    b.HasIndex("TipoFuncionarioId");

                    b.ToTable("Funcionarios");
                });

            modelBuilder.Entity("ControleDeChamado.Models.Setor", b =>
                {
                    b.Property<int>("IdSetor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdSetor"));

                    b.Property<string>("Funcao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Ramal")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Status")
                        .HasColumnType("boolean");

                    b.HasKey("IdSetor");

                    b.ToTable("Setores");
                });

            modelBuilder.Entity("ControleDeChamado.Models.TipoFuncionario", b =>
                {
                    b.Property<int>("IdTipo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdTipo"));

                    b.Property<string>("NomeTipo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("IdTipo");

                    b.ToTable("TipoFuncionarios");
                });

            modelBuilder.Entity("ControleDeChamado.Models.Chamado", b =>
                {
                    b.HasOne("ControleDeChamado.Models.Classificacao", "Classificacao")
                        .WithMany("Chamados")
                        .HasForeignKey("ClassificacaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ControleDeChamado.Models.Funcionario", "Executante")
                        .WithMany()
                        .HasForeignKey("ExecutanteId");

                    b.HasOne("ControleDeChamado.Models.Funcionario", "Solicitante")
                        .WithMany()
                        .HasForeignKey("SolicitanteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Classificacao");

                    b.Navigation("Executante");

                    b.Navigation("Solicitante");
                });

            modelBuilder.Entity("ControleDeChamado.Models.Funcionario", b =>
                {
                    b.HasOne("ControleDeChamado.Models.Setor", "Setor")
                        .WithMany("Funcionarios")
                        .HasForeignKey("SetorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ControleDeChamado.Models.TipoFuncionario", "FuncionarioTipo")
                        .WithMany()
                        .HasForeignKey("TipoFuncionarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FuncionarioTipo");

                    b.Navigation("Setor");
                });

            modelBuilder.Entity("ControleDeChamado.Models.Classificacao", b =>
                {
                    b.Navigation("Chamados");
                });

            modelBuilder.Entity("ControleDeChamado.Models.Setor", b =>
                {
                    b.Navigation("Funcionarios");
                });
#pragma warning restore 612, 618
        }
    }
}
