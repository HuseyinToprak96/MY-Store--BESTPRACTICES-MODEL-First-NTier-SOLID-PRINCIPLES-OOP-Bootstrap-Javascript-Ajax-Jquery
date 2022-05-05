using AppAPI.Filters;
using CacheLayer;
using CoreLayer.Interfaces.Repository;
using CoreLayer.Interfaces.Services;
using CoreLayer.Interfaces.UnitOfWork;
using DataLayer;
using DataLayer.Repository;
using DataLayer.UnitOfWork;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ServiceLayer.Maping;
using ServiceLayer.Services;
using ServiceLayer.Validations;
using System;
using System.Reflection;

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
            services.AddControllers(opt => opt.Filters.Add(new ValidateFilterAttribute())).AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<UyeDtoValidator>());

            
            services.AddDbContext<Data>(opt =>
            {
                opt.UseSqlServer(
    Configuration.GetConnectionString("LCdb"), sqlOption =>
    {
        sqlOption.MigrationsAssembly("DataLayer");
    });
            });
            
            //session kullanabilmek için

            services.AddSession(opt =>
            {
                opt.IdleTimeout = TimeSpan.FromMinutes(5);
            });




            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(x =>
                {
                    x.LoginPath = "/Error/Index";
                });


            services.AddMvc(conf =>
            {
                var policy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();
                conf.Filters.Add(new AuthorizeFilter(policy));
            });




            //dependincy inversion kullanımı için yapılması gereken tanımlamalar
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
            services.AddScoped<ISiparisRepository, SiparisRepository>();
            services.AddScoped<ISiparisService, SiparisService>();
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
            app.UseSession();//yazmaz isek session kullnılmaz.(ÖNEMLİ)
            app.UseRouting();
            app.UseAuthorization();
            app.UseAuthentication();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
