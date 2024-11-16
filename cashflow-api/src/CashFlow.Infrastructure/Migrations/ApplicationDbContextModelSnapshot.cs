﻿// <auto-generated />
using System;
using CashFlow.Infrastructure.Database.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CashFlow.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("CashFlow.Domain.Entities.Transactions.DailyTransactionHistory", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<decimal>("FinalBalanceAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("InitialAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalCreditAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalDebitAmount")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("DailyTransactionHistory");
                });

            modelBuilder.Entity("CashFlow.Domain.Entities.Transactions.TransactionEntry", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("char(36)");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("TransactionTypeId")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("TransactionTypeId");

                    b.ToTable("TransactionEntry");
                });

            modelBuilder.Entity("CashFlow.Domain.Entities.Types.TransactionType", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id");

                    b.ToTable("TransactionType");

                    b.HasData(
                        new
                        {
                            Id = "initialbalance",
                            Name = "Saldo Inicial"
                        },
                        new
                        {
                            Id = "credit",
                            Name = "Crédito"
                        },
                        new
                        {
                            Id = "debit",
                            Name = "Débito"
                        });
                });

            modelBuilder.Entity("CashFlow.Domain.Entities.Transactions.TransactionEntry", b =>
                {
                    b.HasOne("CashFlow.Domain.Entities.Types.TransactionType", "TransactionType")
                        .WithMany()
                        .HasForeignKey("TransactionTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("TransactionType");
                });
#pragma warning restore 612, 618
        }
    }
}