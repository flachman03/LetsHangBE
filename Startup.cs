using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LetsHang.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace LetsHang
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
            services.AddDbContext<UserContext>(options =>
            options.UseNpgsql(Configuration.GetConnectionString("UserConnection")));

            services.AddDbContext<EventContext>(options =>
            options.UseNpgsql(Configuration.GetConnectionString("EventConnection")));

            services.AddDbContext<AdminContext>(options =>
            options.UseNpgsql(Configuration.GetConnectionString("AdminConnection")));

            services.AddControllers();

            services.AddCors( options => 
            {
                options.AddDefaultPolicy(
                    builder => 
                    {
                        builder.WithOrigins("http://localhost:3000")
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                    });
            });

            services.AddAuthentication()
                    .AddGoogle( options => 
                    {
                        IConfigurationSection googleAuthNSection = 
                            Configuration.GetSection("Authentication:Google");

                        options.ClientId = googleAuthNSection["ClientId"];
                        options.ClientSecret = googleAuthNSection["ClientSecret"];
                    });
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

            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
