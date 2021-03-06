// <auto-generated />
using System;
using EF_CORE_NT_BROKER.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EF_CORE_NT_BROKER.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210911064033_dbset")]
    partial class dbset
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BrokerCompany", b =>
                {
                    b.Property<int>("BrokersId")
                        .HasColumnType("int");

                    b.Property<int>("CompaniesId")
                        .HasColumnType("int");

                    b.HasKey("BrokersId", "CompaniesId");

                    b.HasIndex("CompaniesId");

                    b.ToTable("BrokerCompany");
                });

            modelBuilder.Entity("EF_CORE_NT_BROKER.Models.Broker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Brokers");
                });

            modelBuilder.Entity("EF_CORE_NT_BROKER.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("BrokerId")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("BrokerCompany", b =>
                {
                    b.HasOne("EF_CORE_NT_BROKER.Models.Broker", null)
                        .WithMany()
                        .HasForeignKey("BrokersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EF_CORE_NT_BROKER.Models.Company", null)
                        .WithMany()
                        .HasForeignKey("CompaniesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
