using core.Commands;
using core.repository;
using core.service;
using core.store;
using infrastructure.data.mongo.repository;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace services
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

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

            services.AddScoped<IUserRepository, UserMongoRepository>();
            services.AddScoped<IClientRepository, ClientMongoRepository>();
            services.AddScoped<IApiResourceRepository, ApiResourceMongoRepository>();
            services.AddScoped<IApiScopeRepository, ApiScopeMongoRepository>();
            services.AddScoped<IIdentityResourceRepository, IdentityResourceMongoRepository>();

            services.AddControllers();
            services.AddMediatR(typeof(BaseCommand<>));
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LogBehavior<,>));
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "AppnaTech Identity Server API", Version = "v1" }));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection ();
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