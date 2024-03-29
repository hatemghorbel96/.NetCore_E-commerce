﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using webGestionvente2.Models;

namespace webGestionvente2.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210103110715_articlepan")]
    partial class articlepan
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("webGestionvente2.Models.Article", b =>
                {
                    b.Property<int>("ArticleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("categorieId")
                        .HasColumnType("int");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("imagepath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("instock")
                        .HasColumnType("bit");

                    b.Property<string>("nomArticle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("prix")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ArticleID");

                    b.HasIndex("categorieId");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("webGestionvente2.Models.Categorie", b =>
                {
                    b.Property<int>("CategorieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("categorieName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategorieId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("webGestionvente2.Models.PanierArticle", b =>
                {
                    b.Property<int>("PanierArticleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("ArticleID")
                        .HasColumnType("int");

                    b.Property<int>("Montant")
                        .HasColumnType("int");

                    b.Property<string>("PanierId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PanierArticleId");

                    b.HasIndex("ArticleID");

                    b.ToTable("PanierArticles");
                });

            modelBuilder.Entity("webGestionvente2.Models.Article", b =>
                {
                    b.HasOne("webGestionvente2.Models.Categorie", "Categorie")
                        .WithMany("Articles")
                        .HasForeignKey("categorieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categorie");
                });

            modelBuilder.Entity("webGestionvente2.Models.PanierArticle", b =>
                {
                    b.HasOne("webGestionvente2.Models.Article", "Article")
                        .WithMany()
                        .HasForeignKey("ArticleID");

                    b.Navigation("Article");
                });

            modelBuilder.Entity("webGestionvente2.Models.Categorie", b =>
                {
                    b.Navigation("Articles");
                });
#pragma warning restore 612, 618
        }
    }
}
