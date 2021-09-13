using AquaticAPIUsuario.IServicios;
using AquaticAPIUsuario.ModelsSQL;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;

namespace AquaticAPIUsuario
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
            services.AddSwaggerGen();
            services.AddScoped<IPersonas, Deal.Persona>();
            services.AddScoped<IPersonasData, DataAcces.Personas>();
            services.AddScoped<IUsuariosDatos, DataAcces.Usuario>();
            services.AddScoped<IPersonaUsuario, DataAcces.PersonaUsuario>();
            services.AddScoped<IMailDato, DataAcces.Mail>();
            services.AddScoped<IMail, Deal.Correo>();
            services.AddScoped<IEstadisticas, Deal.Estadisticas>();
            services.AddScoped<IEstadisticasDatos, DataAcces.Estadisticas>();

            services.AddDbContext<AquaticPrixContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddHealthChecks()
                .AddCheck("AquaticAPIUsuario", () => HealthCheckResult.Healthy())
                .AddDbContextCheck<AquaticPrixContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger(c =>
            {
                c.SerializeAsV2 = true;
            });

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "AquaticAPIUsuario");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHealthChecks("/hc", new HealthCheckOptions()
                {
                    Predicate = _ => true,
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                });
                endpoints.MapControllers();
            });
        }
    }
}
