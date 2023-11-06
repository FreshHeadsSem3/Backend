﻿// <auto-generated />
using System;
using FreshHeadBackend.Business;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FreshHeadBackend.Migrations
{
    [DbContext(typeof(DBContext))]
    partial class DBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FreshHeadBackend.Business.Company", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KVK")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("FreshHeadBackend.Business.CompanyImage", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<Guid>("CompanyID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("CompanyID");

                    b.ToTable("CompanyImages");
                });

            modelBuilder.Entity("FreshHeadBackend.Business.Deal", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<DateTime>("ActiveTill")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CategoryID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Claimed")
                        .HasColumnType("int");

                    b.Property<Guid>("CompanyID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaxParticipents")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("CompanyID");

                    b.ToTable("Deals");
                });

            modelBuilder.Entity("FreshHeadBackend.Business.DealCategory", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("DealCategories");
                });

            modelBuilder.Entity("FreshHeadBackend.Business.DealImage", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<Guid>("DealID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("DealID");

                    b.ToTable("DealImages");
                });

            modelBuilder.Entity("FreshHeadBackend.Business.CompanyImage", b =>
                {
                    b.HasOne("FreshHeadBackend.Business.Company", "Company")
                        .WithMany("Images")
                        .HasForeignKey("CompanyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("FreshHeadBackend.Business.Deal", b =>
                {
                    b.HasOne("FreshHeadBackend.Business.DealCategory", "DealCategory")
                        .WithMany("Deals")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FreshHeadBackend.Business.Company", "Company")
                        .WithMany("Deals")
                        .HasForeignKey("CompanyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("DealCategory");
                });

            modelBuilder.Entity("FreshHeadBackend.Business.DealImage", b =>
                {
                    b.HasOne("FreshHeadBackend.Business.Deal", "Deal")
                        .WithMany("Images")
                        .HasForeignKey("DealID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Deal");
                });

            modelBuilder.Entity("FreshHeadBackend.Business.Company", b =>
                {
                    b.Navigation("Deals");

                    b.Navigation("Images");
                });

            modelBuilder.Entity("FreshHeadBackend.Business.Deal", b =>
                {
                    b.Navigation("Images");
                });

            modelBuilder.Entity("FreshHeadBackend.Business.DealCategory", b =>
                {
                    b.Navigation("Deals");
                });
#pragma warning restore 612, 618
        }
    }
}
