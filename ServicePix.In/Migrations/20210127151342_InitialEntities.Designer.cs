﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ServicePix.In.Model;

namespace ServicePix.In.Migrations
{
    [DbContext(typeof(spContext))]
    [Migration("20210127151342_InitialEntities")]
    partial class InitialEntities
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("ServicePix.In.Model.Acao", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnType("boolean");

                    b.Property<string>("Caminho")
                        .HasColumnType("text");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DateAlteracao")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Descricao")
                        .HasColumnType("character varying(150)")
                        .HasMaxLength(150);

                    b.Property<string>("Nome")
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<int>("UsuarioCriacao")
                        .HasColumnType("integer");

                    b.Property<int>("UsuarioEdicao")
                        .HasColumnType("integer");

                    b.Property<int>("idCliente")
                        .HasColumnType("integer");

                    b.Property<int>("idMotorAux")
                        .HasColumnType("integer");

                    b.Property<int>("idTipoAcao")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.ToTable("Acao");
                });

            modelBuilder.Entity("ServicePix.In.Model.Cliente", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnType("boolean");

                    b.Property<string>("CNPJ")
                        .HasColumnType("character varying(150)")
                        .HasMaxLength(150);

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DateAlteracao")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Descricao")
                        .HasColumnType("character varying(150)")
                        .HasMaxLength(150);

                    b.Property<string>("Email")
                        .HasColumnType("character varying(150)")
                        .HasMaxLength(150);

                    b.Property<string>("Nome")
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<string>("Url")
                        .HasColumnType("character varying(150)")
                        .HasMaxLength(150);

                    b.Property<int>("UsuarioCriacao")
                        .HasColumnType("integer");

                    b.Property<int>("UsuarioEdicao")
                        .HasColumnType("integer");

                    b.Property<int>("idCliente")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("ServicePix.In.Model.MotorAuxiliar", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DateAlteracao")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Descricao")
                        .HasColumnType("character varying(150)")
                        .HasMaxLength(150);

                    b.Property<string>("Nome")
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<string>("Url")
                        .HasColumnType("text");

                    b.Property<int>("UsuarioCriacao")
                        .HasColumnType("integer");

                    b.Property<int>("UsuarioEdicao")
                        .HasColumnType("integer");

                    b.Property<int>("idCliente")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.ToTable("MotorAuxiliar");
                });

            modelBuilder.Entity("ServicePix.In.Model.Parametro", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnType("boolean");

                    b.Property<string>("Caminho")
                        .HasColumnType("text");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DateAlteracao")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Descricao")
                        .HasColumnType("character varying(150)")
                        .HasMaxLength(150);

                    b.Property<string>("Nome")
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<int>("UsuarioCriacao")
                        .HasColumnType("integer");

                    b.Property<int>("UsuarioEdicao")
                        .HasColumnType("integer");

                    b.Property<int>("idCliente")
                        .HasColumnType("integer");

                    b.Property<int>("idMotorAux")
                        .HasColumnType("integer");

                    b.Property<int>("idTipoAcao")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.ToTable("Parametro");
                });
#pragma warning restore 612, 618
        }
    }
}
