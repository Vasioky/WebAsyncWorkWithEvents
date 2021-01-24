﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAPI1.Models;

namespace WebAPI1.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210124205937_mig1")]
    partial class mig1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.11");

            modelBuilder.Entity("WebAPI1.Models.Batch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("InternalData")
                        .HasColumnType("TEXT");

                    b.Property<int?>("Result")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("WorkId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("WorkId");

                    b.ToTable("Batches");
                });

            modelBuilder.Entity("WebAPI1.Models.Work", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<int>("X")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Y")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Works");
                });

            modelBuilder.Entity("WebAPI1.Models.Batch", b =>
                {
                    b.HasOne("WebAPI1.Models.Work", null)
                        .WithMany("Batches")
                        .HasForeignKey("WorkId");
                });
#pragma warning restore 612, 618
        }
    }
}