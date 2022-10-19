using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Bluebank.Banco.WebApi.Modules.Swagger;
using Bluebank.Banco.WebApi.Modules.Authentication;
using Bluebank.Banco.WebApi.Modules.Feature;
using Bluebank.Banco.WebApi.Modules.Injection;

namespace Bluebank.Banco.WebApi
{
  public class Startup
  {
        readonly string myPolicy = "policyApiEcommerce";
        public Microsoft.AspNetCore.Hosting.IHostingEnvironment _env;
		
        public Startup(IConfiguration configuration, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            Configuration = configuration;
            _env = env;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddFeature(this.Configuration);
            services.AddInjection(this.Configuration);
            services.AddAuthentication(this.Configuration);
            services.AddSwagger(this._env);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API Ecommerce V1");
            });

            app.UseCors(options =>
                {
                  options.WithOrigins("*");
                  options.AllowAnyMethod();
                  options.AllowAnyHeader();
                }
            );
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
  }
}
