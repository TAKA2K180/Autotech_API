﻿// <auto-generated />
using System;
using Autotech.BusinessLayer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Autotech.Main.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240715164405_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Autotech.Core.Models.BaseModel", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("BaseModel");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("Autotech.Core.Models.AccountDetails", b =>
                {
                    b.HasBaseType("Autotech.Core.Models.BaseModel");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("LitersOrdered")
                        .HasColumnType("real");

                    b.Property<int>("OpenReceipts")
                        .HasColumnType("int");

                    b.ToTable("AccountDetails");
                });

            modelBuilder.Entity("Autotech.Core.Models.Accounts", b =>
                {
                    b.HasBaseType("Autotech.Core.Models.BaseModel");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cluster")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactPerson")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("DiscountPercent")
                        .HasColumnType("float");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Terms")
                        .HasColumnType("int");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("Autotech.Core.Models.Product", b =>
                {
                    b.HasBaseType("Autotech.Core.Models.BaseModel");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Products", (string)null);
                });

            modelBuilder.Entity("Autotech.Core.Models.AccountDetails", b =>
                {
                    b.HasOne("Autotech.Core.Models.Accounts", "Accounts")
                        .WithOne("AccountDetails")
                        .HasForeignKey("Autotech.Core.Models.AccountDetails", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Accounts");
                });

            modelBuilder.Entity("Autotech.Core.Models.Product", b =>
                {
                    b.HasOne("Autotech.Core.Models.BaseModel", null)
                        .WithOne()
                        .HasForeignKey("Autotech.Core.Models.Product", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Autotech.Core.Models.Accounts", b =>
                {
                    b.Navigation("AccountDetails")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
