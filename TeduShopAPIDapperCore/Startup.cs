using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Swashbuckle.AspNetCore.Swagger;
using System.Collections.Generic;
using System.Linq;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Identity;
using TeduShopData.Models;
using TeduShopAPIDapperCore.Data;
using AutoMapper;
using TeduShopData.Repositories;
using TeduShopData.Repositories.Interfaces;

namespace TeduShopAPIDapperCore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IUserStore<AppUsers>, UserStore>();
            services.AddTransient<IRoleStore<AppRoles>, RoleStore>();
            services.AddTransient<IAttributeRepository, AttributeRepository>();
            services.AddIdentity<AppUsers, AppRoles>()
                .AddDefaultTokenProviders();

            services.AddAutoMapper(typeof(Startup));
            services.AddMvc().SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_3_0)
            .AddJsonOptions(opt =>
            {
                opt.JsonSerializerOptions.PropertyNamingPolicy = null;
                opt.JsonSerializerOptions.DictionaryKeyPolicy = null;
            })
            .AddMvcOptions(opt =>
            {
                opt.EnableEndpointRouting = false;
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "TEDU Project",
                    Description = "TEDU API Swagger surfaces",
                    Contact = new OpenApiContact
                    {
                        Name = "HungDM",
                        Email = "minhhung.international@gmail.com",

                    },
                    License = new Microsoft.OpenApi.Models.OpenApiLicense { Name = "MIT" }
                });
                //c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                //{
                //    In = ParameterLocation.Header,
                //    Description = "Please insert JWT with Bearer into field",
                //    Name = "Authorizaztion",
                //    Type = SecuritySchemeType.ApiKey
                //});
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseSwagger(c =>
            {
                c.PreSerializeFilters.Add((document, request) =>
                {
                    var paths = document.Paths.ToDictionary(item => item.Key.ToLowerInvariant(), item => item.Value);
                    document.Paths.Clear();
                    foreach (var pathItem in paths)
                    {
                        document.Paths.Add(pathItem.Key, pathItem.Value);
                    }
                });
            });
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "TEDU REST API V1");
            });
            app.UseMvc();
        }
    }
}
