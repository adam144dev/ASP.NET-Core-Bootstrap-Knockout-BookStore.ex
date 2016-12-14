using Microsoft.AspNetCore.Builder;
using System.Linq;
using ASP.NET_Core_Bootstrap_Knockout_BookStore.ex.Models;
using Microsoft.Extensions.DependencyInjection;

namespace ASP.NET_Core_Bootstrap_Knockout_BookStore.ex.DAL
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            var context = app.ApplicationServices.GetRequiredService<BookStoreDbContext>();

            if (context.Categories.Any())
                return;

            var categories = new Category[]
            {
                new Category { Name = "Category1"},
                new Category { Name = "Category2"},
                new Category { Name = "Category3"},
                new Category { Name = "Category4"}
            };

            var authors = new Author[]
            {
                new Author{
                    FirstName = "FirstName1",
                    LastName = "LastName1",
                    Biography = "Biography1"
                },
                new Author{
                    FirstName = "FirstName2",
                    LastName = "LastName2",
                    Biography = "Biography2"
                },
            };

            var books = new Book[]
            {
                new Book
                {
                    Title = "Title11",
                    Isbn = "Isbn11",
                    Synopsis = "Synopsis11",
                    Description = "Description11",
                    ImageUrl = "ImageUrl11",
                    ListPrice = 1.1M,
                    SalePrice = 1.11M,
                    Featured = false,
                    Author = authors[0],
                    Category = categories[0]
                },
                new Book
                {
                    Title = "Title12",
                    Isbn = "Isbn12",
                    Synopsis = "Synopsis12",
                    Description = "Description12",
                    ImageUrl = "ImageUrl12",
                    ListPrice = 1.2M,
                    SalePrice = 1.12M,
                    Featured = true,
                    Author = authors[0],
                    Category = categories[0]
                },
                new Book
                {
                    Title = "Title21",
                    Isbn = "Isbn21",
                    Synopsis = "Synopsis21",
                    Description = "Description21",
                    ImageUrl = "ImageUrl21",
                    ListPrice = 2.1M,
                    SalePrice = 2.21M,
                    Featured = false,
                    Author = authors[1],
                    Category = categories[1]
                },
                new Book
                {
                    Title = "Title22",
                    Isbn = "Isbn22",
                    Synopsis = "Synopsis22",
                    Description = "Description22",
                    ImageUrl = "ImageUrl22",
                    ListPrice = 2.2M,
                    SalePrice = 2.22M,
                    Featured = true,
                    Author = authors[1],
                    Category = categories[2]
                }
            };

            context.Categories.AddRange(categories);
            context.Authors.AddRange(authors);
            context.Books.AddRange(books);
            context.SaveChanges();
        }
    }
}
