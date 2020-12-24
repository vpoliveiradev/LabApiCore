using System;
using VPO.Api.Extensions;
using Elmah.Io.AspNetCore;
using Elmah.Io.AspNetCore.HealthChecks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace VPO.Api.Configuration
{
    public static class LoggerConfig
    {
        public static IServiceCollection AddLoggingConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddElmahIo(o =>
            {
                //chave fornecida no cadastro do site elmah.io
                o.ApiKey = "388dd3a277cb44c4aa128b5c899a3106";
                //chave fornecida no cadastro do site elmah.io
                o.LogId = new Guid("c468b2b8-b35d-4f1a-849d-f47b60eef096");
            });

            //Integrando o Health check no ElmahIo
            services.AddHealthChecks()
                .AddElmahIoPublisher(options =>
                {
                    //chave fornecida no cadastro do site elmah.io
                    options.ApiKey = "388dd3a277cb44c4aa128b5c899a3106";
                    //chave fornecida no cadastro do site elmah.io
                    options.LogId = new Guid("c468b2b8-b35d-4f1a-849d-f47b60eef096");
                    options.HeartbeatId = "API Fornecedores";

                })
                .AddCheck("Fornecedores", new SqlServerHealthCheck(configuration.GetConnectionString("DefaultConnection")))
                .AddSqlServer(configuration.GetConnectionString("DefaultConnection"), name: "BancoSQL");

            return services;
        }

        public static IApplicationBuilder UseLoggingConfiguration(this IApplicationBuilder app)
        {
            app.UseElmahIo();

            return app;
        }
    }
}
