using CacheLayer;
using CoreLayer.Interfaces.Repository;
using CoreLayer.Interfaces.Services;
using CoreLayer.Interfaces.UnitOfWork;
using DataLayer;
using DataLayer.Repository;
using DataLayer.UnitOfWork;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ServiceLayer.Maping;
using ServiceLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alısveris
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<Data>(opt =>
            {
                opt.UseSqlServer(
    Configuration.GetConnectionString("LCdb"), sqlOption =>
    {
        sqlOption.MigrationsAssembly("DataLayer");
    });
            });

            


            services.AddScoped(typeof(IService<>), typeof(Service<>));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAltKategoriRepository, AltKategoriRepository>();
            services.AddScoped<IAltKategoriService, AltKategoriService>();
            services.AddScoped<IUrunRepository, UrunRepository>();
            services.AddScoped<IUrunService, UrunServiceWithCaching>();
            services.AddScoped<ISepetRepository, SepetRepository>();
            services.AddScoped<ISepetService, SepetService>();
            services.AddScoped<IUyeRepository, UyeRepository>();
            services.AddScoped<IUyeService, UyeService>();
            services.AddScoped<IKategoriRepository, KategoriRepository>();
            services.AddScoped<IKategoriService, KategoriService>();
            services.AddScoped<IFaturaRepository, FaturaRepository>();
            services.AddScoped<IFaturaService, FaturaService>();
           
            services.AddAutoMapper(typeof(MapProfile));
            services.AddMemoryCache();
           
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
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
