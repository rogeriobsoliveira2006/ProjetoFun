﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Projeto.Repository.Impl.Context;

namespace Projeto.Repository.Impl.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20190428013452_CreateCoreDB")]
    partial class CreateCoreDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Projeto.Entities.Dependente", b =>
                {
                    b.Property<int>("DependenteId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataNascimento");

                    b.Property<int>("FuncionarioId");

                    b.Property<string>("Nome")
                        .HasMaxLength(50);

                    b.HasKey("DependenteId");

                    b.HasIndex("FuncionarioId");

                    b.ToTable("Dependente");
                });

            modelBuilder.Entity("Projeto.Entities.Funcionario", b =>
                {
                    b.Property<int>("FuncionarioId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataAdmissao");

                    b.Property<string>("Nome")
                        .HasMaxLength(50);

                    b.Property<decimal>("Salario");

                    b.HasKey("FuncionarioId");

                    b.ToTable("Funcionario");
                });

            modelBuilder.Entity("Projeto.Entities.Dependente", b =>
                {
                    b.HasOne("Projeto.Entities.Funcionario", "Funcionario")
                        .WithMany("Dependentes")
                        .HasForeignKey("FuncionarioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
