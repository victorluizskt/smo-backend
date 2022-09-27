using Microsoft.OpenApi.Models;

namespace MC.Backend
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration, IHostEnvironment env)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient();

            services.AddCors(setup => setup.AddPolicy("ApiPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services.AddControllers();
            services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "API Medical Clinic",
                    Description = "API Medical Clinic",
                    Contact = new OpenApiContact
                    {
                        Name = "MC - Medical Clinic",
                        Url = new Uri("https://github.com/victorluizskt/medical-clinic")
                    }
                });
            });

            Map.Map.SetupDependenceInjection(services);
        }

        public void Configure(
            IApplicationBuilder app,
            IWebHostEnvironment env
        )
        {
            app.UseSwagger(opt =>
            {
                opt.SerializeAsV2 = true;
            });

            app.UseSwaggerUI(opt =>
            {
                opt.DocumentTitle = "API SMO";
                opt.SwaggerEndpoint("/swagger/v1/swagger.json", "API SMO - v1");
            });

            if (env.IsDevelopment() || env.IsEnvironment("Local"))
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("ApiPolicy");
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

    }
}
