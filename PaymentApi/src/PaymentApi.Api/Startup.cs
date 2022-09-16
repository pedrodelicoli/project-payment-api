using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PaymentApi.Application;
using PaymentApi.Application.Interfaces;
using PaymentApi.Repository;
using PaymentApi.Repository.Interfaces;
using System.Text.Json.Serialization;

namespace PaymentApi.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataBaseContext>((opt) => opt.UseInMemoryDatabase("PaymentApiData"));
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<ISaleService, SaleService>();
            services.AddScoped<ISaleRepository, SaleRepository>();

            services.AddControllers()
                .AddJsonOptions(
                    options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter())
                );
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PaymentApi.Api", Version = "v1" });
                var filePathApi = Path.Combine(AppContext.BaseDirectory, "PaymentApi.Api.xml");
                c.IncludeXmlComments(filePathApi);
                var filePathApplication = Path.Combine(AppContext.BaseDirectory, "PaymentApi.Application.xml");
                c.IncludeXmlComments(filePathApplication);
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PaymentApi.Api v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

}
