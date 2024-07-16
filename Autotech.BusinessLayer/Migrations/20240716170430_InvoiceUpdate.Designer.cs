﻿// <auto-generated />
using System;
using Autotech.BusinessLayer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Autotech.BusinessLayer.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240716170430_InvoiceUpdate")]
    partial class InvoiceUpdate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Autotech.Core.Models.AccountDetails", b =>
                {
                    b.Property<Guid?>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("LitersOrdered")
                        .HasColumnType("float");

                    b.Property<int>("OpenReceipts")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("AccountDetails");
                });

            modelBuilder.Entity("Autotech.Core.Models.Accounts", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cluster")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactPerson")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("DiscountPercent")
                        .HasColumnType("float");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Terms")
                        .HasColumnType("int");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Accounts", (string)null);
                });

            modelBuilder.Entity("Autotech.Core.Models.Agents", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AgentAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AgentContactNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AgentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AgentRole")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateLastLogin")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Agents", (string)null);
                });

            modelBuilder.Entity("Autotech.Core.Models.InvoicePayments", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AccountName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<double>("Payment")
                        .HasColumnType("float");

                    b.Property<Guid>("SalesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Terms")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Invoices", (string)null);
                });

            modelBuilder.Entity("Autotech.Core.Models.ItemDetails", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("BataanRetail")
                        .HasColumnType("float");

                    b.Property<double>("BataanWholeSale")
                        .HasColumnType("float");

                    b.Property<Guid>("ItemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("ItemsSold")
                        .HasColumnType("float");

                    b.Property<double>("OnHand")
                        .HasColumnType("float");

                    b.Property<double>("PampangaRetail")
                        .HasColumnType("float");

                    b.Property<double>("PampangaWholeSale")
                        .HasColumnType("float");

                    b.Property<double>("Sales")
                        .HasColumnType("float");

                    b.Property<double>("ZambalesRetail")
                        .HasColumnType("float");

                    b.Property<double>("ZambalesWholeSale")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("ItemDetails", (string)null);
                });

            modelBuilder.Entity("Autotech.Core.Models.Items", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ItemCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ItemDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ItemName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Items", (string)null);
                });

            modelBuilder.Entity("Autotech.Core.Models.Locations", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("LocationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Locations", (string)null);
                });

            modelBuilder.Entity("Autotech.Core.Models.Sales", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AccountName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Agent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cluster")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateSold")
                        .HasColumnType("datetime2");

                    b.Property<double>("DiscountPercent")
                        .HasColumnType("float");

                    b.Property<double>("DiscountPeso")
                        .HasColumnType("float");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PaymentType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("RemainingBalance")
                        .HasColumnType("float");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Tax")
                        .HasColumnType("float");

                    b.Property<int>("Terms")
                        .HasColumnType("int");

                    b.Property<double>("TotalLiters")
                        .HasColumnType("float");

                    b.Property<double>("TotalSales")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Sales", (string)null);
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

            modelBuilder.Entity("Autotech.Core.Models.Accounts", b =>
                {
                    b.Navigation("AccountDetails")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
