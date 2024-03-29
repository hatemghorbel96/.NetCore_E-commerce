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
    [Migration("20210103204326_Commandes")]
    partial class Commandes
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

            modelBuilder.Entity("webGestionvente2.Models.Commande", b =>
                {
                    b.Property<int>("CommandeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Adresse")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Codepostal")
                        .HasColumnType("int");

                    b.Property<decimal>("Commandetotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Datecommande")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Numtel")
                        .HasColumnType("int");

                    b.Property<string>("Pays")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ville")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CommandeId");

                    b.ToTable("Commandes");
                });

            modelBuilder.Entity("webGestionvente2.Models.CommandeDetail", b =>
                {
                    b.Property<int>("CommandeDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("ArticleID")
                        .HasColumnType("int");

                    b.Property<int>("CommandeId")
                        .HasColumnType("int");

                    b.Property<int>("Montant")
                        .HasColumnType("int");

                    b.Property<decimal>("Prix")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("CommandeDetailId");

                    b.HasIndex("ArticleID");

                    b.HasIndex("CommandeId");

                    b.ToTable("CommandeDetails");
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

            modelBuilder.Entity("webGestionvente2.Models.CommandeDetail", b =>
                {
                    b.HasOne("webGestionvente2.Models.Article", "Article")
                        .WithMany()
                        .HasForeignKey("ArticleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webGestionvente2.Models.Commande", "Commande")
                        .WithMany("Lignecommande")
                        .HasForeignKey("CommandeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Article");

                    b.Navigation("Commande");
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

            modelBuilder.Entity("webGestionvente2.Models.Commande", b =>
                {
                    b.Navigation("Lignecommande");
                });
#pragma warning restore 612, 618
        }
    }
}
