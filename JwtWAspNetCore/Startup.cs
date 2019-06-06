using JwtWAspNetCore.Domain;
using JwtWAspNetCore.Services.Classes;
using JwtWAspNetCore.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace JwtWAspNetCore
{
    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApiContext>(options => options.UseSqlServer(this.configuration["ConnectionStrings:ApiContext"]));

            // Repository container
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IPartnerRepository, PartnerRepository>();

            services.AddMvc();
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Test API",
                    Description = "API for Test maintenance",
                    Contact = new Contact
                    {
                        Name = "Jorge Fonseca",
                        Email = "jorge.fonseca87@gmail.com"
                    }
                });
            });

            services.AddCors(cors =>
                cors.AddPolicy("CorsPolicy", policy =>
                    policy.AllowAnyHeader()
                          .AllowAnyMethod()
                          .AllowAnyOrigin()
                          .AllowCredentials()
                ));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            app.UseCors("CorsPolicy");
            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "Test API v1");
            });
        }
    }
}
