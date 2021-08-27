﻿// <auto-generated />
using MVCProductsAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MVCProductsAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.9");

            modelBuilder.Entity("MVCProductsAPI.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Title = "Outros"
                        },
                        new
                        {
                            Id = 2,
                            Title = "Alimentos"
                        },
                        new
                        {
                            Id = 3,
                            Title = "Bebidas"
                        });
                });

            modelBuilder.Entity("MVCProductsAPI.Models.Products", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(1024)
                        .HasColumnType("varchar(1024)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Description = "Apenas um caderno comum",
                            Price = 7.50m,
                            Title = "Caderno"
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            Description = "Apenas um lápis",
                            Price = 1.50m,
                            Title = "Lápis"
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 2,
                            Description = "Apenas um salgadinho",
                            Price = 5.29m,
                            Title = "Salgadinho"
                        });
                });

            modelBuilder.Entity("MVCProductsAPI.Models.Products", b =>
                {
                    b.HasOne("MVCProductsAPI.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}
