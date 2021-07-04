using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Airport.Data.UnitOfWork;
using Airport.Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Airport.Api.Services;

namespace Airport.Api
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
            services.AddCors();

            services.AddControllers().AddNewtonsoftJson(opt =>
            {
                opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

            });

            

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)

                .AddJwtBearer(options =>
                {
                    

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,

                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(Configuration.GetValue<string>("JWTSecretKey"))
                        )
                    };

                });

            

            services.AddSingleton<IAuthService>(
                new AuthService(
                    Configuration.GetValue<string>("JWTSecretKey"),
                    Configuration.GetValue<int>("JWTLifespan")
                )
            );
            
            services.AddScoped<IUnitOfWork, AirportUnitOfWork>();
           
            services.AddDbContext<AirportContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(builder => builder
               .AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader()
               );

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
