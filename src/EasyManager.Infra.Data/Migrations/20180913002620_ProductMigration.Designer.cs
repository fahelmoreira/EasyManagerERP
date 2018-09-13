﻿// <auto-generated />
using System;
using EasyManager.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EasyManager.Infra.Data.Migrations
{
    [DbContext(typeof(EasyManagerContext))]
    [Migration("20180913002620_ProductMigration")]
    partial class ProductMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.2-rtm-30932")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EasyManager.Domain.Models.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("ChildCategoryId");

                    b.Property<string>("Description");

                    b.Property<string>("Location");

                    b.HasKey("Id");

                    b.HasIndex("ChildCategoryId")
                        .IsUnique()
                        .HasFilter("[ChildCategoryId] IS NOT NULL");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("EasyManager.Domain.Models.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<bool>("Active");

                    b.Property<string>("Address");

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("Code");

                    b.Property<string>("Contacts");

                    b.Property<string>("CorporateName")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("CorporateTaxpayerId");

                    b.Property<double>("CreditLimit");

                    b.Property<string>("Email");

                    b.Property<string>("FatherName");

                    b.Property<int>("Gender");

                    b.Property<string>("IndividualTaxpayerId");

                    b.Property<int>("MaritalStatus");

                    b.Property<string>("MotherName");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("Profession");

                    b.Property<bool>("ReceiveEmail");

                    b.Property<string>("TradeName")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("EasyManager.Domain.Models.Manufacture", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("Address");

                    b.Property<string>("Contacts");

                    b.Property<string>("CorporateName");

                    b.Property<string>("CorporateTaxpayerId");

                    b.Property<string>("Email");

                    b.Property<string>("IndividualTaxpayerId");

                    b.Property<string>("Name");

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("TradeName");

                    b.HasKey("Id");

                    b.ToTable("Manufactures");
                });

            modelBuilder.Entity("EasyManager.Domain.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<bool>("Active");

                    b.Property<string>("Attributes");

                    b.Property<string>("Barcode");

                    b.Property<Guid?>("CategoryId");

                    b.Property<double>("Comission");

                    b.Property<double>("Consumption");

                    b.Property<double>("Cost");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<double>("Height");

                    b.Property<double>("Immobilized");

                    b.Property<string>("InternalCode");

                    b.Property<double>("Length");

                    b.Property<Guid?>("ManufactureId");

                    b.Property<string>("Observations");

                    b.Property<double>("OtherExpenses");

                    b.Property<int>("ProductType");

                    b.Property<double>("Resale");

                    b.Property<double>("ResaleMax");

                    b.Property<double>("ResaleMin");

                    b.Property<string>("SalesTable");

                    b.Property<bool>("SoldSeparately");

                    b.Property<double>("Weight");

                    b.Property<double>("Width");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ManufactureId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("EasyManager.Domain.Models.ProductBundle", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Amount");

                    b.Property<Guid?>("ProductId");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductBundle");
                });

            modelBuilder.Entity("EasyManager.Domain.Models.SalesTable", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<double>("Price");

                    b.Property<double>("Profit");

                    b.HasKey("Id");

                    b.ToTable("SalesTables");
                });

            modelBuilder.Entity("EasyManager.Domain.Models.Category", b =>
                {
                    b.HasOne("EasyManager.Domain.Models.Category", "ChildCategory")
                        .WithOne("ParentCategory")
                        .HasForeignKey("EasyManager.Domain.Models.Category", "ChildCategoryId");
                });

            modelBuilder.Entity("EasyManager.Domain.Models.Product", b =>
                {
                    b.HasOne("EasyManager.Domain.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.HasOne("EasyManager.Domain.Models.Manufacture", "Manufacture")
                        .WithMany()
                        .HasForeignKey("ManufactureId");
                });

            modelBuilder.Entity("EasyManager.Domain.Models.ProductBundle", b =>
                {
                    b.HasOne("EasyManager.Domain.Models.Product", "Product")
                        .WithMany("Bundles")
                        .HasForeignKey("ProductId");
                });
#pragma warning restore 612, 618
        }
    }
}
