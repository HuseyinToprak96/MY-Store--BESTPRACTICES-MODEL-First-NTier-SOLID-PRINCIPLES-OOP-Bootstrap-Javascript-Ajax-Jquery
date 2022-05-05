using AppAPI.Filters;
using AppAPI.Middlewares;
using CacheLayer;
using CoreLayer.Interfaces.Repository;
using CoreLayer.Interfaces.Services;
using CoreLayer.Interfaces.UnitOfWork;
using DataLayer;
using DataLayer.Repository;
using DataLayer.UnitOfWork;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ServiceLayer.Maping;
using ServiceLayer.Services;
using ServiceLayer.Validations;

namespace AppAPI
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

            services.AddControllers(opt => opt.Filters.Add(new ValidateFilterAttribute())).AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<UrunDtoValidator>());

            services.Configure<ApiBehaviorOptions>(opt =>//API a özel
            {
                opt.SuppressModelStateInvalidFilter = true;
            });


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
            services.AddScoped<ISiparisRepository, SiparisRepository>();
            services.AddScoped<ISiparisService, SiparisService>();
            services.AddAutoMapper(typeof(MapProfile));
            services.AddControllersWithViews();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AppAPI", Version = "v1" });
            });
            services.AddMemoryCache();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AppAPI v1"));
            }
            app.UseCustomException();//Kendi middleware imiz.

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
