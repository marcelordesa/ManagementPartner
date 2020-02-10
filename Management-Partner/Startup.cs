using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using mp_Infrastructure;

namespace Management_Partner
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            PartnerContext.ConnectionString = Configuration.GetConnectionString("PartnerDatabase").ToString();
            PartnerContext.DatabaseName = Configuration.GetConnectionString("DatabaseName").ToString();
            PartnerContext.IsSSL = Configuration.GetConnectionString("SSL").ToString().Equals("0") ? false : true;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api Management Partners", Version = "v1" });
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            });

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseCors(option => option.AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader());

            app.UseSwagger();


            app.UseSwagger(x => x.RouteTemplate = "api-docs/{documentName}/swagger.json")
                .UseSwaggerUI(c =>
                {
                    c.OAuthClientId("foo-administration.swagger");
                    c.RoutePrefix = "api-docs";
                    c.SwaggerEndpoint("v1/swagger.json", "Api Management Partners");
                });

            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
