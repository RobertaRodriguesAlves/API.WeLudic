﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WeLudic.Infrastructure.Data.Context;

#nullable disable

namespace WeLudic.PublicApi.Migrations
{
    [DbContext(typeof(WeLudicContext))]
    [Migration("20230817092352_Remoção Patient FK RouletteSession")]
    partial class RemoçãoPatientFKRouletteSession
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("WeLudic.Domain.Entities.Patient", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("char(36)");

                    b.Property<string>("AccessToken")
                        .IsUnicode(false)
                        .HasColumnType("longtext");

                    b.Property<bool>("ConfirmAndAgree")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("ExpirationAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("GeneratedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("LastModifiedBy")
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("longtext");

                    b.Property<string>("RefreshToken")
                        .IsUnicode(false)
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("WeLudic.Domain.Entities.RouletteOption", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("LastModifiedBy")
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("longtext");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("RouletteOptions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2023, 8, 17, 9, 23, 52, 302, DateTimeKind.Utc).AddTicks(5623),
                            IsDeleted = false,
                            Name = "DESENHAR O QUE QUISER"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2023, 8, 17, 9, 23, 52, 302, DateTimeKind.Utc).AddTicks(5627),
                            IsDeleted = false,
                            Name = "DESENHAR O QUE O TERAPEUTA PEDIR"
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2023, 8, 17, 9, 23, 52, 302, DateTimeKind.Utc).AddTicks(5628),
                            IsDeleted = false,
                            Name = "DESENHAR MEUS SONHOS"
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(2023, 8, 17, 9, 23, 52, 302, DateTimeKind.Utc).AddTicks(5629),
                            IsDeleted = false,
                            Name = "COLORIR MEUS MEDOS"
                        },
                        new
                        {
                            Id = 5,
                            CreatedAt = new DateTime(2023, 8, 17, 9, 23, 52, 302, DateTimeKind.Utc).AddTicks(5630),
                            IsDeleted = false,
                            Name = "COLORIR MEUS PESADELOS"
                        },
                        new
                        {
                            Id = 6,
                            CreatedAt = new DateTime(2023, 8, 17, 9, 23, 52, 302, DateTimeKind.Utc).AddTicks(5631),
                            IsDeleted = false,
                            Name = "COLORIR UM DESENHO"
                        },
                        new
                        {
                            Id = 7,
                            CreatedAt = new DateTime(2023, 8, 17, 9, 23, 52, 302, DateTimeKind.Utc).AddTicks(5632),
                            IsDeleted = false,
                            Name = "INVENTAR UMA HISTÓRIA"
                        },
                        new
                        {
                            Id = 8,
                            CreatedAt = new DateTime(2023, 8, 17, 9, 23, 52, 302, DateTimeKind.Utc).AddTicks(5633),
                            IsDeleted = false,
                            Name = "CINETERAPIA"
                        },
                        new
                        {
                            Id = 9,
                            CreatedAt = new DateTime(2023, 8, 17, 9, 23, 52, 302, DateTimeKind.Utc).AddTicks(5634),
                            IsDeleted = false,
                            Name = "ATIVIDADE COM A FAMÍLIA TODA"
                        },
                        new
                        {
                            Id = 10,
                            CreatedAt = new DateTime(2023, 8, 17, 9, 23, 52, 302, DateTimeKind.Utc).AddTicks(5635),
                            IsDeleted = false,
                            Name = "ATIVIDADE COM O(S) IRMÃO(S)"
                        },
                        new
                        {
                            Id = 11,
                            CreatedAt = new DateTime(2023, 8, 17, 9, 23, 52, 302, DateTimeKind.Utc).AddTicks(5636),
                            IsDeleted = false,
                            Name = "ATIVIDADE COM OS PAIS"
                        },
                        new
                        {
                            Id = 12,
                            CreatedAt = new DateTime(2023, 8, 17, 9, 23, 52, 302, DateTimeKind.Utc).AddTicks(5637),
                            IsDeleted = false,
                            Name = "ATIVIDADE COM A MÃE"
                        },
                        new
                        {
                            Id = 13,
                            CreatedAt = new DateTime(2023, 8, 17, 9, 23, 52, 302, DateTimeKind.Utc).AddTicks(5649),
                            IsDeleted = false,
                            Name = "ATIVIDADE COM O PAI"
                        },
                        new
                        {
                            Id = 14,
                            CreatedAt = new DateTime(2023, 8, 17, 9, 23, 52, 302, DateTimeKind.Utc).AddTicks(5650),
                            IsDeleted = false,
                            Name = "ATIVIDADE COM A VOVÓ"
                        },
                        new
                        {
                            Id = 15,
                            CreatedAt = new DateTime(2023, 8, 17, 9, 23, 52, 302, DateTimeKind.Utc).AddTicks(5651),
                            IsDeleted = false,
                            Name = "ATIVIDADE COM O VOVÔ"
                        },
                        new
                        {
                            Id = 16,
                            CreatedAt = new DateTime(2023, 8, 17, 9, 23, 52, 302, DateTimeKind.Utc).AddTicks(5652),
                            IsDeleted = false,
                            Name = "ATIVIDADE COM UM AMIGO OU AMIGA"
                        },
                        new
                        {
                            Id = 17,
                            CreatedAt = new DateTime(2023, 8, 17, 9, 23, 52, 302, DateTimeKind.Utc).AddTicks(5653),
                            IsDeleted = false,
                            Name = "DOBRADURA"
                        },
                        new
                        {
                            Id = 18,
                            CreatedAt = new DateTime(2023, 8, 17, 9, 23, 52, 302, DateTimeKind.Utc).AddTicks(5654),
                            IsDeleted = false,
                            Name = "MÍMICA"
                        },
                        new
                        {
                            Id = 19,
                            CreatedAt = new DateTime(2023, 8, 17, 9, 23, 52, 302, DateTimeKind.Utc).AddTicks(5655),
                            IsDeleted = false,
                            Name = "JOGO: O MESTRE MANDOU"
                        },
                        new
                        {
                            Id = 20,
                            CreatedAt = new DateTime(2023, 8, 17, 9, 23, 52, 302, DateTimeKind.Utc).AddTicks(5656),
                            IsDeleted = false,
                            Name = "ESCUTAR UMA MÚSICA"
                        },
                        new
                        {
                            Id = 21,
                            CreatedAt = new DateTime(2023, 8, 17, 9, 23, 52, 302, DateTimeKind.Utc).AddTicks(5657),
                            IsDeleted = false,
                            Name = "BRINCAR DE MEDITAR"
                        },
                        new
                        {
                            Id = 22,
                            CreatedAt = new DateTime(2023, 8, 17, 9, 23, 52, 302, DateTimeKind.Utc).AddTicks(5658),
                            IsDeleted = false,
                            Name = "UTILIZAR BRINQUEDOS ESPECIAIS"
                        },
                        new
                        {
                            Id = 23,
                            CreatedAt = new DateTime(2023, 8, 17, 9, 23, 52, 302, DateTimeKind.Utc).AddTicks(5659),
                            IsDeleted = false,
                            Name = "CONTAR PIADAS"
                        },
                        new
                        {
                            Id = 24,
                            CreatedAt = new DateTime(2023, 8, 17, 9, 23, 52, 302, DateTimeKind.Utc).AddTicks(5660),
                            IsDeleted = false,
                            Name = "CONTAR CHARADAS"
                        },
                        new
                        {
                            Id = 25,
                            CreatedAt = new DateTime(2023, 8, 17, 9, 23, 52, 302, DateTimeKind.Utc).AddTicks(5661),
                            IsDeleted = false,
                            Name = "JOGO: O QUE É O QUE É"
                        },
                        new
                        {
                            Id = 26,
                            CreatedAt = new DateTime(2023, 8, 17, 9, 23, 52, 302, DateTimeKind.Utc).AddTicks(5662),
                            IsDeleted = false,
                            Name = "LER UMA HISTÓRIA"
                        },
                        new
                        {
                            Id = 27,
                            CreatedAt = new DateTime(2023, 8, 17, 9, 23, 52, 302, DateTimeKind.Utc).AddTicks(5663),
                            IsDeleted = false,
                            Name = "OUVIR UMA HISTÓRIA"
                        },
                        new
                        {
                            Id = 28,
                            CreatedAt = new DateTime(2023, 8, 17, 9, 23, 52, 302, DateTimeKind.Utc).AddTicks(5664),
                            IsDeleted = false,
                            Name = "ESCREVER UMA HISTÓRIA"
                        },
                        new
                        {
                            Id = 29,
                            CreatedAt = new DateTime(2023, 8, 17, 9, 23, 52, 302, DateTimeKind.Utc).AddTicks(5665),
                            IsDeleted = false,
                            Name = "USAR CAIXA DE ARTES"
                        },
                        new
                        {
                            Id = 30,
                            CreatedAt = new DateTime(2023, 8, 17, 9, 23, 52, 302, DateTimeKind.Utc).AddTicks(5666),
                            IsDeleted = false,
                            Name = "BRINCAR DE ADIVINHE O DESENHO"
                        },
                        new
                        {
                            Id = 31,
                            CreatedAt = new DateTime(2023, 8, 17, 9, 23, 52, 302, DateTimeKind.Utc).AddTicks(5667),
                            IsDeleted = false,
                            Name = "JOGO: MEMÓRIA & ANIMAIS"
                        },
                        new
                        {
                            Id = 32,
                            CreatedAt = new DateTime(2023, 8, 17, 9, 23, 52, 302, DateTimeKind.Utc).AddTicks(5668),
                            IsDeleted = false,
                            Name = "JOGO: PRECISO DE AJUDA"
                        },
                        new
                        {
                            Id = 33,
                            CreatedAt = new DateTime(2023, 8, 17, 9, 23, 52, 302, DateTimeKind.Utc).AddTicks(5669),
                            IsDeleted = false,
                            Name = "JOGO: GOSTO / NÃO GOSTO"
                        });
                });

            modelBuilder.Entity("WeLudic.Domain.Entities.RouletteSession", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("LastModifiedBy")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("PatientId")
                        .HasColumnType("char(36)");

                    b.Property<int>("RouletteOptionId")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("RouletteOptionId");

                    b.HasIndex("UserId");

                    b.ToTable("RouletteSessions");
                });

            modelBuilder.Entity("WeLudic.Domain.Entities.RouletteSessionOption", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("char(36)");

                    b.Property<int>("RouletteOptionId")
                        .HasColumnType("int");

                    b.Property<Guid>("RouletteSessionId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("RouletteOptionId");

                    b.HasIndex("RouletteSessionId");

                    b.ToTable("RouletteSessionOptions");
                });

            modelBuilder.Entity("WeLudic.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("char(36)");

                    b.Property<string>("AccessToken")
                        .IsUnicode(false)
                        .HasColumnType("longtext");

                    b.Property<bool>("ConfirmAndAgree")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("ExpirationAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("GeneratedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("HashedPassword")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("longtext");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("LastModifiedBy")
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("longtext");

                    b.Property<string>("RefreshToken")
                        .IsUnicode(false)
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WeLudic.Domain.Entities.Patient", b =>
                {
                    b.HasOne("WeLudic.Domain.Entities.User", null)
                        .WithMany("Patients")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WeLudic.Domain.Entities.RouletteOption", b =>
                {
                    b.HasOne("WeLudic.Domain.Entities.User", null)
                        .WithMany("RouletteOptions")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("WeLudic.Domain.Entities.RouletteSession", b =>
                {
                    b.HasOne("WeLudic.Domain.Entities.RouletteOption", null)
                        .WithMany("RouletteSessions")
                        .HasForeignKey("RouletteOptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WeLudic.Domain.Entities.User", null)
                        .WithMany("RouletteSessions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WeLudic.Domain.Entities.RouletteSessionOption", b =>
                {
                    b.HasOne("WeLudic.Domain.Entities.RouletteOption", null)
                        .WithMany("RouletteSessionOptions")
                        .HasForeignKey("RouletteOptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WeLudic.Domain.Entities.RouletteSession", null)
                        .WithMany("RouletteSessionOptions")
                        .HasForeignKey("RouletteSessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WeLudic.Domain.Entities.RouletteOption", b =>
                {
                    b.Navigation("RouletteSessionOptions");

                    b.Navigation("RouletteSessions");
                });

            modelBuilder.Entity("WeLudic.Domain.Entities.RouletteSession", b =>
                {
                    b.Navigation("RouletteSessionOptions");
                });

            modelBuilder.Entity("WeLudic.Domain.Entities.User", b =>
                {
                    b.Navigation("Patients");

                    b.Navigation("RouletteOptions");

                    b.Navigation("RouletteSessions");
                });
#pragma warning restore 612, 618
        }
    }
}
