using ASP.NET_Core_Bootstrap_Knockout_BookStore.ex.DAL;
using ASP.NET_Core_Bootstrap_Knockout_BookStore.ex.Models;
using ASP.NET_Core_Bootstrap_Knockout_BookStore.ex.Repositories;
using ASP.NET_Core_Bootstrap_Knockout_BookStore.ex.Services;
using ASP.NET_Core_Bootstrap_Knockout_BookStore.ex.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http; // Needed for the SetString and GetString extension methods

namespace ASP.NET_Core_Bootstrap_Knockout_BookStore.ex
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.

            services.AddDbContext<BookStoreDbContext>(options =>
                options.UseSqlServer(Configuration["Data:BookStore:ConnectionString"]));

            services.AddTransient<IAuthorRepository, EFAuthorRepository>();
            services.AddTransient<IBookRepository, EFBookRepository>();
            services.AddTransient<ICategoryRepository, EFCategoryRepository>();
            services.AddTransient<ICartRepository, EFCartRepository>();
            services.AddTransient<ICartItemRepository, EFCartItemRepository>();

            services.AddTransient<IBookService, BookService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<ICartService, CartService>();
            services.AddTransient<ICartItemService, CartItemService>();

            services.AddMvc();

            services.AddDistributedMemoryCache(); // Adds a default in-memory implementation of IDistributedCache
            // ~OR: services.AddMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseSession();   // IMPORTANT: This session call MUST go before UseMvc()
            app.Use((httpContext, nextMiddleware) =>
            {
                // Still for MVC6? This appears to be a minor flaw in ASP.NET, because if this isn’t done, the SessionId appears to be reset at random points.
                httpContext.Session.SetString("__MyAppSession", string.Empty);
                return nextMiddleware();
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            SeedData.EnsurePopulated(app);

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Category, CategoryViewModel>().ReverseMap();
                cfg.CreateMap<Author, AuthorViewModel>().ReverseMap();
                cfg.CreateMap<Book, BookViewModel>().ReverseMap();
                cfg.CreateMap<Cart, CartViewModel>().ReverseMap();
                cfg.CreateMap<CartItem, CartItemViewModel>().ReverseMap();
            });
        }
    }
}
