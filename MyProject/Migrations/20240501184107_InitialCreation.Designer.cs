﻿// <auto-generated />
using System;
using Comidas.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MyProject.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240501184107_InitialCreation")]
    partial class InitialCreation
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.17");

            modelBuilder.Entity("Comidas.Models.Comida", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Creator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("FrutosMar")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Comidas");
                });
#pragma warning restore 612, 618
        }
    }
}
