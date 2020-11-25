using System;
using application.commands;
using application.core.repositories;
using application.core.services;
using application.core.stores;
using infrastructure.repository.mongo;
using infrastructure.repository.mongo.config;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace service.rest
{
    public class Startup
    {
        private IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddIdentityServer()
                .AddProfileService<ProfileService>()
                .AddResourceOwnerValidator<ResourceOwnerPasswordValidator>()
                .AddClientStore<ClientStore>()
                .AddResourceStore<ResourcesStore>()
                .AddCorsPolicyService<CorsPolicyService>()
                .AddDeveloperSigningCredential(persistKey: false);

            if (string.Equals(Configuration["IdentityServerConfigurations:DataProvider"], "Mongo", StringComparison.OrdinalIgnoreCase))
            {
                services.AddScoped<IUserRepository, UserMongoRepository>();
                services.AddScoped<IClientRepository, ClientMongoRepository>();
                services.AddScoped<IApiResourceRepository, ApiResourceMongoRepository>();
                services.AddScoped<IApiScopeRepository, ApiScopeMongoRepository>();
                services.AddScoped<IIdentityResourceRepository, IdentityResourceMongoRepository>();
            }
            else
            {
                throw new Exception("declared dataType in config not supported");
            }

            services.AddControllers();
            services.AddMediatR(typeof(BaseCommand<>));
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LogBehavior<,>));
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "AppnaTech Identity Server API", Version = "v1" }));

            services.Configure<MongoDataBaseConfigurations>(Configuration.GetSection("MongoDataBaseConfigurations"));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseIdentityServer();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
            app
                .UseSwagger()
                .UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1"));
        }
    }
}
