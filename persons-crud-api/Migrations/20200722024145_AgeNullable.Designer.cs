﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using persons_crud_api;

namespace persons_crud_api.Migrations
{
    [DbContext(typeof(PersonContext))]
    [Migration("20200722024145_AgeNullable")]
    partial class AgeNullable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("persons_crud_api.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Address")
                        .HasColumnName("address")
                        .HasColumnType("character varying(400)")
                        .HasMaxLength(400);

                    b.Property<int?>("Age")
                        .HasColumnName("age")
                        .HasColumnType("integer");

                    b.Property<string>("LastName")
                        .HasColumnName("last_name")
                        .HasColumnType("character varying(60)")
                        .HasMaxLength(60);

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.Property<int>("Rut")
                        .HasColumnName("rut")
                        .HasColumnType("integer");

                    b.Property<char>("Vd")
                        .HasColumnName("vd")
                        .HasColumnType("character(1)");

                    b.HasKey("Id")
                        .HasName("pk_persons");

                    b.ToTable("persons");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Augustgrad 4112, Korhal",
                            Age = 42,
                            LastName = "Raynor",
                            Name = "Jimmy",
                            Rut = 9810616,
                            Vd = '2'
                        },
                        new
                        {
                            Id = 2,
                            Address = "Talematros 243, Shakuras",
                            Age = 38,
                            LastName = "Kerrigan",
                            Name = "Sarah",
                            Rut = 11832947,
                            Vd = '3'
                        });
                });
#pragma warning restore 612, 618
        }
    }
}