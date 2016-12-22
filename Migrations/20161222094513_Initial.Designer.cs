using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ASP.NET_Core_Bootstrap_Knockout_BookStore.ex.DAL;

namespace ASP.NET_Core_Bootstrap_Knockout_BookStore.ex.Migrations
{
    [DbContext(typeof(BookStoreDbContext))]
    [Migration("20161222094513_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ASP.NET_Core_Bootstrap_Knockout_BookStore.ex.Models.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Biography");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.HasKey("Id");

                    b.ToTable("Author");
                });

            modelBuilder.Entity("ASP.NET_Core_Bootstrap_Knockout_BookStore.ex.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AuthorId");

                    b.Property<int>("CategoryId");

                    b.Property<string>("Description");

                    b.Property<bool>("Featured");

                    b.Property<string>("ImageUrl");

                    b.Property<string>("Isbn");

                    b.Property<decimal>("ListPrice");

                    b.Property<decimal>("SalePrice");

                    b.Property<string>("Synopsis");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Book");
                });

            modelBuilder.Entity("ASP.NET_Core_Bootstrap_Knockout_BookStore.ex.Models.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("SessionId")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Cart");
                });

            modelBuilder.Entity("ASP.NET_Core_Bootstrap_Knockout_BookStore.ex.Models.CartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BookId");

                    b.Property<int>("CartId");

                    b.Property<int>("Quantity");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("CartId", "BookId")
                        .IsUnique();

                    b.ToTable("CartItem");
                });

            modelBuilder.Entity("ASP.NET_Core_Bootstrap_Knockout_BookStore.ex.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("ASP.NET_Core_Bootstrap_Knockout_BookStore.ex.Models.Book", b =>
                {
                    b.HasOne("ASP.NET_Core_Bootstrap_Knockout_BookStore.ex.Models.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ASP.NET_Core_Bootstrap_Knockout_BookStore.ex.Models.Category", "Category")
                        .WithMany("Books")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ASP.NET_Core_Bootstrap_Knockout_BookStore.ex.Models.CartItem", b =>
                {
                    b.HasOne("ASP.NET_Core_Bootstrap_Knockout_BookStore.ex.Models.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ASP.NET_Core_Bootstrap_Knockout_BookStore.ex.Models.Cart", "Cart")
                        .WithMany("CartItems")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
