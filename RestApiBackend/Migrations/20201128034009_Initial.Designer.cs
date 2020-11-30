﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using RestApiBackend;

namespace RestApiBackend.Migrations
{
    [DbContext(typeof(PostgreSqlContext))]
    [Migration("20201128034009_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("RestApiBackend.Colaborador", b =>
                {
                    b.Property<int>("ColaboradorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ColaboradorId");

                    b.ToTable("Colaboradores");
                });

            modelBuilder.Entity("RestApiBackend.Tarea", b =>
                {
                    b.Property<int>("TareaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<int>("ColaboradorId")
                        .HasColumnType("integer");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("FechaFin")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Notas")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Prioridad")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("TareaId");

                    b.HasIndex("ColaboradorId");

                    b.ToTable("Tareas");
                });

            modelBuilder.Entity("RestApiBackend.Tarea", b =>
                {
                    b.HasOne("RestApiBackend.Colaborador", "Colaborador")
                        .WithMany()
                        .HasForeignKey("ColaboradorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Colaborador");
                });
#pragma warning restore 612, 618
        }
    }
}