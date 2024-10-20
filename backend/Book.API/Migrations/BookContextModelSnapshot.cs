﻿// <auto-generated />
using System;
using Book.API.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Book.API.Migrations
{
    [DbContext(typeof(BookContext))]
    partial class BookContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Book.API.Entities.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsInStock")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a56c6700-c556-4345-ae64-f56babbfd5de"),
                            Author = "Author A",
                            IsInStock = true,
                            Title = "Book One"
                        },
                        new
                        {
                            Id = new Guid("f0816a79-543b-42a8-b6e2-fa24cb228aba"),
                            Author = "Author B",
                            IsInStock = false,
                            Title = "Book Two"
                        });
                });

            modelBuilder.Entity("Book.API.Entities.Page", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BookId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PageNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.ToTable("Pages");

                    b.HasData(
                        new
                        {
                            Id = new Guid("8785b229-efec-4360-8572-1529cc210e9e"),
                            BookId = new Guid("a56c6700-c556-4345-ae64-f56babbfd5de"),
                            Content = "Content of page 1 in Book One",
                            PageNumber = 1
                        },
                        new
                        {
                            Id = new Guid("6dfdf426-5529-49d2-be1d-9e3b9fdc3485"),
                            BookId = new Guid("a56c6700-c556-4345-ae64-f56babbfd5de"),
                            Content = "Content of page 2 in Book One",
                            PageNumber = 2
                        },
                        new
                        {
                            Id = new Guid("0ef336f4-bf0a-40ba-bb9e-70b2298aadd8"),
                            BookId = new Guid("f0816a79-543b-42a8-b6e2-fa24cb228aba"),
                            Content = "Content of page 1 in Book Two",
                            PageNumber = 1
                        },
                        new
                        {
                            Id = new Guid("8ee36fb7-92e3-46d9-af52-8f5a4781857b"),
                            BookId = new Guid("f0816a79-543b-42a8-b6e2-fa24cb228aba"),
                            Content = "Content of page 2 in Book Two",
                            PageNumber = 2
                        });
                });

            modelBuilder.Entity("Book.API.Entities.Page", b =>
                {
                    b.HasOne("Book.API.Entities.Book", "Book")
                        .WithMany("Pages")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");
                });

            modelBuilder.Entity("Book.API.Entities.Book", b =>
                {
                    b.Navigation("Pages");
                });
#pragma warning restore 612, 618
        }
    }
}
