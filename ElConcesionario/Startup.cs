using ElConcesionario.BL.Contracts;
using ElConcesionario.BL.Implementations;
using ElConcesionario.DAL.Models;
using ElConcesionario.DAL.Repositories.Contracts;
using ElConcesionario.DAL.Repositories.Implementations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;

namespace ElConcesionario
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
            services.AddControllers();

            //Para habilitar CORS en nuestra API
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });

            //Aquí las inyecciones: Contexto
            services.AddDbContext<desarrollodeinterfacesContext>(opts => opts.UseMySql(Configuration["ConnectionString:ElConcesionarioDB"]));

            //Aquí las inyecciones: Interfaz - Clase
            services.AddScoped<IUsuarioBL, UsuarioBL>();
            services.AddScoped<IVehiculoBL, VehiculoBL>();
            services.AddScoped<IVentaBL, VentaBL>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IVehiculoRepository, VehiculoRepository>();
            services.AddScoped<IVentaRepository, VentaRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors("CorsPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
