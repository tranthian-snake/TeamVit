using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Ice_Cream.Models;
using Microsoft.EntityFrameworkCore;

namespace Ice_Cream
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<StoreDbContext>(
                opts =>
                {
                    opts.UseSqlServer(Configuration["ConnectionStrings:Ice_CreamConnection"]);
                });

            services.AddScoped<IStoreRepository, EFStoreRepository>();
            services.AddRazorPages();

            services.AddDistributedMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseSession();

            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllerRoute(
                //    //name: "default",
                //    //pattern: "{controller=Home}/{action=Index}/{id?}");

                //endpoints.MapControllerRoute("catepage", "{category}/Page{productPage:int}",
                //    new { Controller = "Product", action = "Index" });

                //endpoints.MapControllerRoute("page", "Page{productPage:int}",
                //    new { Controller = "Product", action = "Index", productPage = 1 });

                //endpoints.MapControllerRoute("category", "{category}",
                //    new { Controller = "Product", action = "Index", productPage = 1 });

                //endpoints.MapControllerRoute("pagination", "Products/Page{productPage}",
                //    new { Controller = "Product", action = "Index", productPage = 1 });


                //sửa

                endpoints.MapControllerRoute("catepage", "{category}/Page{productPage:int}",
                    new { Controller = "Recipe", action = "CateRecipe", productPage = 1 });

                endpoints.MapControllerRoute("pagination", "Recipe/Page{productPage}",
                    new { Controller = "Recipe", action = "CateRecipe", productPage = 1 });

                //sửa

                endpoints.MapDefaultControllerRoute();
                endpoints.MapRazorPages();

            });
            SeedData.EnsurePopulated(app);
        }
    }
}
